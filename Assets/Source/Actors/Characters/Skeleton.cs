using System.Collections.Generic;
using System.Linq;
using Assets.Source.Actors.Static.Items;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;
using Item = DungeonCrawl.Actors.Static.Items.Item;
using System.Threading;
namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character

    {

        private Moving moving = new Moving();
        public Skeleton()
        {
            this.Health = 15;
            this.Strength = 3;

        }
        public override bool OnCollision(Actor anotherActor)
        {   if (anotherActor is Player)
            {
                Player player = anotherActor.GetComponent<Player>();
                ApplyDamage(player.Strength);
                if (player.Health > 0 && Health > 0)
                {
                    player.ApplyDamage(Strength);
                }
            }

            return false;
        }
        protected float waitTime = 1.0f;
        protected float lastTime;

        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId { get => 316; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Skeleton";

        protected override void OnUpdate(float deltaTime)
        {
            if(Time.time - lastTime > waitTime)
            {
                TryMove(moving.GetRandomDirection());
                
            }
           
        }
        
    }
}
