using System;
namespace DungeonCrawl
{
	public class GameState
	{
		public int id { get; set; }
		public string currentMap { get; set; }
		public DateTime saveAt { get; set; }
		public int playerId { get; set; }
	}
}
