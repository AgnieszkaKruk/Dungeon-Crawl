using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static { 

    public class Door : Actor
    {
        public override int DefaultSpriteId { get => 441; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Door";


    }
}
