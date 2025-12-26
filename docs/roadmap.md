# Roadmap StarPanel

## Phase 0 - Cadrage ✅
- [x] Définir l'architecture
- [x] Créer la structure du monorepo
- [x] Définir le protocole de communication
- [x] Créer le format de profil JSON

## Phase 1 - Socle technique (En cours)

### Windows Host
- [x] Structure de base .NET
- [x] Serveur WebSocket (Fleck)
- [x] Service ViGEm (joystick virtuel)
- [x] Service clavier (SendInput)
- [ ] Découverte réseau (mDNS/UDP)
- [ ] Pairing sécurisé avec session token
- [ ] Gestion des profils côté host

### Android App
- [x] Structure de base Kotlin + Compose
- [x] Navigation de base
- [x] Écrans de connexion et runtime
- [ ] Client WebSocket
- [ ] Découverte réseau (mDNS/UDP)
- [ ] Pairing avec code/QR
- [ ] Stockage local (Room)

## Phase 2 - UI Runtime

### Widgets de base
- [ ] Boutons (tap, hold, toggle)
- [ ] Sliders (avec courbes)
- [ ] Toggles
- [ ] Layout en grille
- [ ] Feedback visuel (états)

### Communication
- [ ] Envoi d'événements (boutons, axes)
- [ ] Réception d'états (toggles, axes)
- [ ] Gestion de la latence
- [ ] Reconnexion automatique

## Phase 3 - Éditeur

### Édition de base
- [ ] Créer/modifier des pages
- [ ] Ajouter/supprimer des widgets
- [ ] Drag & drop des widgets
- [ ] Propriétés des widgets

### Mapping
- [ ] Assigner des actions (clavier, ViGEm)
- [ ] Créer des macros simples
- [ ] Tester les actions

### Import/Export
- [ ] Exporter un profil JSON
- [ ] Importer un profil JSON
- [ ] Validation du schéma

## Phase 4 - Fonctionnalités avancées

### Radial Menu
- [ ] Menu radial (4/6/8/12 segments)
- [ ] Press-and-drag
- [ ] Actions par segment

### Macros
- [ ] Éditeur de macros
- [ ] Séquences temporisées
- [ ] Conditions simples
- [ ] Annulation de macro

### Profils
- [ ] Profils pré-configurés (Vol, Combat, Mining, FPS, EVA)
- [ ] Changement de profil
- [ ] Pages multiples par profil

## Phase 5 - Polish & Open Source

### Documentation
- [x] README principal
- [x] Guide de développement
- [x] Guide utilisateur
- [x] Documentation du protocole
- [ ] Guide de contribution
- [ ] Vidéos de démonstration

### Distribution
- [ ] Build automatique (GitHub Actions)
- [ ] Releases (APK + installer host)
- [ ] Installation facile du host
- [ ] Détection automatique de ViGEm

### Communauté
- [ ] Marketplace de profils
- [ ] Partage de profils
- [ ] Système de plugins (phase 2)

## V2 - Fonctionnalités futures

- [ ] Télémétrie depuis Star Citizen (si API disponible)
- [ ] Feedback haptique avancé
- [ ] Thèmes personnalisables
- [ ] Multi-appareils (plusieurs Android → 1 PC)
- [ ] Support d'autres jeux (Elite Dangerous, etc.)
- [ ] Plugin system côté host
