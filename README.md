# 3D Runner Game

## Overview
This is a simple 3D endless runner game developed in Unity as part of a test assignment. The game features a player character that automatically runs forward along the Z-axis, with player-controlled strafing (left/right movement) and jumping to avoid obstacles and collect coins. The project demonstrates modular code structure, 3D mechanics, animations, and a responsive UI, built with clean coding practices and minimal dependencies.

## Features
- **Core Mechanics**:
  - Automatic forward movement along the Z-axis at a fixed speed.
  - Player-controlled strafing (smooth left/right movement along the X-axis).
  - Jumping to avoid obstacles.
  - Coin collection system with 3D coin objects that update a score counter.
  - Static obstacles (walls, barriers, spikes, mines).
  - Single level lasting 30–60 seconds with 5–10 obstacles and 10–20 coins.
- **Animations**:
  - Running animation for the player character.
  - Coin collection animation (rotation, scaling, or disappearance).
- **User Interface**:
  - Real-time coin counter displayed during gameplay.
  - Main menu with "Start" and "Exit" buttons.
  - Game over screen showing the final coin score and a "Retry" button.
  - Responsive UI that adapts to different screen resolutions.
- **Modularity**:
  - Organized systems: `PlayerController`, `GameplayManager`, `CollectibleManager`, `ObstacleManager` and Entry Points in each scene provides clear understanding of game initialization process.
  - Loose coupling using events or ScriptableObjects to minimize dependencies.
  - Clean project structure with folders: `Scripts`, `Prefabs`, `Sources` and some of Unity Asset Store packages.
- **Bonus Features**:
  - Coin collection effects, obstacle collision VFX.

## Requirements
- **Unity Version**: Unity 6000.0.42f1 LTS or compatible.
- **Platform**: Tested on Android and in the Unity Editor with Android target platform.
- **Assets**: Uses only custom assets or Unity's built-in 3D primitives (e.g., capsules, cubes). No third-party game templates are used.

## Setup Instructions
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/3d-runner-game.git
   ```
2. **Open in Unity**:
   - Open Unity Hub and select "Add".
   - Navigate to the cloned repository folder and open the project.
   - Ensure the Unity version matches or exceeds 6000.0.42f1 LTS.
3. **Project Structure**:
   - `Scripts/`: Contains all C# scripts.
   - `Prefabs/`: Prefabs for the player, coins, obstacles, and UI elements, etc.
   - `Sources/`: Sources of models, sprites, etc.
   - `Scenes/`: Contains the main game scene and menu scene.
4. **Running the Game**:
   - Open the main scene (e.g., `MainScene.unity`) from the `Scenes/` folder.
   - Go to Simulation play mode.
   - Press the "Play" button in the Unity Editor to start the game.

## Gameplay
- **Objective**: Collect as many coins as possible while avoiding obstacles.
- **Controls**:
  - **A/D or Left/Right Arrow Keys**: Strafe left or right.
  - **Spacebar**: Jump to avoid obstacles.
- **Game Flow**:
  - Start the game from the main menu by clicking "Start".
  - The player automatically runs forward, collecting coins and avoiding obstacles.
  - Colliding with an obstacle ends the game, displaying the game over screen with the coin score.
  - Click "Retry" to restart or "Exit" to quit.

## Code Structure
The project follows a modular design with minimal dependencies:
- **PlayerController**: Handles player movement (auto-run, strafe, jump) and collision detection.
- **CollectibleManager**: Manages coin spawning, collection, and animations.
- **UIManager**: Updates the coin counter and handles menu/game over UI.
- **GameManager**: Controls game state transitions (start, play, game over).
- Events or ScriptableObjects are used to communicate between systems, ensuring loose coupling.
- Code includes comments for key methods and is organized for readability.

## Disclaimer
**Running in Unity Editor**: To play the game in the Unity Editor, ensure the Play Mode is set to **Simulation Mode**. This is required for accurate physics and input handling. To enable Simulation Mode:
1. Go to **Edit > Project Settings > Editor**.
2. Set **Play Mode** to **Simulation Mode** before pressing the Play button.

## Known Limitations
- The game is designed for a single level (30–60 seconds). No additional levels are included.
- Bonus features (particle effects, sounds) may not be fully implemented unless specified.
- Tested primarily in the Unity Editor; standalone builds may require additional configuration.

## Future Improvements
- Add multiple levels with increasing difficulty.
- Implement a high-score system with persistent storage.
- Enhance visuals with more detailed 3D models and environments.
- Add more complex obstacle patterns or power-ups.

## License
This project is for demonstration purposes only and is not licensed for commercial use.

## Contact
For questions or feedback, please contact [your-email@example.com] or open an issue on the GitHub repository.
