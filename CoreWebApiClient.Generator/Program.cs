﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.CSharp;

namespace CoreWebApiClient.Generator
{
    // todo: support controller method like void Login() for get and post (no parameters, no return type; basically investigate all possible method combinations)
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: CoreWebApiClient.Generator.exe <path to an assembly with web api controllers> <generated namespace> <output folder>");
                return -1;
            }
            var sourceAssembly = args[0];
            var generatedNamespace = args[1];
            var outputFolder = args[2];
            try
            {
                if (ShouldRegenerateControllerClients(sourceAssembly, outputFolder))
                {
                    GenerateWebApiClients(sourceAssembly, generatedNamespace, outputFolder);                    
                    Console.WriteLine("Controller clients were regenerated");
                }
                else
                {
                    Console.WriteLine("No change detected in source web api controllers - controller clients were not regenerated");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return -2;
            }
            return 0;
        }

        private static bool ShouldRegenerateControllerClients(string sourceAssembly, string outputFolder)
        {
            var assemblyWriteTime = File.GetLastWriteTime(sourceAssembly);
            var files = Directory.GetFiles(outputFolder, "*ControllerClient.cs");
            var shouldRegenerate = false;
            foreach (var file in files)
            {
                var sourceFileWriteTime = File.GetLastWriteTime(file);
                if (assemblyWriteTime > sourceFileWriteTime)
                {
                    shouldRegenerate = true;
                }
            }
            return !files.Any() || shouldRegenerate;
        }

        // http://msdn.microsoft.com/en-us/library/system.codedom.compiler.codedomprovider%28VS.80%29.aspx
        // http://stackoverflow.com/questions/484489/is-there-a-way-to-programmatically-extract-an-interface
        private static void GenerateWebApiClients(string sourceAssembly, string generatedNamespace, string outputFolder)
        {
            var assembly = Assembly.LoadFrom(sourceAssembly);
            var apiControllerTypes = GetAllApiControllers(assembly);

            foreach (var controllerType in apiControllerTypes)
            {
                ProcessController(controllerType, generatedNamespace, outputFolder);
            }
        }

        private static void ProcessController(Type controllerType, string generatedNamespace, string outputFolder)
        {
            var methodInfos = controllerType.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            var controllerName = controllerType.Name.Replace("Controller", "");
            
            CodeCompileUnit interfaceCompileUnit;
            CodeTypeDeclaration clientInterface;
            CodeCompileUnit classCompileUnit;
            CodeTypeDeclaration clientClass;
            CreateInterfaceAndClassCompileUnitsAndTypeDeclarations(controllerName, 
                                                                   generatedNamespace,
                                                                   out interfaceCompileUnit,
                                                                   out clientInterface,
                                                                   out classCompileUnit,
                                                                   out clientClass);

            foreach (var methodInfo in methodInfos)
            {
                ProcessControllerMethod(controllerType, methodInfo, clientInterface, clientClass);
            }

            CodeDomProvider provider = new CSharpCodeProvider();

            var interfaceFileName = string.Format(@"{0}\I{1}ControllerClient.cs", outputFolder, controllerName);
            GenerateCode(interfaceFileName, provider, interfaceCompileUnit);

            var classFileName = string.Format(@"{0}\{1}ControllerClient.cs", outputFolder, controllerName);
            GenerateCode(classFileName, provider, classCompileUnit);
        }

        private static void CreateInterfaceAndClassCompileUnitsAndTypeDeclarations(string controllerName, string generatedNamespace,
                                                                  out CodeCompileUnit interfaceCompileUnit,
                                                                  out CodeTypeDeclaration clientInterface,
                                                                  out CodeCompileUnit classCompileUnit,
                                                                  out CodeTypeDeclaration clientClass)
        {
            var interfaceNamespace = new CodeNamespace(generatedNamespace);
            interfaceCompileUnit = new CodeCompileUnit();
            interfaceCompileUnit.Namespaces.Add(interfaceNamespace);
            var interfaceName = string.Format("I{0}ControllerClient", controllerName);
            clientInterface = new CodeTypeDeclaration(interfaceName) {IsInterface = true};
            interfaceNamespace.Types.Add(clientInterface);

            var classNamespace = new CodeNamespace(generatedNamespace);
            classCompileUnit = new CodeCompileUnit();
            classCompileUnit.Namespaces.Add(classNamespace);
            clientClass = new CodeTypeDeclaration(string.Format("{0}ControllerClient", controllerName));
            clientClass.BaseTypes.Add(new CodeTypeReference(typeof (BaseApiControllerClient)));
            clientClass.BaseTypes.Add(new CodeTypeReference(interfaceName));
            classNamespace.Types.Add(clientClass);

            var constructor = new CodeConstructor
                {
                    Attributes = MemberAttributes.Public
                };
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof (string), "serverUrl"));
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof (RouteCollection), "routes"));
            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("serverUrl"));
            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("routes"));
            clientClass.Members.Add(constructor);

            var constructorWithAuthentication = new CodeConstructor
                {
                    Attributes = MemberAttributes.Public
                };
            constructorWithAuthentication.Parameters.Add(new CodeParameterDeclarationExpression(typeof (string), "serverUrl"));
            constructorWithAuthentication.Parameters.Add(new CodeParameterDeclarationExpression(typeof (RouteCollection), "routes"));
            constructorWithAuthentication.Parameters.Add(
                new CodeParameterDeclarationExpression(typeof (IAuthenticationCookiePersister), "authenticationCookiePersister"));
            constructorWithAuthentication.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("serverUrl"));
            constructorWithAuthentication.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("routes"));
            constructorWithAuthentication.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("authenticationCookiePersister"));
            clientClass.Members.Add(constructorWithAuthentication);
        }

        private static void ProcessControllerMethod(Type controllerType, MethodInfo methodInfo, CodeTypeDeclaration clientInterface,
                                                    CodeTypeDeclaration clientClass)
        {
            var method = new CodeMemberMethod {Name = methodInfo.Name, Attributes = MemberAttributes.Public};
            var asyncMethod = new CodeMemberMethod {Name = methodInfo.Name + "Async", Attributes = MemberAttributes.Public};

            var routeValuesDeclarationStatement = new CodeVariableDeclarationStatement(
                typeof (RouteValueDictionary), "routeValues", new CodeObjectCreateExpression(typeof (RouteValueDictionary)));
            var routeValuesReference = new CodeVariableReferenceExpression("routeValues");

            method.Statements.Add(routeValuesDeclarationStatement);
            asyncMethod.Statements.Add(routeValuesDeclarationStatement);

            var parameterInfos = methodInfo.GetParameters();

            if (methodInfo.GetCustomAttributes(typeof (HttpPutAttribute), true).Any() ||
                methodInfo.GetCustomAttributes(typeof (HttpDeleteAttribute), true).Any())
            {
                throw new Exception(string.Format("{0}.{1}: PUT and DELETE methods are not supported", controllerType.Name,
                                                  methodInfo.Name));
            }

            var methodHasHttpGetAttribute = methodInfo.GetCustomAttributes(typeof (HttpGetAttribute), true).Any();
            var methodHasHttpPostAttribute = methodInfo.GetCustomAttributes(typeof (HttpPostAttribute), true).Any();
            var atLeastOneParameterHasFromBodyAttribute =
                parameterInfos.Any(x => x.GetCustomAttributes(typeof (FromBodyAttribute), true).Any());
            var allParametersAreSimpleType = parameterInfos.All(x => IsSimpleType(x.ParameterType));

            if (methodHasHttpGetAttribute && atLeastOneParameterHasFromBodyAttribute)
            {
                throw new Exception(string.Format("{0}.{1}: HttpGet attribute and FromBody are not compatible",
                                                  controllerType.Name, methodInfo.Name));
            }
            if (methodHasHttpGetAttribute && !allParametersAreSimpleType)
            {
                throw new Exception(
                    string.Format("{0}.{1}: all parameters need to be of a simple style when having HttpGet attribute",
                                  controllerType.Name, methodInfo.Name));
            }

            var isPost = methodHasHttpPostAttribute
                         || atLeastOneParameterHasFromBodyAttribute
                         || !allParametersAreSimpleType;

            if (!isPost && !methodHasHttpGetAttribute && !methodInfo.Name.ToLower().StartsWith("get"))
            {
                throw new Exception(string.Format("{0}.{1}: add HttpGet attribute or rename the method to Get{1}",
                                                  controllerType.Name, methodInfo.Name));
            }

            var numberOfHttpBodyParameters = 0;

            CodeVariableReferenceExpression httpBodyParameterVariableReference = null;
            foreach (var parameterInfo in parameterInfos)
            {
                isPost = ProcessControllerMethodParameter(controllerType, methodInfo, parameterInfo, isPost, method,
                                                          asyncMethod, routeValuesReference,
                                                          ref numberOfHttpBodyParameters,
                                                          ref httpBodyParameterVariableReference);
            }

            method.ReturnType = new CodeTypeReference(methodInfo.ReturnType);
            var returnTypeIsVoid = methodInfo.ReturnType == typeof (void);
            if (returnTypeIsVoid)
            {
                asyncMethod.ReturnType = new CodeTypeReference(typeof (Task));
            }
            else
            {
                var taskType = typeof (Task<>);
                var returnAsyncType = taskType.MakeGenericType(methodInfo.ReturnType);
                asyncMethod.ReturnType = new CodeTypeReference(returnAsyncType);
            }

            clientInterface.Members.Add(method);
            clientInterface.Members.Add(asyncMethod);

            var typeParameters = returnTypeIsVoid
                                     ? new CodeTypeReference[0]
                                     : new[] {method.ReturnType};

            var codeMethodReferenceExpression = new CodeMethodReferenceExpression(
                new CodeThisReferenceExpression(),
                isPost ? "HttpClientPost" : (returnTypeIsVoid ? "HttpClientGetNoReturnValue" : "HttpClientGet"),
                typeParameters);
            var statement = isPost
                                ? new CodeMethodInvokeExpression(codeMethodReferenceExpression,
                                                                 new CodePrimitiveExpression(methodInfo.Name),
                                                                 httpBodyParameterVariableReference, routeValuesReference)
                                : new CodeMethodInvokeExpression(codeMethodReferenceExpression,
                                                                 new CodePrimitiveExpression(methodInfo.Name),
                                                                 routeValuesReference);

            var asyncCodeMethodReferenceExpression = new CodeMethodReferenceExpression(
                new CodeThisReferenceExpression(),
                isPost
                    ? "HttpClientPostAsync"
                    : (returnTypeIsVoid ? "HttpClientGetNoReturnValueAsync" : "HttpClientGetAsync"),
                typeParameters);
            var asyncStatement = isPost
                                     ? new CodeMethodInvokeExpression(asyncCodeMethodReferenceExpression,
                                                                      new CodePrimitiveExpression(methodInfo.Name),
                                                                      httpBodyParameterVariableReference,
                                                                      routeValuesReference)
                                     : new CodeMethodInvokeExpression(asyncCodeMethodReferenceExpression,
                                                                      new CodePrimitiveExpression(methodInfo.Name),
                                                                      routeValuesReference);
            var asyncCodeMethodReturnStatement = new CodeMethodReturnStatement(asyncStatement);

            if (returnTypeIsVoid)
            {
                method.Statements.Add(statement);
                asyncMethod.Statements.Add(asyncCodeMethodReturnStatement);
            }
            else
            {
                method.Statements.Add(new CodeMethodReturnStatement(statement));
                asyncMethod.Statements.Add(asyncCodeMethodReturnStatement);
            }

            clientClass.Members.Add(method);
            clientClass.Members.Add(asyncMethod);
        }

        private static bool ProcessControllerMethodParameter(Type controllerType, MethodInfo methodInfo,
                                                             ParameterInfo parameterInfo, bool isPost, CodeMemberMethod method,
                                                             CodeMemberMethod asyncMethod,
                                                             CodeVariableReferenceExpression routeValuesReference,
                                                             ref int numberOfHttpBodyParameters,
                                                             ref CodeVariableReferenceExpression httpBodyParameterVariableReference)
        {
            var hasFromBodyAttribute = parameterInfo.GetCustomAttributes(typeof (FromBodyAttribute), true).Any();
            var isComplexType = !IsSimpleType(parameterInfo.ParameterType);
            var isHttpBodyParameter = hasFromBodyAttribute || isComplexType;
            if (isHttpBodyParameter)
            {
                isPost = true;
                numberOfHttpBodyParameters++;
            }
            if (isPost && numberOfHttpBodyParameters > 1)
                throw new Exception(string.Format("{0}.{1} can have only one http body parameter", controllerType.Name,
                                                  methodInfo.Name));

            method.Parameters.Add(new CodeParameterDeclarationExpression(parameterInfo.ParameterType, parameterInfo.Name));
            asyncMethod.Parameters.Add(new CodeParameterDeclarationExpression(parameterInfo.ParameterType,
                                                                              parameterInfo.Name));

            if (!isHttpBodyParameter)
            {
                var addParameterToRouteValues = new CodeMethodInvokeExpression(routeValuesReference, "Add",
                                                                               new CodePrimitiveExpression(
                                                                                   parameterInfo.Name),
                                                                               new CodeVariableReferenceExpression(
                                                                                   parameterInfo.Name));
                method.Statements.Add(addParameterToRouteValues);
                asyncMethod.Statements.Add(addParameterToRouteValues);
            }
            else
            {
                httpBodyParameterVariableReference = new CodeVariableReferenceExpression(parameterInfo.Name);
            }
            return isPost;
        }

        private static IEnumerable<Type> GetAllApiControllers(Assembly assembly)
        {
            return assembly
                .GetTypes()
                .Where(x =>
                       (typeof (ApiController).IsAssignableFrom(x)
                        && x.IsClass
                        && !x.IsAbstract)
                ).ToList();
        }

        private static void GenerateCode(string sourceFileName, CodeDomProvider provider, CodeCompileUnit compileunit)
        {
            var tw = new IndentedTextWriter(new StreamWriter(sourceFileName, false), "    ");
            provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions());
            tw.Close();
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive || type == typeof (string);
        }
    }
}
