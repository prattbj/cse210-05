namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    /// </summary>
    public class Player : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private Point spawn = new Point(0, 0);

        /// <summary>
        /// Constructs a new instance of Player.
        /// </summary>
        public Player(Color color, Point spawn)
        {
            SetColor(color);
            this.spawn = spawn;
            PreparePlayer();
        }

        /// <summary>
        /// Gets the Player's trail segments.
        /// </summary>
        /// <returns>The trail segments in a List.</returns>
        public List<Actor> GetTrail()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the Player's cycle.
        /// </summary>
        /// <returns>The cycle segment as an instance of Actor.</returns>
        public Actor GetCycle()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the Player's segments (including the cycle).
        /// </summary>
        /// <returns>A list of Player segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Adds an additional Actor to the segments list, extending the trail.
        /// </summary>
        public void ExtendTrail()
        {
            Actor trail = segments.Last<Actor>();
            Point velocity = trail.GetVelocity();
            Point offset = velocity.Reverse();
            Point position = trail.GetPosition().Add(offset);

            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.SetVelocity(velocity);
            segment.SetText("#");
            segment.SetColor(this.GetColor());
            segments.Add(segment);
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        // Turns the player's cycle to face the given direction
        public void TurnCycle(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the Player trail for moving.
        /// </summary>
        private void PreparePlayer()
        {
            int x = spawn.GetX();
            int y = spawn.GetY();


            Point position = new Point(x, y);
            string text = "@";

            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.SetColor(this.GetColor());
            segment.SetText(text);
            segments.Add(segment);
        }
    }
}