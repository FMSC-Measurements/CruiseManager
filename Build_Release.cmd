::Boilderplate
@ECHO OFF
SETLOCAL ENABLEEXTENSIONS

::name of this script
SET me=%~n0
::directory of script
SET parent=%~dp0

ECHO %me%
::::::::::::::

REM use VS 2017 MSBuild 
SET msbuildPath="C:\Program Files (x86)\MSBuild\15.0\bin\amd64\MSBuild.exe"

ECHO "falling back on VS 2015"
IF NOT EXIST %msbuildPath% (
	SET msbuildPath="C:\Program Files (x86)\MSBuild\14.0\bin\amd64\MSBuild.exe")

%msbuildPath%  %parent%\CruiseManager.WinForms\CruiseManager.WinForms.csproj /target:Rebuild /property:Configuration=Release;Platform=AnyCPU;SolutionDir=%parent%\

::End Boilderplate
EXIT /B %errorlevel%