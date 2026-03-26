# Wood Game

A 3D wood-gathering game built in Unity 2022.3 LTS.

## Gameplay

Move your character through a forest and chop down trees to collect wood logs.

- **WASD / Arrow Keys** — Move the player
- **Space** — Chop the nearest tree within range

Trees require multiple chops to fell. Each felled tree yields wood logs tracked in your inventory. New trees periodically respawn so the forest never stays empty for long.

## Project Structure

```
Assets/
  Scenes/
    MainScene.unity       — The main game scene
  Scripts/
    PlayerController.cs   — Handles player movement and chopping input
    Tree.cs               — Tree health and wood-drop logic
    GameManager.cs        — Global state: wood count, initial tree spawning
    TreeSpawner.cs        — Periodic tree respawn system
  Prefabs/                — (place Tree prefab here once created in the editor)
Packages/
  manifest.json           — Unity package dependencies
ProjectSettings/          — Unity project configuration
```

## Getting Started

1. Install **Unity 2022.3 LTS** (tested with 2022.3.20f1).
2. Open the project folder in the Unity Hub.
3. Open `Assets/Scenes/MainScene.unity`.
4. Press **Play** to start the game.

### First-time Setup in the Editor

After opening the project in Unity:

1. Create a **Tree Prefab** in `Assets/Prefabs/`:
   - Create a new `GameObject` with a `Capsule` mesh (to represent a tree trunk).
   - Attach the `Tree` script component.
   - Save it as a Prefab in `Assets/Prefabs/`.
2. On the **GameManager** GameObject in the scene, assign the Tree Prefab to the `treePrefab` field.
3. Press **Play** — trees will spawn and you can chop them with `Space`.

## Requirements

- Unity 2022.3 LTS or newer
