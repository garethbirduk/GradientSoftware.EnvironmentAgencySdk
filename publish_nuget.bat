echo %GITHUB_USERNAME%
echo %GITHUB_APIKEY%
echo %GITHUB_INDEX%

dotnet build --configuration Release
dotnet nuget push EnvironmentAgencySdk/bin/Release/GradientSoftware.EnvironmentAgencySdk.0.1.0.nupkg --api-key %GITHUB_APIKEY% --source "github" 