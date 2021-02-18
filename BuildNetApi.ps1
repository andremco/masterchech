. .\EnvironmentVariable.ps1
. .\BuildFunctions.ps1
 
Function InitNet {
    rd $build_dir -recurse -force  -ErrorAction Ignore
	md $build_dir > $null

	exec {
		& dotnet clean $source_api_dir/$projectName.sln -nologo -v $verbosity
		}
	exec {
		& dotnet restore $source_api_dir/$projectName.sln -nologo --interactive -v $verbosity  
		}
    

    Write-Host $projectConfig
    Write-Host $version
}


Function CompileNet{
	exec {
		& dotnet build $source_api_dir/$projectName.sln -nologo --no-restore -v $verbosity -maxcpucount --configuration $projectConfig --no-incremental /p:Version=$version /p:Authors="Andre" /p:Product="Architecture"
	}
}

Function UnitTestsNet{
	Push-Location -Path $unitTestProjectPath

	try {
		exec {
			& dotnet test -nologo -v $verbosity --logger:trx --results-directory $test_dir --no-build --no-restore --configuration $projectConfig /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=$test_dir/coverage/
			& dotnet reportgenerator -reports:"$test_dir/coverage/coverage.cobertura.xml" -targetDir:"$test_dir/coverage/reports" -tag:$version -reportTypes:htmlInline
		}
	}
	finally {
		Pop-Location
	}
}

Function IntegrationTestNet{
	Push-Location -Path $integrationTestProjectPath

	try {
		exec {
			& dotnet test -nologo -v $verbosity --logger:trx --results-directory $test_dir --no-build --no-restore --configuration $projectConfig /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=$test_dir/Coverage/
			& dotnet reportgenerator -reports:"$test_dir/coverage/coverage.cobertura.xml" -targetDir:"$test_dir/coverage/reports" -tag:$version -reportTypes:htmlInline
		}
	}
	finally {
		Pop-Location
	}
}

Function PublishNet{
	$csProjWebApi = "$apiDir/src/$projectName"".WebApi""/$projectName"".WebApi"".csproj"
	# Publish Net Core Api
	exec {
		& dotnet publish "./$csProjWebApi" -c $projectConfig --no-restore --no-build -o "./$apiDir/src/$projectName"".WebApi""/publish/"
	}
}

Function CIBuildNetApi{
	InitNet
	CompileNet
	UnitTestsNet
	IntegrationTestNet
	PublishNet
}