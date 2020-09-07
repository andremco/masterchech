. .\EnvironmentVariable.ps1
. .\BuildFunctions.ps1

Function PrivateBuildReact{

	exec {
		& npm --prefix "$source_web_app_dir/install" install $source_web_app_dir
		& npm --prefix $source_web_app_dir run build
		& Remove-Item -Recurse -Force "./deploy/webapp"
		& Copy-Item "$source_web_app_dir/build/*" -Destination './deploy/webapp' -Recurse
	}
}