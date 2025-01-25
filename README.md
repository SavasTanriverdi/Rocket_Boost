# Unity Space Game

This is a Unity-based space game where players control a spaceship, navigate through obstacles, and complete levels. The game includes features such as thrust and rotation controls, collision handling, and level progression.

## Table of Contents

- [Features](#features)
- [Screenshots](#screenshots)
- [Installation](#installation)
- [Usage](#usage)
- [Scripts](#scripts)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Thrust and Rotation Controls**: Control the spaceship using thrust and rotation inputs.
- **Collision Handling**: Handle collisions with different objects (friendly, finish, fuel).
- **Level Progression**: Progress through levels upon successful completion.
- **Debug Keys**: Use debug keys to load the next level or toggle collision.

## Screenshots

![resim](https://github.com/user-attachments/assets/0d53f935-e5a9-49ca-afb7-a39cad573c1e)
![resim](https://github.com/user-attachments/assets/dd51ad42-fd32-428e-8624-d7bbdfc00758)
![resim](https://github.com/user-attachments/assets/bc7ad276-de49-4233-83a9-7c060aa38eee)
![Ekran görüntüsü 2025-01-25 200903](https://github.com/user-attachments/assets/9387725d-a0f3-4e91-8cca-ff2c8ef36a85)




## Installation

1. **Clone the repository**:
    ```sh
    https://github.com/SavasTanriverdi/Rocket_Boost.git
    ```

2. **Open the project in Unity**:
    - Open Unity Hub.
    - Click on "Add" and select the cloned project folder.

3. **Install dependencies**:
    - Ensure you have the necessary Unity version installed.
    - Install any required packages via the Unity Package Manager.

## Usage

1. **Run the game**:
    - Open the `Assets/Scenes/MainScene.unity` scene.
    - Click on the "Play" button in the Unity Editor.

2. **Controls**:
    - **Thrust**: Press the spacebar to apply thrust.
    - **Rotate**: Use the arrow keys or mouse to rotate the spaceship.
    - **Debug Keys**:
        - Press `L` to load the next level.
        - Press `C` to toggle collision.

## Scripts

### `Movement.cs`

Handles the thrust and rotation of the spaceship.

### `CollisionHandler.cs`

Handles collisions with different objects and triggers appropriate responses (e.g., success, crash).

### `Oscillator.cs`

Moves objects back and forth in a specified direction.

### `QuitApplication.cs`

Quits the application when the Escape key is pressed.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
