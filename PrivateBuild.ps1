$env:PROJECTNAME = "MasterChechBot"
$env:BUILDCONFIGURATION = "Debug"
$env:APIDIR = "/src/api"
$env:WEBAPPDIR = "/src/webapp"
$env:VERSION = "1.0"

. .\BuildNetApi.ps1
. .\BuildReactApp.ps1

$sw = [Diagnostics.Stopwatch]::StartNew()
PrivateBuildNetApi
#PrivateBuildReact
$sw.Stop()
write-host "Build time: " $sw.Elapsed.ToString()