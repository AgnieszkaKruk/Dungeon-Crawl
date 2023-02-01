using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors.Static.Items;

namespace Assets.Source.Actors.Static.Items
{
    public class Hearth : Life
    {
        public Hearth() => Health = 1;

        public override int DefaultSpriteId { get => 518; set => throw new System.NotImplementedException(); }

        public override string DefaultName => "Hearth";
    }
}
