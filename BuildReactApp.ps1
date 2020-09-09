. .\EnvironmentVariable.ps1
. .\BuildFunctions.ps1

Function PrivateBuildReact{

	exec {
		& npm install $source_web_app_dir
		& npm --prefix $source_web_app_dir run build
	}
}