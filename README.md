# StarPanel

Une application Android qui transforme ton appareil en panneau de contrôle multi-pages pour piloter Star Citizen (et d'autres jeux), en envoyant des commandes à un agent Windows qui les convertit en joystick virtuel et actions clavier.

## 🎮 Vision

**"Je lance le panel, ça se connecte, je joue."**

StarPanel permet de créer des interfaces personnalisées avec boutons, sliders, toggles et menus radiaux pour contrôler ton jeu via un appareil Android, sans configuration complexe.

## ✨ Fonctionnalités

### MVP
- ✅ Connexion automatique au PC via réseau local
- ✅ Pairing sécurisé (code 6 chiffres ou QR code)
- ✅ Pages multiples avec widgets (boutons, sliders)
- ✅ Mapping vers joystick virtuel (ViGEm) et clavier
- ✅ Profils pré-configurés (Vol, Combat, Mining, FPS, EVA)

### V1
- 🔄 Toggles, hold, double-tap
- 🔄 Menu radial (4/6/8/12 segments)
- 🔄 Macros temporisées
- 🔄 Import/export de profils JSON
- 🔄 Thèmes et personnalisation UI

### V2
- 📋 Bibliothèque de profils communautaires
- 📋 Feedback avancé et télémétrie
- 📋 Système de plugins

## 🏗️ Architecture

```
starpanel/
├── android/          # Application Android (Kotlin + Compose)
├── host-windows/     # Service Windows (.NET C#)
├── shared/           # Schémas et exemples partagés
└── docs/             # Documentation
```

## 🚀 Démarrage rapide

### Windows Host

1. Installer [ViGEmBus](https://github.com/ViGEm/ViGEmBus/releases)
2. Exécuter `host-windows/StarPanel.Host/StarPanel.Host.exe`
3. Le service écoute sur le port 8765

### Android App

1. Installer l'APK depuis les releases
2. Lancer l'app
3. L'app détecte automatiquement le PC sur le réseau
4. Saisir le code de pairing affiché sur le PC
5. Commencer à jouer !

## 📚 Documentation

- [Guide d'installation](docs/dev-setup.md)
- [Format des profils](docs/profile-format.md)
- [Protocole de communication](docs/protocol.md)
- [Guide utilisateur](docs/user-guide.md)

## 🛠️ Développement

Voir [docs/dev-setup.md](docs/dev-setup.md) pour les instructions de build.

## 📄 Licence

MIT License - Voir [LICENSE](LICENSE)

## 🤝 Contribution

Les contributions sont les bienvenues ! Voir les [issues](https://github.com/SAA-Gaming/issues) pour les tâches en cours.

Voir [CONTRIBUTING.md](CONTRIBUTING.md) pour le guide de contribution.

## 🔗 Liens

- **Repository** : [GitHub - SAA-Gaming](https://github.com/SAA-Gaming)
- **Issues** : [GitHub Issues](https://github.com/SAA-Gaming/issues)

---

**Note de sécurité** : StarPanel utilise uniquement des APIs Windows standard (SendInput, ViGEm) et ne modifie pas la mémoire du jeu. Compatible avec les systèmes anti-cheat standards.
