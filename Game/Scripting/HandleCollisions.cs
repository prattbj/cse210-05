using Unit05.Game.Casting;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisions : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisions()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }


        /// <summary>
        /// Sets the game over flag if a cycle collides with a trail
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            
            Player player1 = (Player) cast.GetFirstOfKey("player1");
            Player player2 = (Player) cast.GetFirstOfKey("player2");
            Actor head1 = player1.GetCycle();
            Actor head2 = player2.GetCycle();
            List<Actor> body1 = player1.GetSegments();
            List<Actor> body2 = player2.GetSegments();

            foreach (Actor segment in body1.Skip(1))
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                }
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                }
            }
            foreach (Actor segment in body2.Skip(1))
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                }
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                }
            }  
        }
        

        // Handles what happens if the game ends.
        // Turns the cycles and their trails white and 
        // displays the game over message.
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Player player1 = (Player)cast.GetFirstOfKey("player1");
                Player player2 = (Player)cast.GetFirstOfKey("player2");
                List<Actor> body1 = player1.GetSegments();
                List<Actor> body2 = player2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2 - 110;
                int y = Constants.MAX_Y / 2 - 45;
                Point position = new Point(x, y);
                Color color = new Color(255, 0, 255);
                Actor message = new Actor();
                message.SetColor(color);
                message.SetFontSize(45);
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in body1)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in body2)
                {
                    segment.SetColor(Constants.WHITE);
                }
                player1.SetColor(Constants.WHITE);
                player2.SetColor(Constants.WHITE);
            }
        }

    }
}