; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
; #defines require the ISPP add-on: http://sourceforge.net/projects/ispp/
#define APP "Cruise Manager"
;
#define VERSION "2020.01.31"
;version format for setup file name
#define SETUPVERSION "20200131";  
#define SPECIALTAG ""
#define BASEURL "http://www.fs.fed.us/fmsc/measure"
#define ORGANIZATION "U.S. Forest Service, Forest Management Service Center"
#define EXEName "CruiseManager.exe"

[Setup]
;value displayed throught the setup. 
;used as default value for AppId, VersionInfoDescription and VersionInfoProductName 
AppName={#APP}
;used to prevent user from installing/uninstalling while app is running
;requires app code to create a mutex while program is running
AppMutex=CruiseManager
;not displayed in ui. used for uninstall registry key and where install detects previouse install settings
;defaults to AppName
AppID={#APP}
;used as default value for AppVerName. displayed in version field of app's add/remove entry
;used to provide major/minor version values in registry entry
AppVersion={#VERSION}
;app name plus version number
;used as title in add/remove programs entry
;required if AppVersion not provided
AppVerName={#APP} version {#VERSION}

LicenseFile=..\LICENSE.md

AppPublisher={#ORGANIZATION}
AppPublisherURL={#BASEURL}
AppSupportURL={#BASEURL}/support.shtml
AppUpdatesURL={#BASEURL}/cruising/index.shtml

DefaultDirName={pf32}\FMSC\{#APP}
DefaultGroupName=FMSC\{#APP}

;specifies the file version on the setup exe
VersionInfoVersion={#VERSION}

Compression=lzma
;causes all files to be compressed together
;this is less effecent if some files don't need to be installed 
SolidCompression=yes
PrivilegesRequired=admin
;causes installer to notify windows that environment variables have been changed
ChangesEnvironment=yes
;notifys windows that file associations have changed when installer exits
ChangesAssociations=yes

;dont allow program to be installed on network drives
AllowUNCPath=no
AllowNetworkDrive=no


OutputBaseFilename=CruiseManager_Setup
;OutputBaseFilename=CruiseManager_Setup_{#SETUPVERSION}
OutputManifestFile=Setup-Manifest.txt

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons};
Name: overwriteTemplates; Description: "Replace Existing Template Files"; GroupDescription: "Template Files"; Flags: checkedonce;  
Name: associateCruiseFileTypes; Description: "Associate Cruise (.cruise) Files with Cruise Manager"; GroupDescription: "Associate File Types"; Flags: checkedonce;
Name: associateCutFileTypes; Description: "Associate Cruise Template (.cut) Files with Cruise Manager"; GroupDescription: "Associate File Types"; Flags: checkedonce;


[Files]
; need to update the paths below after the solution files and folders are updated.
Source: "..\CruiseManager.WinForms\bin\Release\net451\CruiseManager.exe"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\net451\CruiseManager.exe.config"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\net451\*.dll"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\net451\STPinfo.setup"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\net451\x64\*.dll"; DestDir: {app}\x64; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\net451\x86\*.dll"; DestDir: {app}\x86; Flags: ignoreversion;
Source: "..\Documentation\CruiseManagerUserGuide.docx";DestName: CruiseManagerUserGuide_{#SETUPVERSION}.docx; DestDir: {app}; Flags: ignoreversion
Source: "..\Template Files\*.cut"; DestDir: {userdocs}\CruiseFiles\Templates; Flags: ignoreversion; Tasks: overwriteTemplates;
Source: "..\Template Files\*.cut"; DestDir: {userdocs}\CruiseFiles\Templates; Flags: onlyifdoesntexist; Tasks: not overwriteTemplates;

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: {group}\{#APP}; Filename: {app}\{#EXEName}
Name: {group}\Cruise Manager User Guide; Filename: {app}\CruiseManagerUserGuide_{#SETUPVERSION}.docx
Name: {userdesktop}\{#APP}; Filename: {app}\{#EXEName}; Tasks: desktopicon

[Run]
Filename: "{app}\{#EXEName}"; Description: "{cm:LaunchProgram,Cruise Manager}"; Flags: nowait postinstall skipifsilent

[Registry]
;Register app path
Root: HKLM; Subkey: SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\{#EXEName}; ValueType: string; ValueData: "{app}\{#EXEName}"; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes or associateCutFileTypes;

; Register cruise file
Root: HKCR; SubKey: .cruise; ValueType: string; ValueData: NCS.CruiseFile; Flags: uninsdeletekey; Tasks: associateCruiseFileTypes;
Root: HKCR; SubKey: NCS.CruiseFile; ValueType: string; ValueData: Cruise File; Flags: uninsdeletekey; Tasks: associateCruiseFileTypes;
Root: HKCR; SubKey: NCS.CruiseFile\Shell\Open\Command; ValueType: string; ValueData: """{app}\{#EXEName}"" ""%1"""; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
; NEED NEW FILE ICONS Root: HKCR; Subkey: NCS.CruiseFile\DefaultIcon; ValueType: string; ValueData: {app}\crz1.ico; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;

; Register setup file
Root: HKCR; SubKey: .cut; ValueType: string; ValueData: NCS.TemplateFile; Flags: uninsdeletekey;  Tasks: associateCutFileTypes;
Root: HKCR; SubKey: NCS.TemplateFile; ValueType: string; ValueData: Cruise Template File; Flags: uninsdeletekey;  Tasks: associateCutFileTypes;
Root: HKCR; SubKey: NCS.TemplateFile\Shell\Open\Command; ValueType: string; ValueData: """{app}\{#EXEName}"" ""%1"""; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
; NEED NEW FILE ICONS Root: HKCR; Subkey: NCS.SetupFile\DefaultIcon; ValueType: string; ValueData: {app}\stp1.ico; Flags: uninsdeletevalue; Tasks: associateFileTypes;

; Modify OpenWithList and FileExts for cruise (Requires admin privledges.)
; If user doesn't have admin privledges, setup simply skips these registry changes.
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cruise; ValueName: Application; ValueType: string; ValueData: " "; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cruise\OpenWithList; ValueName: a; ValueType: string; ValueData: {#EXEName}; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cruise\OpenWithList; ValueName: b; ValueType: string; ValueData: " "; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cruise\OpenWithList; ValueName: c; ValueType: string; ValueData: " "; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cruise\OpenWithList; ValueName: MRUList ValueType: string; ValueData: a; Flags: uninsdeletevalue;  Tasks: associateCruiseFileTypes;

; Modify OpenWithList and FileExts for stp (Require admin privledges.)
; If user doesn't have admin privledges, setup simply skips these registry changes.
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cut; ValueName: Application; ValueType: string; ValueData: " "; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cut\OpenWithList; ValueName: a; ValueType: string; ValueData: {#EXEName}; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cut\OpenWithList; ValueName: b; ValueType: string; ValueData: " "; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cut\OpenWithList; ValueName: c; ValueType: string; ValueData: " "; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKCU; SubKey: Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.cut\OpenWithList; ValueName: MRUList ValueType: string; ValueData: a; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
