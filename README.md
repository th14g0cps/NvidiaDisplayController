
# NVIDIA Display Controller

This is only for NVIDIA GPU's. Allows you to change display settings and easily switch between different profiles without having to manually adjust settings each time. Applies to the monitor and not a specific program.

> **Fork mantido por [@th14g0cps](https://github.com/th14g0cps)** com as seguintes melhorias sobre o projeto original.

## Changelog

### Migração para .NET 10
- Target framework atualizado de `net7.0-windows` para `net10.0-windows` em todos os projetos da solução.
- Removidas referências hardcoded a DLLs e caminhos do .NET 7.
- Pacote `System.Drawing.Common` removido (embutido no runtime do Windows Desktop .NET 10+).

### Process Rules — Automação por Processo
Nova funcionalidade que monitora processos em execução e aplica perfis de cor automaticamente:

- Crie regras associando um executável (ex: `cs2.exe`) a um monitor e a um perfil específico.
- Quando o processo for detectado em execução, o perfil é aplicado automaticamente.
- Quando o processo encerrar, todos os monitores retornam ao perfil **Default**.
- Regras são persistidas em `Data\Data.json` junto com os demais dados.
- O monitoramento ocorre em background com polling a cada 2 segundos, sem impacto perceptível de performance.

**Como usar:**
1. Na janela principal, localize a seção **Process Rules** na parte inferior.
2. Preencha o nome do executável (com ou sem `.exe`), selecione o monitor e o perfil desejado.
3. Clique em **Adicionar**.
4. Para remover uma regra, clique em **Remover** na linha correspondente da lista.




## Features

- Adjust the brightness, contrast, gamma, and digital vibrance settings to your preference.
- Automatically detects all displays connected to the computer and creates a base default profile for each.
- Configure settings for up to five profiles for each monitor to easily switch between different configurations.
- Set a profile as the default so no need to select each time. Optionally, set the default profiles to apply to all monitors on start across all displays.
- Minimizes to system tray to avoid clutter on taskbar. Right click icon to open/close application once minimized.
- View selected profiles when hoving mouse over icon in taskbar.
- Extremely lightweight with low resource use (under 100 MB)


## Requirements

- NVIDIA GPU (with installed drivers)
- Windows (tested with 10/11)


## How to Use

Run the executable and select a monitor from the collection at the top. To create a profile hit the green plus symbol in the Profile section. From there you name the Profile and proceed to set the settings in the Detail section. 

Settings will not be applied until the 'Apply' button is pressed at the bottom. To update the settings of a profile WITHOUT applying them to the monitor click the 'Update' button. To revert changes made before applying hit the 'Revert' button.

All the data is stored where the executable resides (\InstallLocation\Data\Data.json). If you need to reset the data, there is a help button at the top where you can do that.



## Screenshot

![App Screenshot](https://github.com/therealmariolaurianti/NvidiaDisplayController/assets/25336894/8be460e9-f572-498b-99fe-89fe6a8a722d/468x300?text=App+Screenshot+Here)

![App Screenshot](https://github.com/therealmariolaurianti/NvidiaDisplayController/assets/25336894/cc1304d0-23fb-452f-8c91-10f87f412800/468x300?text=App+Screenshot+Here)


