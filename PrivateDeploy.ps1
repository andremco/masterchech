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
    & dotnet publish "./$csProjWebApi" -c $env:BUILDCONFIGURATION -o ./deploy/api/
}
# Publish React Web App
exec{
	& Remove-Item –path "./deploy/webapp/*" -Recurse
	& Copy-Item "$source_web_app_dir/build/*" -Destination './deploy/webapp' -Recurse
}
# Docker compose applications
exec {
	& docker-compose up -d --build
}
$sw.Stop()
write-host "Build time: " $sw.Elapsed.ToString()