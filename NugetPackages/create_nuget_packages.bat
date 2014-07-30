cd CoreMvvm
..\..\.nuget\nuget.exe pack Package.nuspec -OutputDirectory ..\

cd ..\CoreWebApi
..\..\.nuget\nuget.exe pack Package.nuspec -OutputDirectory ..\

cd ..\CoreWebApiClient
..\..\.nuget\nuget.exe pack Package.nuspec -OutputDirectory ..\

cd ..\CoreWebApiClient.Generator
..\..\.nuget\nuget.exe pack Package.nuspec -OutputDirectory ..\
