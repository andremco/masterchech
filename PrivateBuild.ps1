$env:ProjectName = "MasterChechBot"
$env:BuildConfiguration = "Debug"
$env:ApiDir = "\src\api"
$env:WebAppDir = "\src\webapp"
$env:Version = "1.0"

. .\BuildNetApi.ps1
. .\BuildReactApp.ps1

PrivateBuildNetApi
CompileReact