using Unit05.Game.Casting;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>
    public class MoveActors : Action
    {
        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActors()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Player player2 = (Player) cast.GetFirstOfKey("player2");
            Player player1 = (Player) cast.GetFirstOfKey("player1");
            
            List<Actor> actors = cast.GetAllActors();
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
            }
            player1.ExtendTrail();
            player2.ExtendTrail();
        }
    }
}