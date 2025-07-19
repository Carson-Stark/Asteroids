# Asteroids

![hero](https://github.com/user-attachments/assets/afa9fe7f-109a-4d97-bc49-f2e3db50e080)

Asteroids is a modern 2D remake of the classic ATARI game, built in Unity as an educational project to teach game development fundamentals. Players control a drifting spaceship, shooting and dodging procedurally spawned asteroids while the game progressively increases in difficulty.

- **Original Project Date:** November 2021

## Features

- **Procedural Asteroid Spawning**  
  Asteroids spawn randomly and break into smaller fragments when shot.

- **Physics-Based Movement**  
  Drifty, rotation-based movement using `Rigidbody2D` physics for realistic space feel.

- **Shooting Mechanics**  
  Projectile firing system with cooldowns and player knockback.

- **Screen Wraparound**  
  Both the player and asteroids seamlessly loop across screen edges.

- **Progressive Difficulty**  
  Asteroid spawn rate dynamically scales with player score.

- **Audio and Visual Feedback**  
  - Shooting sounds, asteroid destruction, and death audio.
  - Particle effects for thruster propulsion and collisions.

- *Graphics and audio assets were sourced from free online libraries.*

## Demo Video

https://github.com/user-attachments/assets/5ddc1d3b-9a4f-4a3a-a316-008cbe233c82

## Usage Instructions

### Controls

| Action         | Key                |
|----------------|--------------------|
| Thrust         | W / Up Arrow       |
| Rotate Left    | A / Left Arrow     |
| Rotate Right   | D / Right Arrow    |
| Shoot          | Spacebar           |

### Setup

1. **Clone or Download the Project:**

   ```bash
   git clone [<repository_url>](https://github.com/Carson-Stark/Asteroids)
   ```

2. Open in Unity:

  - Unity Version: 2021.x.x or newer recommended.
  - Open the project folder via Unity Hub.

3. Play the Game:

  - Press Play in the Unity editor.
  - Use the controls to shoot asteroids and survive as long as possible.

### Build Instructions

To build the game:
  
  1. Go to File > Build Settings in Unity.
  2. Select your target platform (Windows, Mac, WebGL, etc.).
  3. Click Build.
Difficulty Scaling
Spawn rate of asteroids increases with player score.

New audio cues play when difficulty milestones are reached.
