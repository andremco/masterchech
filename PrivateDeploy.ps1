$env:PROJECTNAME = "MasterChechBot"
$env:BUILDCONFIGURATION = "Debug"
$env:APIDIR = "/src/api"
$env:WEBAPPDIR = "/src/webapp"
$env:VERSION = "1.0"

. .\BuildNetApi.ps1
. .\BuildReactApp.ps1

$sw = [Diagnostics.Stopwatch]::StartNew()
PrivateBuildNetApi
PrivateBuildReact
$csProjWebApi = "$env:APIDIR/$env:PROJECTNAME""WebApi""/$env:PROJECTNAME""WebApi"".csproj"
# Publish Net Core Api
exec {
    & dotnet publish "./$csProjWebApi" -c $env:BUILDCONFIGURATION --no-restore --no-build -o "./$env:APIDIR/$env:PROJECTNAME""WebApi""/publish/"
}
# Docker compose applications
exec {
	& docker-compose up -d --build
}
$sw.Stop()
write-host "Build time: " $sw.Elapsed.ToString()