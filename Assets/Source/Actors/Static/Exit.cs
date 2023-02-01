using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Static
{
    public class Exit : Actor
    {
        public override int DefaultSpriteId { get => 984; set => throw new System.NotImplementedException(); }

        public override string DefaultName => "Exit";
        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {

                return true;
            }

            return false;
        }
        protected override void OnUpdate(float deltaTime)
        {
        }
    }
}
