using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A player on a bike.</para>
    /// <para>The bike continually leaves a trail behind it..</para>
    /// </summary>
    public class Player : Actor
    {
        private List<Actor> segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of Player.
        /// </summary>
        public Player(Color color, Point spawn)
        {
            PreparePlayer();
            this.color = color;
            this.spawn = spawn;
            this.x = spawn.GetX();
            this.y = spawn.GetY();

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

        public void ExtendTrail()
        {
            Actor tail = segments.Last<Actor>();
            Point velocity = tail.GetVelocity();
            Point offset = velocity.Reverse();
            Point position = tail.GetPosition().Add(offset);

            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.SetVelocity(velocity);
            segment.SetText("#");
            segment.SetColor(Constants.GREEN);
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

        public void TurnCycle(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the Player trail for moving.
        /// </summary>
        private void PreparePlayer()
        {
            int x = this.x;
            int y = this.y;


            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(this.color);
                segments.Add(segment);
            }
        }
    }
}