. .\EnvironmentVariable.ps1
. .\BuildFunctions.ps1

Function PrivateBuildReact{

	exec {
		& cd $source_web_app_dir
		& npm install --no-optional
		& npm run build
		& cd $base_dir
	}
}