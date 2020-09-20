. .\EnvironmentVariable.ps1
. .\BuildFunctions.ps1

Function CIBuildReact{

	exec{
		& cd $source_web_app_dir
		& npm install 
	}
	CreateFileEnvIfNotExitsForReact
	exec{
		& npm run build
		& cd $base_dir
	}
}

Function CreateFileEnvIfNotExitsForReact{
	if (-Not(Test-Path ".env")) {
		exec{
			Set-Content -Path .env -Value "REACT_APP_API_URL=$urlApi`nREACT_APP_API_KEY_HEADER=$apiKeyHeader"
		}
	}
}