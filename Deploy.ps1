$progFilesPath = ${env:ProgramFiles(x86)}
if(-not($progFilesPath)){
    $progFilesPath = "C:\Program Files"
    }

$MsBuild = $env:systemroot + "\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe";
$mstestPath = $progFilesPath + "\Microsoft Visual Studio 12.0\Common7\IDE\MSTest.exe";

Write-Host "Clean and Build"
Start-Process $MsBuild -ArgumentList "Praticum.sln /t:clean"  -NoNewWindow -Wait
Start-Process $MsBuild -ArgumentList "Praticum.sln /p:Configuration=Release" -NoNewWindow -Wait




Write-Host "Build Application Structure"
$executionPath = split-path $SCRIPT:MyInvocation.MyCommand.Path -parent
$applicationPath = $executionPath + "\Application"
$applicationTestPath = $executionPath + "\ApplicationTests"

if(Test-Path($applicationPath)){
    Remove-Item "$applicationPath\*" -Recurse
}
else{
  New-Item -ItemType directory -Path $applicationPath
}

if(Test-Path($applicationTestPath)){
    Remove-Item "$applicationTestPath\*" -Recurse
}
else{
  New-Item -ItemType directory -Path $applicationTestPath
}

Write-Host "Coping files"
Copy-Item  "$executionPath\Practicum.Console\bin\Release\*" $applicationPath
Copy-Item "$executionPath\Practicum.Meals\bin\Release\*" $applicationPath
Copy-Item "$executionPath\Practicum.Rules\bin\Release\*" $applicationPath
Copy-Item "$executionPath\Practicum.Meal.Rules\bin\Release\*" $applicationPath

Copy-Item "$executionPath\Practicum.Console.Test\bin\Release\*" $applicationTestPath
Copy-Item "$executionPath\Practicum.Meals.Test\bin\Release\*" $applicationTestPath
Copy-Item "$executionPath\Practicum.Rules.Test\bin\Release\*" $applicationTestPath
Copy-Item "$executionPath\Practicum.Meal.Rules.Test\bin\Release\*" $applicationTestPath

Write-Host "Running Unit Tests"

Start-Process $mstestPath -ArgumentList "/testcontainer:./ApplicationTests/Practicum.Console.Test.dll" -NoNewWindow -Wait
Start-Process $mstestPath -ArgumentList "/testcontainer:./ApplicationTests/Practicum.Meal.Rules.Test.dll" -NoNewWindow -Wait
Start-Process $mstestPath -ArgumentList "/testcontainer:./ApplicationTests/Practicum.Meals.Test.dll" -NoNewWindow -Wait
Start-Process $mstestPath -ArgumentList "/testcontainer:./ApplicationTests/Practicum.Rules.Test.dll" -NoNewWindow -Wait
 

