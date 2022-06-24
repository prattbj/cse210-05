# cse210-05
 Cycle game

Classes:
    Constants - Holds constant variables, like colors, font size, resolution, etc.
    Program - Creates the cast, script, services, then starts the game by calling Director()
    Director - Launches the game and runs the game loop phases: "Input, update, output"
    KeyboardService - Indicates the key being pressed
    VideoService - Draws the game state to the screen
    Cast - Holds all actors in a dictionary
    Player - Creates the cycles and holds methods for turning, moving, and extending
    Actor - Keeps track of all items' appearance, position and velocity in 2d space
    Color - Returns color values
    Point - Gets location of all objects on the screen and has methods for doing calculations with them
    Script - Holds a dictionary of actions
    DrawActors - Draws all of the items through VideoService
    HandleCollisions - Ends the game when a collision occurs
    MoveActors - Moves the cycle head and extends the tail with each frame.
    ControlActors - Sets the direction of the cycle