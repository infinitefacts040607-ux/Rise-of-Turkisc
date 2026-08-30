# Rise of Turkics

European War 7 inspired turn-based strategy game for Android.

## Features
- 256×256 hex tactical map
- Turn-based gameplay with 4 factions
- Battle simulator
- Save/Load system
- AdMob + IAP integration
- Historical battles

## Quick Start

### Prerequisites
- Unity 2022.3 LTS
- Android SDK 21+
- Git

### Clone & Setup
```bash
git clone https://github.com/infinitefacts040607-ux/Rise-of-Turkisc.git
cd Rise-of-Turkisc
```

### Build APK
1. Open Unity 2022.3 LTS
2. File → Build Settings → Android
3. Player Settings:
   - Package Name: com.aox.game
   - Min API: 21
   - Target API: 34
   - Orientation: Landscape
4. Build → Build APK

### Test on Phone
- Transfer APK via USB
- Enable "Unknown Sources"
- Install and play

## Game Systems

### Core Mechanics
- **HexMap**: 256×256 axial coordinate grid
- **TurnManager**: Turn-based faction rotation
- **BattleResolver**: Combat simulation
- **SaveLoadManager**: JSON persistence

### Factions
- KazakhKhanate
- GoldenHorde
- Tang
- Sasanian

### Resources
- Livestock: Army maintenance
- Trade: Income generation
- Culture: Technology advancement
- Technology: Unit upgrades

### Units
- TurkicInfantry (Attack: 5, Defense: 3)
- HeavyCavalry (Attack: 8, Defense: 1)
- Archer (Attack: 3, Defense: 4)
- Siege (Attack: 12, Defense: 6)
- Dragoon (Attack: 4, Defense: 2)

### Terrain Effects
- Steppe: +20% attack bonus
- Mountain: +25% defense bonus
- Cavalry bonus in open terrain

## Monetization

### AdMob (Test IDs)
- App ID: ca-app-pub-3940256099942544~3347511713
- Banner: ca-app-pub-3940256099942544/6300978111
- Interstitial: ca-app-pub-3940256099942544/1033173712
- Rewarded: ca-app-pub-3940256099942544/5224354917

### IAP Products
- com.aox.game.remove_ads (Non-consumable)
- com.aox.game.premium_pass (Non-consumable)
- com.aox.game.gold_small ($0.99)
- com.aox.game.gold_medium ($2.99)
- com.aox.game.gold_large ($6.99)
- com.aox.game.subscription_monthly ($9.99)

## Privacy Policy
https://doc-hosting.flycricket.io/rise-of-turkics-privacy-policy/2fb0ec7a-f89e-4c3e-954c-cdadee0832cc/privacy

## Status
Beta - Playable prototype

## License
Proprietary

## Author
AOX Games
