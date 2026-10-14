# Abaks: User's Guide



## Downloads & Runtimes

Download the latest release from the [Releases page](https://github.com/RemusRigo/Abaks-VB.NET/releases).

Each release contains one folder per framework and architecture:

|Folder|Target Framework|Architecture|Required Runtime|
|-|-|-|-|
|`net8.0 x64`|.NET 8.0|64-bit|[.NET 8.0 Desktop Runtime (x64)](https://dotnet.microsoft.com/download/dotnet/8.0)|
|`net8.0 x86`|.NET 8.0|32-bit|[.NET 8.0 Desktop Runtime (x86)](https://dotnet.microsoft.com/download/dotnet/8.0)|
|`net10.0 x64`|.NET 10.0|64-bit|[.NET 10.0 Desktop Runtime (x64)](https://dotnet.microsoft.com/download/dotnet/10.0)|
|`net10.0 x86`|.NET 10.0|32-bit|[.NET 10.0 Desktop Runtime (x86)](https://dotnet.microsoft.com/download/dotnet/10.0)|

> **Which one do I need?** On 64-bit Windows 10/11, use **x64**. Pick the .NET version whose
> **Desktop Runtime** you already have installed, or install one from the links above.
> The plain ".NET Runtime" is not enough; Abaks needs the **Desktop** Runtime.

To check which runtimes are installed, open a command prompt and run:

```
dotnet --list-runtimes
```

Look for a `Microsoft.WindowsDesktop.App 8.x` or `10.x` line.



## Install

Abaks is portable: there is no installer.

1. Download and extract the folder that matches your system (see the table above), e.g. `net8.0 x64`.
2. Copy the **whole folder** to a permanent location, for example `D:\My Apps\Abaks\`.
   The folder must contain all 4 files: `Abaks.exe`, `Abaks.dll`, `Abaks.deps.json`, `Abaks.runtimeconfig.json`.
3. Double-click `Abaks.exe`.

> If Windows blocks the file ("Windows protected your PC"), right-click `Abaks.exe` →
> **Properties** → check **Unblock** → **OK**, then try again.



## Usage

The upper box shows the operation in progress (e.g. `20-10`), the lower box shows the result.
Operations are applied in the order you type them: `2+3*4=` gives `20`.

|Button|Key|Description|
|-|-|-|
|**0** - **9**|0 - 9|Enter a digit|
|**+** **-** **x** **/**|`+` `-` `*` `/`|Apply the pending operation and start a new one|
|**=**|Enter|Show the result|
|**⌫**|Backspace|Delete the last digit|
|**CE**|Delete|Clear the current number|
|**C**|Esc|Clear everything|
|**±**| |Change the sign of the current number|

> Decimal numbers are not supported yet: the **.** and **%** buttons do nothing.

Right-click the title bar → **About...** for version information.



## Uninstall

Delete the folder you copied in step 2 of *Install*. Abaks doesn't write any settings.
