using DungeonCrawl.Core;
namespace DungeonCrawl.Actors.Static.Items
{
    public class PunchStrike : Actor
    {
        public override int DefaultSpriteId { get => 605; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "PunchStrike";
        public override int Z => -2;
    }
}