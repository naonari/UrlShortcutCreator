; -- UrlShortcutCreatorInstaller.iss --
[Setup]
AppName=UrlShortcutCreator
AppId=Growup_Consultant/Software/UrlShortcutCreator
AppPublisher=Growup Consultant
AppCopyright=Growup Consultant
AppVerName=UrlShortcutCreator 1.0.0.0
AppVersion=1.0.0.0
ArchitecturesAllowed=x86 x64
DefaultDirName={pf}\UrlShortcutCreator
DefaultGroupName=UrlShortcutCreator
UninstallDisplayIcon={app}\UrlShortcutCreator.exe
ShowLanguageDialog=no
VersionInfoVersion=1.0.0.0
VersionInfoDescription=UrlShortcutCreatorセットアッププログラム

OutputBaseFilename=UrlShortcutCreatorInstaller_x86
OutputDir="."
SetupIconFile="..\UrlShortcutCreator\UrlShortcutCreator.ico"

[Tasks]
Name: desktopicon; Description: "デスクトップにショートカットアイコンを作成する";

[Files]
Source: "..\UrlShortcutCreator\bin\Release\UrlShortcutCreator.exe";  DestDir: "{app}"; Flags: ignoreversion
Source: "..\UrlShortcutCreator\bin\Release\NexFx.dll";               DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\UrlShortcutCreator"; Filename: "{app}\UrlShortcutCreator.exe"
Name: "{commondesktop}\UrlShortcutCreator"; Filename: "{app}\UrlShortcutCreator.exe"; WorkingDir: "{app}"; Tasks: desktopicon

[Languages]
Name: japanese; MessagesFile: compiler:Languages\Japanese.isl

[Run]
Filename: "{app}\UrlShortcutCreator.exe"; Description: "アプリケーションを起動する"; Flags: postinstall shellexec skipifsilent
