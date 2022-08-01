@echo off

dotnet test EnvironmentAgencySdk.Test/EnvironmentAgencySdk.Test.csproj /p:CollectCoverage=true /p:CoverletOutputFormat="opencover" --verbosity normal

dotnet tool install -g dotnet-reportgenerator-globaltool

reportgenerator "-reports:EnvironmentAgencySdk.Test/coverage.opencover.xml" "-targetdir:./coverage/" "-reporttypes:Badges;Html;TextSummary"

IF [%1]==[-s] GOTO:show 
IF [%1]==[--show] GOTO:show

GOTO:eof

:show

  rundll32 url.dll,FileProtocolHandler coverage\index.html
