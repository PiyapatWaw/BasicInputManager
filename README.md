# BasicInputManager

This project is a simple Unity-based character controller using a state machine pattern for managing character states and input handling. The character can move and use skills based on user input.

## Features

- **State Machine Pattern**: Modular and maintainable structure for character behavior.
- **Character Movement**: Handle movement input with smooth transitions.
- **Skill Usage**: Activate skills using specified input keys.

## Prerequisites

- Unity 2021.3 or later

## Usage

### 1. Character Controller

The `Character` class handles character initialization, state transitions, and input responses. It uses a state machine to switch between different states such as idle, walking, and using skills. The `Character` class listens for input events from the `InputManager` to transition between these states.

- **Initialization**: Call the `Initialize` method with a list of skills to set up the character.
- **State Transitions**: The `Update` method listens for input and changes the character's state accordingly.

### 2. InputManager

The `InputManager` class captures user input and triggers appropriate events for movement and skill usage. It checks for key presses and directional input in its `Update` method and invokes events that the `Character` class listens to.

- **Singleton Pattern**: Ensures a single instance of the input manager.
- **Input Handling**: Detects movement and skill key presses in the `ReadInput` method.

### 3. GameBootstrapper

The `GameBootstrapper` class initializes the `InputManager` before the scene loads. This ensures that input handling is set up and ready as soon as the game starts.

- **Initialization**: Creates and sets up the `InputManager` before the game scene loads.
- **Don't Destroy On Load**: Ensures the `InputManager` persists across different scenes.

### Key Components and Relationships

#### Character

- **Initialization**: Initializes with a list of skills and starts in the idle state.
- **State Transitions**: Changes between `IdleState`, `WalkingState`, and `UsingSkillState` based on input.
  - **IdleState**: The default state where the character is not moving.
  - **WalkingState**: Activated when there is movement input, handles character movement.
  - **UsingSkillState**: Activated when a skill input is detected, handles skill execution.

#### InputManager

- **Singleton Pattern**: Ensures a single instance of the input manager.
- **Input Handling**: Detects movement and skill key presses in the `ReadInput` method.

#### GameBootstrapper

- **Initialization**: Creates and sets up the `InputManager` before the game scene loads.
- **Don't Destroy On Load**: Ensures the `InputManager` persists across different scenes.

### Extending the Project

1. **Add New States**: Create new state classes implementing `ICharacterState` for additional behaviors.
2. **Skills**: Implement the `ISkill` interface for different character abilities.
3. **UI Integration**: Connect UI buttons to the `InputManager` for skill activation.

## Example Workflow

1. **Initialize Character**: Set up the character with a list of skills.
2. **Input Handling**: The `InputManager` reads inputs and updates the character state.
3. **State Management**: Based on the input, the character transitions between states (Idle, Walking, UsingSkill).
4. **Animation**: Animator parameters are updated according to the current state.
5. **Movement**: The `WalkingState` handles character movement direction and rotation.
6. **Skill Usage**: The `UsingSkillState` manages skill execution and transitions back to Idle state after skill use.

## Conclusion

This character controller system provides a structured way to manage character actions and inputs in a Unity game. By leveraging state management and interfaces, the code is organized and extensible, allowing for easy addition of new states and inputs.
