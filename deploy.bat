powershell.exe -NoProfile -ExecutionPolicy Bypass -Command "& { .\PrivateDeploy.ps1; if ($lastexitcode -ne 0) {write-host "ERROR: $lastexitcode" -fore RED; exit $lastexitcode} }" & pause