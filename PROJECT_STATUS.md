# État du projet StarPanel

## ✅ Structure créée

### Documentation
- ✅ README principal avec vision produit
- ✅ Guide de développement (dev-setup.md)
- ✅ Guide utilisateur (user-guide.md)
- ✅ Documentation du protocole (protocol.md)
- ✅ Format des profils (profile-format.md)
- ✅ Roadmap (roadmap.md)
- ✅ Guide de contribution (CONTRIBUTING.md)
- ✅ Changelog (CHANGELOG.md)

### Schémas et exemples
- ✅ JSON Schema pour les profils (shared/schema/profile.schema.json)
- ✅ Exemple de profil Star Citizen (shared/samples/star-citizen-vol-starter.json)

### Application Android
- ✅ Structure Gradle (settings.gradle.kts, build.gradle.kts)
- ✅ Application de base (MainActivity, StarPanelApplication)
- ✅ Thème Material 3 (Theme.kt, Color.kt, Type.kt)
- ✅ Navigation de base (StarPanelApp.kt)
- ✅ Écran de connexion (ConnectionScreen.kt)
- ✅ Écran runtime (RuntimeScreen.kt)
- ✅ Composants UI (ConnectionStatus.kt)
- ✅ Configuration réseau (NetworkConfig.kt)
- ✅ Manifest et ressources de base

### Windows Host
- ✅ Projet .NET 8.0 (StarPanel.Host.csproj)
- ✅ Point d'entrée (Program.cs)
- ✅ Service ViGEm (ViGEmService.cs)
- ✅ Service clavier (KeyboardService.cs)
- ✅ Serveur WebSocket (StarPanelWebSocketServer.cs)
- ✅ Modèles de messages (Messages.cs)
- ✅ README du host

### Configuration
- ✅ .gitignore
- ✅ LICENSE (MIT)
- ✅ Structure de monorepo

## 🚧 À implémenter (prochaines étapes)

### Priorité 1 - Communication
1. **Client WebSocket Android**
   - Implémenter le client WebSocket avec OkHttp
   - Gérer la connexion/déconnexion
   - Envoyer les événements (boutons, axes)
   - Recevoir les états (toggles, axes)

2. **Découverte réseau**
   - mDNS côté Android (jmdns)
   - UDP broadcast (alternative)
   - Affichage des PCs disponibles

3. **Pairing sécurisé**
   - Génération de code côté host
   - Validation côté host
   - Stockage du sessionToken
   - QR code (optionnel)

### Priorité 2 - Widgets de base
1. **Boutons**
   - Widget bouton avec comportements (tap, hold, toggle)
   - Actions (clavier, ViGEm)
   - Feedback visuel

2. **Sliders**
   - Widget slider avec courbes
   - Rate limiting (60 Hz)
   - Actions ViGEm axis

3. **Layout**
   - Grille de widgets
   - Positionnement (column, row, span)
   - Responsive

### Priorité 3 - Profils
1. **Stockage local**
   - Room database
   - Entités Profile, Page, Widget
   - DAO et Repository

2. **Chargement de profils**
   - Parser JSON → modèles Kotlin
   - Charger un profil
   - Afficher les widgets

3. **Import/Export**
   - Exporter un profil en JSON
   - Importer un profil depuis JSON
   - Validation avec schéma

### Priorité 4 - Mapping côté host
1. **Mapping des actions**
   - Charger un profil côté host
   - Mapper controlId → actions
   - Exécuter les actions (ViGEm, clavier)

2. **Macros**
   - Parser les macros JSON
   - Exécuter les séquences
   - Gérer les delays
   - Annulation

## 📝 Notes techniques

### Dépendances à vérifier
- **Android** : OkHttp WebSocket, jmdns, Room, Hilt, Moshi
- **Windows** : Fleck, ViGEmClient, Newtonsoft.Json

### Points d'attention
- ViGEmBus doit être installé avant de lancer le host
- Le firewall Windows peut bloquer le port 8765
- La latence Wi-Fi doit être < 100ms pour une bonne expérience
- Les événements doivent être horodatés pour la synchronisation

### Tests à prévoir
- Test de connexion WebSocket
- Test de pairing
- Test d'envoi d'événements
- Test de mapping ViGEm
- Test de macros

## 🎯 Objectif MVP

Un MVP fonctionnel doit permettre :
1. ✅ Connexion Android → Windows Host
2. ⏳ Pairing avec code
3. ⏳ Affichage d'une page avec widgets
4. ⏳ Envoi d'événements bouton → action clavier/ViGEm
5. ⏳ Envoi d'événements slider → axe ViGEm
6. ⏳ Chargement d'un profil depuis JSON

Une fois ces points validés, le projet sera utilisable pour Star Citizen !
