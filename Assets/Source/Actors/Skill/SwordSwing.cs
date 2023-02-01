using DungeonCrawl.Core;
namespace DungeonCrawl.Actors.Static.Items
{
    public class SwordSwing : Actor
    {
        public override int DefaultSpriteId { get => 552; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "SwordSwing";
        public override int Z => -2;
    }
}