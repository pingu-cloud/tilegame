# Unity Developer Intern - Mini Assignment

## Objective
This prototype showcases a grid-based game created in Unity, highlighting interaction mechanics, visual animations, and problem-solving abilities. The game is built for WebGL and can be played in a browser.

---

## Features

### Core Features (Implemented)
1. **Grid System**:
   - A 7x7 grid of square tiles.
   - Tiles feature at least 3 distinct colors, arranged randomly at the start of the game.

2. **Tile Selection**:
   - Players can click on tiles to select them.
   - Selected tiles are visually highlighted with highlight colour .
   - Clicking another tile moves the highlight to the new tile.

3. **Tile Matching**:
   - If two adjacent tiles of the same color are selected consecutively:
     - They disappear from the grid.
     - Empty spaces are filled with new tiles falling from the top.
   - New tiles have random colors and integrate seamlessly into the grid with animations.

4. **Animations**:
   - Idle tiles have subtle tween animations to enhance visual appeal.
   - Tile reactivation or refilling includes smooth animations.
5. **Basic Scoring System**:
   - A score counter increases each time a valid match is made.
   - The score is displayed on the screen.

---



## How to Play
1. Open the game on the itch.io page linked below.
2. Click on a tile to select it.
3. Select an adjacent tile of the same color to make them disappear.
4. Enjoy the animations for tile interactions and refilling!

---

## Development Tools & Resources
- **Unity Version**: 2022.3.44f1 .
- **Programming Language**: C# for scripting.
- **Animation Tool**: Tween animations via [DOTween/LeanTween] (if applicable).
- **WebGL Hosting**: itch.io.

---

## Author
This project was developed as part of the Unity Developer Intern application. For questions or feedback, contact me at [devi.rath07@gmail.com].

---

## Demo
https://devirath.itch.io/tilegame

