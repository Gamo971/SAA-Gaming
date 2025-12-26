# Format des profils

Un profil StarPanel est un fichier JSON qui définit les pages, widgets et actions.

## Structure générale

```json
{
  "version": "1.0",
  "profileId": "profile_vol_starter",
  "name": "Vol - Starter",
  "description": "Profil de base pour le vol",
  "author": "StarPanel Community",
  "pages": [...],
  "macros": [...]
}
```

## Pages

Une page contient un layout et des widgets.

```json
{
  "pageId": "page_vol_1",
  "name": "Vol 1",
  "layout": {
    "columns": 4,
    "rows": 6,
    "widgets": [...]
  }
}
```

## Widgets

### Bouton

```json
{
  "widgetId": "btn_throttle",
  "type": "button",
  "position": {
    "column": 0,
    "row": 0,
    "columnSpan": 2,
    "rowSpan": 1
  },
  "style": {
    "label": "Throttle",
    "backgroundColor": "#2196F3",
    "textColor": "#FFFFFF",
    "icon": "ic_throttle"
  },
  "behavior": "tap",  // "tap", "hold", "toggle", "doubleTap", "repeat"
  "actions": {
    "onTap": [
      {
        "type": "keyboard",
        "key": "W",
        "action": "tap"
      }
    ],
    "onHold": [
      {
        "type": "vigem_button",
        "button": 0,
        "action": "press"
      }
    ],
    "onRelease": [
      {
        "type": "vigem_button",
        "button": 0,
        "action": "release"
      }
    ]
  }
}
```

### Slider

```json
{
  "widgetId": "slider_throttle",
  "type": "slider",
  "position": {
    "column": 0,
    "row": 1,
    "columnSpan": 4,
    "rowSpan": 1
  },
  "style": {
    "label": "Throttle",
    "color": "#4CAF50",
    "showValue": true
  },
  "config": {
    "min": 0.0,
    "max": 1.0,
    "default": 0.0,
    "curve": "linear",  // "linear", "exponential"
    "centerMode": false,  // true pour -1..+1
    "snapPoints": [0.0, 0.5, 1.0],  // optionnel
    "fineControl": false  // mode précision avec modificateur
  },
  "actions": {
    "onChange": [
      {
        "type": "vigem_axis",
        "axis": "left_trigger",  // "left_trigger", "right_trigger", "left_stick_x", etc.
        "value": "$value"  // variable remplacée par la valeur actuelle
      }
    ]
  }
}
```

### Toggle

```json
{
  "widgetId": "toggle_vtol",
  "type": "toggle",
  "position": {
    "column": 2,
    "row": 0,
    "columnSpan": 1,
    "rowSpan": 1
  },
  "style": {
    "label": "VTOL",
    "onColor": "#4CAF50",
    "offColor": "#757575",
    "icon": "ic_vtol"
  },
  "actions": {
    "onToggleOn": [
      {
        "type": "keyboard",
        "key": "K",
        "action": "tap"
      }
    ],
    "onToggleOff": [
      {
        "type": "keyboard",
        "key": "K",
        "action": "tap"
      }
    ]
  }
}
```

### Radial Menu

```json
{
  "widgetId": "radial_weapons",
  "type": "radial",
  "position": {
    "column": 0,
    "row": 2,
    "columnSpan": 2,
    "rowSpan": 2
  },
  "style": {
    "label": "Armes",
    "segments": 8,
    "colors": ["#F44336", "#E91E63", "#9C27B0", "#673AB7", "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4"]
  },
  "segments": [
    {
      "segmentId": 0,
      "label": "Laser",
      "action": {
        "type": "keyboard",
        "key": "1",
        "action": "tap"
      }
    },
    {
      "segmentId": 1,
      "label": "Missile",
      "action": {
        "type": "keyboard",
        "key": "2",
        "action": "tap"
      }
    }
    // ... autres segments
  ]
}
```

## Actions

### Keyboard

```json
{
  "type": "keyboard",
  "key": "W",  // Code clavier ou nom (W, A, S, D, Space, Enter, etc.)
  "action": "tap"  // "tap", "down", "up"
}
```

### ViGEm Button

```json
{
  "type": "vigem_button",
  "button": 0,  // 0-15 (Xbox 360 controller)
  "action": "press"  // "press", "release", "toggle"
}
```

### ViGEm Axis

```json
{
  "type": "vigem_axis",
  "axis": "left_trigger",  // "left_trigger", "right_trigger", "left_stick_x", "left_stick_y", "right_stick_x", "right_stick_y"
  "value": 0.75  // -1.0 à +1.0, ou "$value" pour utiliser la valeur du widget
}
```

### Macro

```json
{
  "type": "macro",
  "macroId": "macro_landing_sequence"
}
```

### Page Switch

```json
{
  "type": "page_switch",
  "pageId": "page_vol_2"
}
```

## Macros

Une macro est une séquence d'actions temporisées.

```json
{
  "macroId": "macro_landing_sequence",
  "name": "Séquence d'atterrissage",
  "steps": [
    {
      "action": "keyboard",
      "key": "N",
      "action": "down",
      "delay": 0
    },
    {
      "action": "delay",
      "ms": 100
    },
    {
      "action": "keyboard",
      "key": "N",
      "action": "up",
      "delay": 0
    },
    {
      "action": "vigem_button",
      "button": 0,
      "action": "press",
      "delay": 200
    },
    {
      "action": "vigem_button",
      "button": 0,
      "action": "release",
      "delay": 0
    }
  ],
  "mode": "oneshot"  // "oneshot" ou "maintain"
}
```

## Exemple complet

Voir `shared/samples/star-citizen-vol-starter.json` pour un profil complet.

## Validation

Le format suit un JSON Schema (voir `shared/schema/profile.schema.json`).

## Versioning

- Version actuelle : `1.0`
- Les versions futures maintiendront la rétrocompatibilité quand possible
- Les champs optionnels peuvent être ajoutés sans changer la version majeure
