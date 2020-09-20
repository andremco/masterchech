$projectName = $env:PROJECTNAME
if ([string]::IsNullOrEmpty($projectName)) { throw("Empty var projectName!") }

$apiDir = $env:APIDIR
if ([string]::IsNullOrEmpty($apiDir)) { throw("Empty var apiDir!") }

$webAppDir = $env:WEBAPPDIR
if ([string]::IsNullOrEmpty($webAppDir)) { throw("Empty var webAppDir!") }

$base_dir = resolve-path ./
$source_api_dir = "$base_dir" + $apiDir
$source_web_app_dir = "$base_dir" + $webAppDir

$unitTestProjectPath = "$source_api_dir/UnitTests"
$integrationTestProjectPath = "$source_api_dir/IntegrationTests"
$projectConfig = $env:BUILDCONFIGURATION
$version = $env:VERSION
$verbosity = "m"

$build_dir = "$base_dir/build"
$test_dir = "$build_dir/test"

if ([string]::IsNullOrEmpty($version)) { $version = "9.9.9"}
if ([string]::IsNullOrEmpty($projectConfig)) {$projectConfig = "Release"}

## .env for react!

$urlApi = $env:URLAPI
if ([string]::IsNullOrEmpty($urlApi)) { 
    $urlApi = "htpp://localhost:80/" 
}

$apiKeyHeader = $env:APIKEYHEADER
if ([string]::IsNullOrEmpty($apiKeyHeader)) { 
    $apiKeyHeader = "mykey123" 
}