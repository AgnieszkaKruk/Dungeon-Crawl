namespace DungeonCrawl.Actors.Static
{

    public class Floor : Actor
    {
        public override int DefaultSpriteId { get => 1; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Floor";

        public override bool Detectable => false;
    }
}
