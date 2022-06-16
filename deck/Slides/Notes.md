# System.CommandLine Demystified

## What is a CLI?
- Short for Command Line Interface
- API inside the shell
- Anatomy of a CLI:
  - Root command - main executable
  - Sub-commands (verbs) - can also have child commands
  - Options - named parameter
  - Arguments - value passed to command or option

---

## What is System.CommandLine?
- Library for building CLI apps without the overhead of parsing arguments or rendering help docs.
- Separates app logic from input parsing.
- Trim friendly - fast, lightweight AOT app.
- Consistent input parsing according to POSIX or Windows.
- Used by .NET CLI, .NET tooling and other global tools.
- Built-in support for tab-completion and response files.

---

## Getting started

- Any code editor e.g. VSCode with C# extension
- .NET 6 SDK

or
- Visual Studio 2022 with .NET desktop development workload installed

---

## Demo 1: A Basic CLI app

---

## The command-line syntax

### Tokens
Command-line input is parsed into tokens - strings delimted by spaces.

```
dotnet new console --framework net6.0 
       ^----------------------------^
```
- `new` - Command token
- `console` - Command token
- `--framework` - Option token
- `net6.0` - Option argument token

### Commands

```
dotnet tool install dotnet-suggest --global --verbosity quiet
       ^----------^
```

- Root command - `dotnet`
- Sub-commands - `tool` and `install`

### Options

```
dotnet tool update dotnet-suggest --verbosity quiet --global
                                  ^---------^       ^------^
```

- `--verbosity` - Value parameter with value "quiet"
- `--global` - Switch parameter as boolean. Defaults to `true` if specified.
- Can be denoted wit prefixes `--` or `/` (some Windows apps)

### Arguments
Arguments provide value parameters to options or commands.
```
dotnet tool update dotnet-suggest --verbosity quiet --global
                                              ^---^
```
```
dotnet build myapp.csproj
             ^----------^
```