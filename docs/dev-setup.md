# Guide de développement

## Prérequis

### Android
- Android Studio Hedgehog ou plus récent
- JDK 17+
- Android SDK API 26+ (Android 8.0+)
- Kotlin 1.9+

### Windows Host
- Visual Studio 2022 ou .NET SDK 8.0+
- ViGEmBus installé (voir [Installation ViGEm](#installation-vigem))

## Installation ViGEm

1. Télécharger depuis [ViGEmBus Releases](https://github.com/ViGEm/ViGEmBus/releases)
2. Installer `ViGEmBus_Setup_x64.exe` (ou x86 selon votre système)
3. Redémarrer si nécessaire
4. Vérifier dans le Gestionnaire de périphériques : "ViGEm Bus Driver" doit apparaître

## Build Android

```bash
cd android
./gradlew assembleDebug
# APK généré dans app/build/outputs/apk/debug/
```

Pour un build release :
```bash
./gradlew assembleRelease
```

## Build Windows Host

```bash
cd host-windows/StarPanel.Host
dotnet build -c Release
# Exécutable dans bin/Release/net8.0/
```

Ou via Visual Studio :
1. Ouvrir `host-windows/StarPanel.Host/StarPanel.Host.sln`
2. Build > Build Solution (Ctrl+Shift+B)

## Exécution

### Host Windows
```bash
cd host-windows/StarPanel.Host
dotnet run
```

Le service démarre sur `ws://0.0.0.0:8765` par défaut.

### Android
1. Connecter un appareil Android ou lancer un émulateur
2. Dans Android Studio : Run > Run 'app'
3. L'app se connecte automatiquement au host sur le réseau local

## Configuration réseau

Par défaut :
- Port WebSocket : 8765
- Découverte mDNS : `_starpanel._tcp.local`
- Broadcast UDP : port 8766

Pour changer le port, modifier :
- Android : `android/app/src/main/java/.../config/NetworkConfig.kt`
- Host : `host-windows/StarPanel.Host/Program.cs`

## Debug

### Android
- Logcat dans Android Studio
- Filtre : `tag:StarPanel`

### Windows Host
- Console pour les logs
- Fichier de log : `logs/starpanel-host.log` (si activé)

## Tests

### Android
```bash
cd android
./gradlew test
```

### Windows Host
```bash
cd host-windows/StarPanel.Host
dotnet test
```

## Structure du projet

```
starpanel/
├── android/
│   ├── app/                    # Application principale
│   ├── core/                   # Modules partagés (network, data)
│   └── build.gradle.kts
├── host-windows/
│   └── StarPanel.Host/         # Service Windows
├── shared/
│   ├── schema/                 # JSON schemas
│   └── samples/                # Profils exemples
└── docs/                       # Documentation
```
