# Assignment 3: INFINITE FLYER

A fast-paced 2D arcade game built in Unity that puts a mind-bending twist on the classic "Flappy" formula. Players navigate a bird through a procedurally generated obstacle course, featuring moving pipes, collectibles, and a unique gravity inversion mechanic that flips the physics, visuals, and audio of the entire game on the fly. 

## 🎮 Game Controls

The game utilizes Unity's modern Input System for responsive, cross-platform inputs. 

* **Flap / Jump:** Press **Spacebar** to propel the bird upwards. 
* **Note on Gravity:** When passing through a Gravity Pipe, your jump direction inverts. Flapping will propel you *downwards* relative to the screen to match the newly inverted physics!

## 📐 Technical Implementation Details

### Infinite Parallax Scrolling System
To create a seamless illusion of forward movement without the performance overhead of constantly instantiating and destroying background objects, the game utilizes a continuous resetting parallax system (`BackgroundController.cs`). 

**How it works:**
1. **Initialization:** On `Start()`, the script calculates the exact width of the background sprite using `GetComponent<SpriteRenderer>().bounds.size.x` and caches the original starting X-coordinate.
2. **Translation:** Every frame, the background moves along the negative X-axis. The movement speed is dynamically tied to the global game speed (`Pipes.speed`) multiplied by a customizable `parallaxEffect` scalar (e.g., 0.5f) and `Time.deltaTime`.
3. **Seamless Reset:** The system continuously checks if the background's current X position has traveled beyond its own cached length (`transform.position.x <= startPos - length`). Once this threshold is crossed, the background is instantaneously shifted forward by exactly its length on the X-axis. This snapping happens out of the camera's view, creating a perfect, infinite loop.

### Gravity Inversion System
Passing through special gravity pipes flips the world upside down. This inverts the 2D physics gravity (`Physics2D.gravity = new Vector2(0, -9.81f)`), flips the background's Y-scale, toggles post-processing volumes for visual feedback, and applies audio filters to both the music and sound effects via the centralized `GameManager` and `AudioManager`.

### Dynamic Obstacle Spawning
The `Spawner` utilizes a Coroutine to implement progressive difficulty over time. Every `diffInterval` seconds, the global pipe speed increases, and the spawn intervals decrease. The spawner rolls a weighted chance (30%) to spawn vertically oscillating pipes powered by a mathematical sine wave, ensuring gameplay remains unpredictable.

## 🛠️ Setup & Installation

1. Clone the repository.
2. Open the project in Unity (Ensure you have the "Input System" package installed).
3. Open the Main Menu or Game scene and press **Play**.
4. Alternatively, you can also play the finished build in ./Build/BTL3.exe

## 📦 Asset Sources & Attribution

* **Sprites & Art Assets:**
  * **Flappy Bird Sprites:** https://youtu.be/XtQMytORBmM?si=5tDL0uVEtg5c0jCD
  * **Coin Collectible:** https://www.pngegg.com/vi/png-ertzr
  * **Sky Background:** https://free-game-assets.itch.io/free-sky-with-clouds-background-pixel-art-set
* **Audio & Sound Effects (SFX):**
  * **Background Music (BGM):** https://beatscribe.itch.io/beatscribes-free-uge-music-asset-pack
  * **SFX:** https://harvey656.itch.io/8-bit-game-sound-effects-collectio
