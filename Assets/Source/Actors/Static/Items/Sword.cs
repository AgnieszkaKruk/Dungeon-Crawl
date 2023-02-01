using Assets.Source.Actors.Static.Items;

namespace DungeonCrawl.Actors.Static.Items
{
    public class Sword : Weapon
    {
        public Sword() => this.AttackPoint = 7;

        public override int DefaultSpriteId { get => 319; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Sword";
    }
}