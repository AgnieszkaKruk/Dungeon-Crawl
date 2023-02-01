using Assets.Source.Actors.Static.Items;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Heart : Weapon
    {
        public Heart() => this.HealthPoint= 7;

        public override int DefaultSpriteId { get => 629; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Heart";
    }
}