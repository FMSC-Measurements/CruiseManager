::Boilderplate 
@ECHO OFF
SETLOCAL ENABLEEXTENSIONS

::detect if invoked via Window Explorer
SET interactive=1
ECHO %CMDCMDLINE% | FIND /I "/c" >NUL 2>&1
IF %ERRORLEVEL% == 0 SET interactive=0

::name of this script
SET me=%~n0
::directory of script
SET parent=%~dp0
::::::::::::::::::


IF NOT DEFINED verStamp (SET verStamp=%date:~10,4%%date:~4,2%%date:~7,2%)

CALL %parent%/Build_Release.cmd

IF /I "%ERRORLEVEL%" NEQ "0" (
ECHO build failed
IF "%interactive%"=="0" PAUSE
EXIT /B 1
)

"C:\Program Files (x86)\Inno Setup 5\iscc" /dAPP_VERSION=%appVer% /F"CruiseManager_Setup_%verStamp%" "./InnoSetupFiles/CruiseManager.iss" 

::End Boilderplate
::if invoked from windows explorer, pause
IF "%interactive%"=="0" PAUSE
ENDLOCAL
EXIT /B 0
