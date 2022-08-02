echo %GITHUB_USERNAME%
echo %GITHUB_APIKEY%
echo %GITHUB_INDEX%

dotnet build --configuration Release
pause
dotnet nuget push EnvironmentAgencySdk/bin/Release/GradientSoftware.EnvironmentAgencySdk.0.1.2.nupkg --api-key %GITHUB_APIKEY% --source "github" 