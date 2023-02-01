using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Static
{
    public class ExitGlow : Actor
    {

        public override int DefaultSpriteId { get => 1032; set => throw new System.NotImplementedException(); }

        public override string DefaultName => "ExitGlow";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {

                return true;
            }

            return false;
        }
    }
}
