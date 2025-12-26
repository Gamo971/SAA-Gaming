# Guide utilisateur

## Installation

### Windows Host

1. **Installer ViGEmBus**
   - Télécharger depuis [ViGEmBus Releases](https://github.com/ViGEm/ViGEmBus/releases)
   - Exécuter `ViGEmBus_Setup_x64.exe`
   - Redémarrer si demandé

2. **Installer StarPanel Host**
   - Télécharger `StarPanel.Host.Setup.exe` depuis les releases
   - Exécuter l'installer
   - Le service démarre automatiquement

3. **Vérifier l'installation**
   - Une icône apparaît dans la barre des tâches
   - Cliquer pour voir le code de pairing et l'état

### Android App

1. **Activer les sources inconnues** (si nécessaire)
   - Paramètres > Sécurité > Sources inconnues

2. **Installer l'APK**
   - Télécharger `starpanel-v1.0.apk`
   - Ouvrir le fichier pour installer

## Première connexion

1. **Lancer l'app Android**
   - L'app recherche automatiquement le PC sur le réseau

2. **Saisir le code de pairing**
   - Le code s'affiche sur le PC (ex: `123456`)
   - Saisir dans l'app Android
   - Ou scanner le QR code affiché sur le PC

3. **Connexion établie**
   - L'indicateur de connexion devient vert
   - La latence s'affiche (typiquement 10-50ms)

## Utilisation de base

### Changer de page
- **Swipe** gauche/droite pour changer de page
- Ou utiliser le bouton de navigation en haut

### Utiliser les widgets

**Boutons**
- **Tap** : appuyer rapidement
- **Hold** : maintenir appuyé
- **Toggle** : basculer on/off

**Sliders**
- **Glisser** pour ajuster la valeur
- **Double-tap** pour réinitialiser (si configuré)

**Menu radial**
- **Appuyer et glisser** vers un segment
- **Relâcher** pour activer

## Profils

### Charger un profil

1. Ouvrir le menu (☰)
2. Sélectionner "Profils"
3. Choisir un profil (Vol, Combat, Mining, etc.)
4. Le profil se charge automatiquement

### Créer un profil

1. Menu > Éditeur
2. Créer une nouvelle page
3. Ajouter des widgets (boutons, sliders, etc.)
4. Assigner des actions à chaque widget
5. Sauvegarder

### Importer/Exporter

**Exporter**
1. Menu > Profils
2. Sélectionner un profil
3. Menu (⋮) > Exporter
4. Le fichier JSON est sauvegardé

**Importer**
1. Menu > Profils
2. Menu (⋮) > Importer
3. Sélectionner un fichier JSON
4. Le profil est ajouté à la liste

## Dépannage

### L'app ne trouve pas le PC

- Vérifier que le PC et l'appareil Android sont sur le même réseau Wi-Fi
- Vérifier que le firewall Windows n'bloque pas le port 8765
- Essayer de saisir l'IP manuellement (Menu > Paramètres > IP manuelle)

### La connexion se coupe

- Vérifier la stabilité du Wi-Fi
- Vérifier que le host est toujours en cours d'exécution
- L'app se reconnecte automatiquement en 2-3 secondes

### Les commandes ne fonctionnent pas

- Vérifier que le jeu est au focus (fenêtre active)
- Vérifier que ViGEmBus est bien installé
- Vérifier les logs dans l'app (Menu > Paramètres > Logs)

### Latence élevée

- Vérifier la qualité du signal Wi-Fi
- Éviter les réseaux surchargés
- Utiliser la bande 5 GHz si disponible

## Support

- **Issues** : [GitHub Issues](https://github.com/SAA-Gaming/issues)
- **Discord** : [Lien Discord](https://discord.gg/saa-gaming)
- **Wiki** : [Documentation complète](https://github.com/SAA-Gaming/wiki)
