; ============================
; Inno Setup Script - Gestao Mercadinho (net9.0-windows)
; ============================

#define AppName        "Gestão Mercadinho"
#define AppPublisher   "Seu Nome ou Empresa"
#define AppExeName     "Gestao Mercadinho.exe"
#define BuildDir       "C:\Users\Luis Henrique\OneDrive\Documentos\Visual Studio 2022\Templates\Codigo C#\Mercadinho\Gestao Mercadinho\bin\Release\net9.0-windows"
#define AppVersion     "1.0.0"

[Setup]
AppId={{B9E2F6A7-8E4A-4B7E-9D20-8F6C7B1D9C01}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
; Se preferir, gere o instalador em uma subpasta:
; OutputDir={#BuildDir}\installer
OutputDir={#BuildDir}
OutputBaseFilename=Setup_{#AppName}
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64
UninstallDisplayIcon={app}\{#AppExeName}
WizardStyle=modern
SetupLogging=yes

[Languages]
Name: "portuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "Criar atalho na Área de Trabalho"; GroupDescription: "Atalhos:"; Flags: unchecked
Name: "runapp"; Description: "Executar {#AppName} após concluir a instalação"; GroupDescription: "Finalização:"; Flags: unchecked

[Files]
; Executável
Source: "{#BuildDir}\{#AppExeName}"; DestDir: "{app}"; Flags: ignoreversion

; Todas as DLLs do publish
Source: "{#BuildDir}\*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; JSONs (inclui .deps.json e .runtimeconfig.json)
Source: "{#BuildDir}\*.json"; DestDir: "{app}"; Flags: ignoreversion

; Configs são opcionais – não falhar se não existirem
Source: "{#BuildDir}\*.config"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

; Subpasta runtimes é opcional em alguns publishes
Source: "{#BuildDir}\runtimes\*"; DestDir: "{app}\runtimes"; Flags: ignoreversion recursesubdirs createallsubdirs skipifsourcedoesntexist

; Copiar a pasta Config do projeto
Source: "C:\Users\Luis Henrique\OneDrive\Documentos\Visual Studio 2022\Templates\Codigo C#\Mercadinho\Gestao Mercadinho\Config\*"; \
    DestDir: "{app}\Config"; \
    Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Executar {#AppName} agora"; Flags: nowait postinstall skipifsilent; Tasks: runapp

[Code]
function DotNetDesktop90Installed: Boolean;
var ver: string;
begin
  Result := RegQueryStringValue(HKLM64,
    'SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedfx\Microsoft.WindowsDesktop.App',
    'Version', ver);
  if Result then Result := (Copy(ver, 1, 2) = '9.');
end;

procedure InitializeWizard;
begin
  if not DotNetDesktop90Installed then
  begin
    MsgBox(
      'Este aplicativo requer o .NET Desktop Runtime 9.0 (Microsoft.WindowsDesktop.App x64).'#13#10#13#10 +
      'Instale o runtime e execute novamente o instalador.',
      mbError, MB_OK);
    WizardForm.Close;
  end;
end;
 
