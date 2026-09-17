# Roguelike

A 2D turn-based roguelike dungeon crawler built in Unity and C#, based on Unity's official **2D Roguelike** tutorial with personal modifications on top of the base project.

### Architecture
<img width="1000" height="1000" alt="diagram" src="https://github.com/user-attachments/assets/a5de005e-5e7e-48ba-bb2d-5d800b2732c2" />

<!-- Add a screenshot or GIF of gameplay here once you have one -->
<!-- ![Gameplay screenshot](docs/screenshot.png) -->
### Gameplay
<img width="848" height="825" alt="gameplay" src="https://github.com/user-attachments/assets/93ac8678-06cf-4c27-86d0-d809524c4016" />


## About

This project started from Unity's 2D Roguelike tutorial and was extended/customized as a learning project. Core gameplay revolves around procedurally arranged dungeon boards, turn-based movement, and collecting food/items while avoiding or dealing with obstacles.

I'm currently working on the challenge from the Unity 2D tutorial: updating the wall's tile as it takes damage from the player, so the player can visually tell when a wall is about to break.

## Features

- Turn-based movement and game loop (`TurnManager`)
- Procedurally arranged dungeon board (`BoardManager`)
- Player movement and interaction (`PlayerController`)
- Collectible/food objects (`FoodObject`)
- Wall/obstacle objects (`WallObject`)
- Central game state management (`GameManager`)
- Built with Unity's Universal Render Pipeline (URP) for 2D lighting
- Uses Unity's new Input System package

## Project Structure

```
Assets/
├── Prefabs/          # Reusable game object prefabs (Wall, Beef, etc.)
├── Scenes/           # Main.unity — primary game scene
├── Scripts/          # Core C# gameplay scripts
│   ├── BoardManager.cs
│   ├── CellObject.cs
│   ├── FoodObject.cs
│   ├── GameManager.cs
│   ├── PlayerController.cs
│   ├── TurnManager.cs
│   └── WallObject.cs
├── Settings/         # URP render pipeline settings
├── Tiles/            # Tilemap palette and sprite sheet assets
├── UI/ & UI Toolkit/ # In-game UI (UXML/UI Toolkit)
└── Roguelike2D/      # Original Unity tutorial art/audio/font assets
```

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity Editor version `6000.0.83f1`

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/amineelghazi/Roguelike.git
   ```
2. Open **Unity Hub** → **Add project from disk** → select the cloned folder.
3. Let Unity import all assets and packages (first import may take a few minutes).
4. Open `Assets/Scenes/Main.unity`.
5. Press **Play** in the Unity Editor to run the game.

## Controls

| Action | Key |
|---|---|
| Move | `WASD` / Arrow Keys |
| Interact / Attack | Not yet implemented |

## Built With

- [Unity](https://unity.com/) — game engine
- C# — scripting
- Unity Input System — input handling
- Universal Render Pipeline (URP) — 2D rendering

## Credits

- Base project structure and starter assets from Unity's official [2D Roguelike tutorial](https://learn.unity.com/project/2d-roguelike-tutorial).
- Sprites, audio, and fonts under `Assets/Roguelike2D/TutorialAssets` are part of Unity's tutorial asset pack.

## License

No license yet — all rights reserved by default. Note that Unity's tutorial art/audio assets may carry their own separate licensing terms.
