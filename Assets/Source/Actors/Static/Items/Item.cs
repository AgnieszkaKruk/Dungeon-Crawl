using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;


namespace DungeonCrawl.Actors.Static.Items
{
    public abstract class Item : Actor
    {
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                UserInterface.Singleton.SetText("Press E to pick up", UserInterface.TextPosition.BottomRight);
            } 
            
            return true;
        }
        

        // put item on top of map
        public override int Z => -1;
    }
}
