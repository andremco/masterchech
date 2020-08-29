. .\environmentVariable.ps1
. .\BuildFunctions.ps1

Function CompileReact{
	$sw = [Diagnostics.Stopwatch]::StartNew()
	exec {
		& npm install $source_web_app_dir
	}
	$sw.Stop()
	write-host "Build time: " $sw.Elapsed.ToString()
}