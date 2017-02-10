; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
; #defines require the ISPP add-on: http://sourceforge.net/projects/ispp/
#define APP "Cruise Manager"
;
#define VERSION "2017.02.09"
;version format for setup file name
#define SETUPVERSION "20170209";  
#define SPECIALTAG ""
#define BASEURL "http://www.fs.fed.us/fmsc/measure"
#define ORGANIZATION "U.S. Forest Service, Forest Management Service Center"
#define EXEName "CruiseManager.exe"

[Setup]
AppName={#APP}
AppMutex={#APP}
AppID={#APP}
AppVerName={#APP} version {#VERSION}
AppVersion={#VERSION}
AppPublisher={#ORGANIZATION}
AppPublisherURL={#BASEURL}
AppSupportURL={#BASEURL}/support.shtml
AppUpdatesURL={#BASEURL}/cruising/index.shtml

DefaultDirName={pf32}\FMSC\{#APP}
DefaultGroupName=FMSC\{#APP}
;InfoBeforeFile="Intro.txt"

VersionInfoDescription={#APP} Setup
VersionInfoCompany={#ORGANIZATION}
VersionInfoVersion={#VERSION}

Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin
ChangesEnvironment=yes
ChangesAssociations=yes
AllowUNCPath=no
AllowNoIcons=yes
ShowLanguageDialog=no

OutputBaseFilename=CruiseManager_Setup_{#SETUPVERSION}
OutputManifestFile=Setup-Manifest.txt

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons};
Name: overwriteTemplates; Description: "Replace Existing Template Files"; GroupDescription: "Template Files"; Flags: checkedonce;  
Name: associateCruiseFileTypes; Description: "Associate Cruise (.cruise) Files with Cruise Manager"; GroupDescription: "Associate File Types"; Flags: checkedonce;
Name: associateCutFileTypes; Description: "Associate Cruise Template (.cut) Files with Cruise Manager"; GroupDescription: "Associate File Types"; Flags: checkedonce;


[Files]
; need to update the paths below after the solution files and folders are updated.
Source: "..\CruiseManager.WinForms\bin\Release\CruiseManager.exe"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\CruiseManager.exe.config"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\*.dll"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\STPinfo.setup"; DestDir: {app}; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\x64\*.dll"; DestDir: {app}\x64; Flags: ignoreversion;
Source: "..\CruiseManager.WinForms\bin\Release\x86\*.dll"; DestDir: {app}\x86; Flags: ignoreversion;
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
