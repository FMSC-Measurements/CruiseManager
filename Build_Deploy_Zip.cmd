::@ECHO OFF
SETLOCAL ENABLEEXTENSIONS

::Boilderplate 
::detect if invoked via Window Explorer
SET interactive=1
ECHO %CMDCMDLINE% | FIND /I "/c" >NUL 2>&1
IF %ERRORLEVEL% == 0 SET interactive=0

::name of this script
SET me=%~n0
::directory of script
SET parent=%~dp0
SET zip="%parent%tools\zip.cmd"

IF NOT DEFINED verStamp (SET verStamp=%date:~10,4%%date:~4,2%%date:~7,2%)

set outFile=%parent%InnoSetupFiles\Output\CruiseManager_%verStamp%.zip

cd .\CruiseManager.WinForms\bin\Release\net461

call %zip% a -tzip -spf %outFile%  CruiseManager.exe CruiseManager.exe.config STPinfo.setup x86\*.dll x64\*.dll *.dll Sounds\*

::if invoked from windows explorer, pause
IF "%interactive%"=="0" PAUSE
ENDLOCAL
EXIT /B 0