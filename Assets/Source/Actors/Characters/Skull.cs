using System.Collections.Generic;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;
using Random = System.Random;

namespace DungeonCrawl.Actors.Characters
{
    public class Skull : Character
    {
        public List<Skull> skulls = new List<Skull>();
        public Skull()
        {
            this.ID = GenerateNextID();
            skulls.Add(this);
        }

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }
        bool isLeft = true;
        protected override void OnUpdate(float deltaTime)
        {
            if (Time.time > OnNextFrame)
            {

                Random PRNG = new Random();
                foreach (Skull skull in skulls)
                {
                    int randomNum = PRNG.Next(1, 3);
                    Debug.Log(skull.ID);
                    switch (skull.ID)
                    {
                        case 1:

                            if (skull.Position.x == 23) isLeft = true;
                            if (skull.Position.x == 15) isLeft = false;
                            if (isLeft) TryMove(Direction.Left);
                            if (!isLeft) TryMove(Direction.Right);
                            break;
                        case 2:
                            if (skull.Position.x == 23) isLeft = true;
                            if (skull.Position.x == 15) isLeft = false;
                            if (isLeft) TryMove(Direction.Left);
                            if (!isLeft) TryMove(Direction.Right);
                            break;
                        case 3:
                            if (skull.Position.x == 23) isLeft = true;
                            if (skull.Position.x == 15) isLeft = false;
                            if (isLeft) TryMove(Direction.Left);
                            if (!isLeft) TryMove(Direction.Right);
                            break;
                        case 4:
                            if (skull.Position.x == 23) isLeft = true;
                            if (skull.Position.x == 15) isLeft = false;
                            if (isLeft) TryMove(Direction.Left);
                            if (!isLeft) TryMove(Direction.Right);
                            break;
                        case 5:
                            if (skull.Position.x == 23) isLeft = true;
                            if (skull.Position.x == 14) isLeft = false;
                            if (isLeft) TryMove(Direction.Left);
                            if (!isLeft) TryMove(Direction.Right);
                            break;
                       
                    }
                }

                OnNextFrame = Time.time + SkeletonSpeed;
            }
        }

        private float SkeletonSpeed = 0.6f;
        private float OnNextFrame = 0f;


        //public override int DefaultSpriteId { get => 709; set => throw new System.NotImplementedException(); }
        public override int DefaultSpriteId { get => 709; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Skull";
    }
}