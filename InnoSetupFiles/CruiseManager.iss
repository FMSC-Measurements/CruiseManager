; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
; #defines require the ISPP add-on: http://sourceforge.net/projects/ispp/
#define MsBuildOutputDir "..\CruiseManager.WinForms\bin\Release\net462"
#define APP "Cruise Manager"
;
#define VERSION "2021.05.24.1"
;version format for setup file name
#define SETUPVERSION "202105241";  
#define SPECIALTAG ""
#define BASEURL "https://www.fs.fed.us/forestmanagement/products/measurement"
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

DefaultDirName={autopf}\FMSC\{#APP}
DefaultGroupName=FMSC\{#APP}

;specifies the file version on the setup exe
VersionInfoVersion={#VERSION}

Compression=lzma
;causes all files to be compressed together
;this is less effecent if some files don't need to be installed 
SolidCompression=yes
;notifys windows that file associations have changed when installer exits
ChangesAssociations=yes

;dont allow program to be installed on network drives
AllowUNCPath=no
AllowNetworkDrive=no

PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog


;OutputBaseFilename=CruiseManager_Setup
OutputBaseFilename=CruiseManager_Setup_{#SETUPVERSION}
OutputManifestFile=Setup-Manifest.txt

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons};
Name: deployTemplates; Description: "Templates"; GroupDescription: "Template Files"; Flags: checkablealone
Name: deployTemplates/overwriteTemplates; Description: "Recopy existing template files"; GroupDescription: "Template Files"; Flags: unchecked dontinheritcheck;  
Name: associateCruiseFileTypes; Description: "Associate Cruise (.cruise) Files with Cruise Manager"; GroupDescription: "Associate File Types";
Name: associateCutFileTypes; Description: "Associate Cruise Template (.cut) Files with Cruise Manager"; GroupDescription: "Associate File Types";

[Dirs]
Name: "{app}\Templates"; Flags: deleteafterinstall;

[Files]
; need to update the paths below after the solution files and folders are updated.
Source: "{#MsBuildOutputDir}\CruiseManager.exe"; DestDir: {app}; Flags: ignoreversion;
Source: "{#MsBuildOutputDir}\CruiseManager.exe.config"; DestDir: {app}; Flags: ignoreversion;
Source: "{#MsBuildOutputDir}\*.dll"; DestDir: {app}; Flags: ignoreversion;
Source: "{#MsBuildOutputDir}\STPinfo\*.xml"; DestDir: {app}\STPinfo; Flags: ignoreversion;
Source: "{#MsBuildOutputDir}\runtimes\win-x64\native\*.dll"; DestDir: {app}\runtimes\win-x64\native; Flags: ignoreversion;
Source: "{#MsBuildOutputDir}\net461\runtimes\win-x86\native\*.dll"; DestDir: {app}\runtimes\win-x86\native; Flags: ignoreversion;
Source: "..\Documentation\CruiseManagerUserGuide.docx";DestName: CruiseManagerUserGuide_{#SETUPVERSION}.docx; DestDir: {app}; Flags: ignoreversion;
Source: "..\Template Files\*.cut"; DestDir: {app}\Templates; Flags: ignoreversion deleteafterinstall;

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: {group}\{#APP}; Filename: {app}\{#EXEName}
Name: {group}\Cruise Manager User Guide; Filename: {app}\CruiseManagerUserGuide_{#SETUPVERSION}.docx
Name: {autodesktop}\{#APP}; Filename: {app}\{#EXEName}; Tasks: desktopicon

[Run]
Filename: "{app}\{#EXEName}"; Description: "{cm:LaunchProgram,Cruise Manager}"; Flags: nowait postinstall skipifsilent

[Registry]

Root: HKLM; Subkey: SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\{#EXEName}; ValueType: none; Flags: deletekey noerror;

Root: HKA; Subkey: "Software\Classes\Applications\CruiseManager.exe\SupportedTypes"; ValueType: string; ValueName: ".cruise"; ValueData: ""; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKA; Subkey: "Software\Classes\Applications\CruiseManager.exe\SupportedTypes"; ValueType: string; ValueName: ".cut"; ValueData: ""; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;

; NCS.CruiseFile is the internal unique name for the file type assocation for the .cruise extention
Root: HKA; Subkey: "Software\Classes\.cruise"; ValueType: string; ValueName: ""; ValueData: "NCS.CruiseFile"; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKA; Subkey: "Software\Classes\.cruise\OpenWithProgids"; ValueType: string; ValueName: "NCS.CruiseFile"; ValueData: ""; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKA; Subkey: "Software\Classes\NCS.CruiseFile"; ValueType: string; ValueName: ""; ValueData: "Cruise File V2"; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
; the ',0' in ValueData tells Explorer to use the first icon from CruiseManager.exe
Root: HKA; Subkey: "Software\Classes\NCS.CruiseFile\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#EXEName},0"; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;
Root: HKA; Subkey: "Software\Classes\NCS.CruiseFile\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#EXEName}"" ""%1"""; Flags: uninsdeletevalue; Tasks: associateCruiseFileTypes;

; register cruise template files
Root: HKA; Subkey: "Software\Classes\.cut"; ValueType: string; ValueName: ""; ValueData: "NCS.TemplateFile"; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKA; Subkey: "Software\Classes\.cut\OpenWithProgids"; ValueType: string; ValueName: "NCS.TemplateFile"; ValueData: ""; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKA; Subkey: "Software\Classes\NCS.TemplateFile"; ValueType: string; ValueName: ""; ValueData: "Cruise Template File V2"; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKA; Subkey: "Software\Classes\NCS.TemplateFile\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#EXEName},0"; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;
Root: HKA; Subkey: "Software\Classes\NCS.TemplateFile\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#EXEName}"" ""%1"""; Flags: uninsdeletevalue; Tasks: associateCutFileTypes;


[Code]

function ShouldSkipPage(PageID: Integer): Boolean;
begin
  Log('ShouldSkipPage(' + IntToStr(PageID) + ') called');
  { Skip wpSelectDir page if admin install; show all others }
  case PageID of
    wpSelectDir:
      Result := IsAdminInstallMode();
  else
    Result := False;
  end;
end;

{ copys files matching pattern from srcDir to destDir }
procedure CopyFiles(srcDir: String; pattern: String; destDir: String; overwrite: Boolean);
var 
  FindRec: TFindRec;
begin
  if ForceDirectories(destDir) then
  begin {itterate files in srcDir and copy them to destDir }
    if FindFirst(srcDir + pattern, FindRec) then
    begin
      try
        repeat
          Log('Copy ' + srcDir + FindRec.Name + ' -> ' + destDir + FindRec.Name);
          if FileCopy(srcDir + FindRec.Name, destDir + FindRec.Name, not overwrite) then
          begin
            Log('File Copyed ' + srcDir + FindRec.Name + ' -> ' + destDir + FindRec.Name);
          end else
          begin
            Log('File NOT Copyed ' + srcDir + FindRec.Name + ' -> ' + destDir + FindRec.Name);
          end;
        until not FindNext(FindRec);
      finally
        FindClose(FindRec);
      end; { end try }
    end;   { end file copy loop }   
  end else { end if force dir }
  begin
    Log('Error Creating Dir ' + destDir);
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  UsersPath: String;
  DocumentsPath: String;
  DesktopPath: String;
  UserTemplatesPath: String;
  CopyTemplateIfExists: Boolean;
  UserDirFindRec: TFindRec;
  TemplateSrcPath: String;
begin
  { Once the files are installed }
  if (CurStep = ssPostInstall) and WizardIsTaskSelected('deployTemplates') then
  begin
    Log('Copying Templates');
    TemplateSrcPath := ExpandConstant('{app}') + '\Templates\';
    if IsAdminInstallMode() then
    begin
      UsersPath := ExpandConstant('{%HOMEDRIVE|C:}') + '\Users\';
      Log(Format('Users Path [%s]', [UsersPath]));

      { Iterate all users }
      if FindFirst(UsersPath + '*', UserDirFindRec) then
      begin
        try
          repeat  
            { Just directories and ignore Public, All Users, and Default User. All Users and Default User are symbolic links that we don't care about }

            if (UserDirFindRec.Attributes and FILE_ATTRIBUTE_DIRECTORY <> 0) and (UserDirFindRec.Name <> 'Public') and (UserDirFindRec.Name <> 'All Users') and (UserDirFindRec.Name <> 'Default User') then
            begin
              DocumentsPath := UsersPath + UserDirFindRec.Name + '\Documents';
              Log('UserProfile ' + UsersPath + UserDirFindRec.Name);
              if DirExists(DocumentsPath) then
              begin
                UserTemplatesPath := DocumentsPath + '\CruiseFiles\Templates\';
                CopyFiles(TemplateSrcPath, '*.cut', UserTemplatesPath, CopyTemplateIfExists);
              end;       { end if force dir }

              { delete any desktop icons left behind in the user's desktop folder }
              { note we arn't deleting from the Public\Desktop where the All Users desktop icon is located }

              DesktopPath := UsersPath + UserDirFindRec.Name + '\Desktop\';
              if DirExists(DesktopPath) then
              begin
                if DeleteFile(DesktopPath + 'Cruise Manager.lnk') then begin
                  Log('File Deleted ' + DesktopPath + 'Cruise Manager.lnk');
                end else
                  Log('File Not Deleted ' + DesktopPath + 'Cruise Manager.lnk');
              end;       {end if desktop exists }
            end;         { end check user dir exists }     
          until not FindNext(UserDirFindRec);
        finally
          FindClose(UserDirFindRec);
        end;
      end else
      begin
        Log(Format('Error listing User dirs [%s]', [UsersPath]));
      end;
    end else {end is admin mode}
    begin
      CopyFiles(TemplateSrcPath, '*.cut', ExpandConstant('{userdocs}') + '\CruiseFiles\Templates\', CopyTemplateIfExists); 
    end;
    
  end; {end if is templates component selected }
end;


