using System;
using System.Collections.Generic;

namespace DungeonCrawl
{
    public class Moving
    {
        Random rand = new Random();
        
        
        public static Direction[] Directions => (Direction[])Enum.GetValues(typeof(Direction));

        public Direction[] HorizontalDirections = { Directions[2], Directions[3] };

        public Direction[] VerticalDirections = { Directions[0], Directions[1] };

        public Direction[] UpDirections = { Directions[0], Directions[0] };


        public Direction GetRandomDirection()
        {
            var i = rand.Next(0, Directions.Length);
            return Directions[i];
        }


        public Direction ThereAndBackMovements(Direction[] directions)
        {
            var i = rand.Next(0, directions.Length);
            return directions[i];
        }
        
    }
}

