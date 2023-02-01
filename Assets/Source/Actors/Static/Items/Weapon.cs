using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors.Static.Items;

namespace Assets.Source.Actors.Static.Items
{
    public abstract class Weapon : Item
    {
        public int AttackPoint { get; set; }
        public int HealthPoint { get; set; }
    }
}
