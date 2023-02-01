namespace DungeonCrawl.Actors.Static
{

    public class Floor2 : Actor
    {
        public override int DefaultSpriteId { get => 0; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Floor2";

        public override bool Detectable => false;
    }
}
