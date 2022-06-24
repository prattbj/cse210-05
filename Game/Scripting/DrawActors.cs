using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActors : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActors(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Player player1 = (Player)cast.GetFirstOfKey("player1");
            Player player2 = (Player)cast.GetFirstOfKey("player2");
            List<Actor> body1 = player1.GetSegments();
            List<Actor> body2 = player2.GetSegments();
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(body1);
            videoService.DrawActors(body2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}