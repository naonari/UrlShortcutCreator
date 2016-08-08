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
VersionInfoDescription=UrlShortcutCreator�Z�b�g�A�b�v�v���O����

OutputBaseFilename=UrlShortcutCreatorInstaller_x86
OutputDir="."
SetupIconFile="..\UrlShortcutCreator\UrlShortcutCreator.ico"

[Tasks]
Name: desktopicon; Description: "�f�X�N�g�b�v�ɃV���[�g�J�b�g�A�C�R�����쐬����";

[Files]
Source: "..\UrlShortcutCreator\bin\Release\UrlShortcutCreator.exe";  DestDir: "{app}"; Flags: ignoreversion
Source: "..\UrlShortcutCreator\bin\Release\NexFx.dll";               DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\UrlShortcutCreator"; Filename: "{app}\UrlShortcutCreator.exe"
Name: "{commondesktop}\UrlShortcutCreator"; Filename: "{app}\UrlShortcutCreator.exe"; WorkingDir: "{app}"; Tasks: desktopicon

[Languages]
Name: japanese; MessagesFile: compiler:Languages\Japanese.isl

[Run]
Filename: "{app}\UrlShortcutCreator.exe"; Description: "�A�v���P�[�V�������N������"; Flags: postinstall shellexec skipifsilent
