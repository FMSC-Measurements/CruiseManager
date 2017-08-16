::Boilderplate
@ECHO OFF
SETLOCAL ENABLEEXTENSIONS

::name of this script
SET me=%~n0
::directory of script
SET parent=%~dp0

ECHO %me%
::::::::::::::

SET msbuildPath="C:\Program Files (x86)\MSBuild\14.0\bin\amd64\MSBuild.exe"

%msbuildPath%  %parent%\CruiseManager.WinForms\CruiseManager.WinForms.VS15.csproj /target:Rebuild /property:Configuration=Release;Platform=AnyCPU;SolutionDir=%parent%\

::End Boilderplate
EXIT /B %errorlevel%