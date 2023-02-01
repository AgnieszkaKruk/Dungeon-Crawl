using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static
{
    public class OpenDoor : Actor
    {
        public override int DefaultSpriteId { get => 437; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "CloseDoor";

        public override int Z => -1;
        public override bool OnCollision(Actor anotherActor) => true;
    }
}
