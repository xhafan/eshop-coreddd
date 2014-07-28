cd CoreWebApiClient
..\..\.nuget\nuget.exe pack Package.nuspec -OutputDirectory ..\

cd ..\CoreWebApiClient.Generator
..\..\.nuget\nuget.exe pack Package.nuspec -OutputDirectory ..\
