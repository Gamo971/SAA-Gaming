# Protocole de communication

StarPanel utilise WebSocket (JSON) pour la communication entre l'app Android et le host Windows.

## Connexion

- **URL** : `ws://<host-ip>:8765/starpanel`
- **Protocole** : WebSocket standard
- **Format** : JSON UTF-8

## Messages Client → Host

### HELLO
Premier message envoyé par le client.

```json
{
  "type": "HELLO",
  "appVersion": "1.0.0",
  "deviceName": "Galaxy S21"
}
```

### PAIR_REQUEST
Demande de pairing avec un code.

```json
{
  "type": "PAIR_REQUEST",
  "code": "123456"
}
```

### EVENT_BUTTON
Événement de bouton.

```json
{
  "type": "EVENT_BUTTON",
  "controlId": "btn_throttle",
  "action": "down",  // "down", "up", "tap"
  "timestamp": 1234567890
}
```

### EVENT_AXIS
Événement d'axe (slider).

```json
{
  "type": "EVENT_AXIS",
  "controlId": "slider_throttle",
  "value": 0.75,  // -1.0 à +1.0
  "timestamp": 1234567890
}
```

### RUN_MACRO
Exécuter une macro.

```json
{
  "type": "RUN_MACRO",
  "macroId": "macro_landing_sequence",
  "mode": "oneshot"  // "oneshot" ou "maintain"
}
```

### SWITCH_PAGE
Changer de page.

```json
{
  "type": "SWITCH_PAGE",
  "pageId": "page_vol_2"
}
```

### CANCEL_MACRO
Annuler une macro en cours.

```json
{
  "type": "CANCEL_MACRO",
  "macroId": "macro_landing_sequence"
}
```

## Messages Host → Client

### PAIR_OK
Pairing réussi.

```json
{
  "type": "PAIR_OK",
  "sessionToken": "abc123...",
  "hostName": "PC-GAMING"
}
```

### PAIR_ERROR
Erreur de pairing.

```json
{
  "type": "PAIR_ERROR",
  "reason": "INVALID_CODE"
}
```

### STATE_UPDATE
Mise à jour de l'état (toggles, axes, page active).

```json
{
  "type": "STATE_UPDATE",
  "toggles": {
    "toggle_vtol": true,
    "toggle_landing_gear": false
  },
  "axes": {
    "slider_throttle": 0.75
  },
  "activePage": "page_vol_1"
}
```

### ACK
Accusé de réception d'un événement.

```json
{
  "type": "ACK",
  "eventId": "evt_1234567890",
  "timestamp": 1234567890
}
```

### PING
Ping pour mesurer la latence.

```json
{
  "type": "PING",
  "timestamp": 1234567890
}
```

### PONG
Réponse au ping.

```json
{
  "type": "PONG",
  "timestamp": 1234567890,
  "serverTime": 1234567891
}
```

### ERROR
Erreur générique.

```json
{
  "type": "ERROR",
  "code": "INVALID_CONTROL",
  "message": "Control ID not found"
}
```

## Sécurité

### Pairing
1. Le host génère un code à 6 chiffres aléatoire
2. Le client envoie `PAIR_REQUEST` avec le code
3. Le host valide et renvoie un `sessionToken`
4. Tous les messages suivants doivent inclure le `sessionToken` dans l'en-tête

### Session Token
Inclus dans chaque message après pairing :

```json
{
  "type": "EVENT_BUTTON",
  "sessionToken": "abc123...",
  "controlId": "btn_throttle",
  "action": "down"
}
```

Le host rejette les messages sans token valide.

## Découverte réseau

### mDNS
Le host s'annonce via mDNS :
- Service : `_starpanel._tcp.local`
- Nom : `StarPanel-<hostname>`
- Port : 8765

### UDP Broadcast
Alternative si mDNS ne fonctionne pas :
- Port : 8766
- Message : `STARPANEL_DISCOVERY`
- Réponse : `STARPANEL_RESPONSE|<ip>|<port>|<code>`

## Latence

- Les événements incluent un `timestamp` (millisecondes depuis epoch)
- Le host calcule la latence via PING/PONG
- Latence typique : 10-50ms sur Wi-Fi local

## Rate limiting

- Sliders : max 60 événements/seconde
- Boutons : pas de limite (mais throttling côté host)
- Macros : une seule macro à la fois par défaut
