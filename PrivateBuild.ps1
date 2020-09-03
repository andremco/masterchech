$env:ProjectName = "MasterChechBot"
$env:BuildConfiguration = "Debug"
$env:ApiDir = "\src\api"
$env:WebAppDir = "\src\webapp"
$env:Version = "1.0"

. .\BuildNetApi.ps1
. .\BuildReactApp.ps1

$sw = [Diagnostics.Stopwatch]::StartNew()
PrivateBuildNetApi
PrivateBuildReact
$sw.Stop()
write-host "Build time: " $sw.Elapsed.ToString()