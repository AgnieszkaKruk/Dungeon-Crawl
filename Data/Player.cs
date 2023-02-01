using System;
namespace DungeonCrawl {
	public class Player
	{
		public string playerName { get; set; };
		public int playerId { get; set; };
		public int playerHp { get; set; };
		public int playerX { get; set; };
		public int playerY { get; set; };
		public string inventory { get; set; };
		public string discoveredMap { get; set; };


	}
}
