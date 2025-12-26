# StarPanel Host (Windows)

Service Windows qui reçoit les commandes de l'app Android et les convertit en actions (joystick virtuel, clavier).

## Prérequis

- Windows 10/11
- .NET 8.0 Runtime
- ViGEmBus installé

## Installation

1. Installer ViGEmBus depuis [GitHub Releases](https://github.com/ViGEm/ViGEmBus/releases)
2. Exécuter `StarPanel.Host.exe`
3. Noter le code de pairing affiché dans la console

## Utilisation

Le service démarre automatiquement un serveur WebSocket sur le port 8765.

- Code de pairing : affiché dans la console au démarrage
- Connexions : affichées dans la console
- Quitter : appuyer sur 'q' dans la console

## Build

```bash
dotnet build -c Release
```

L'exécutable se trouve dans `bin/Release/net8.0/win-x64/StarPanel.Host.exe`
