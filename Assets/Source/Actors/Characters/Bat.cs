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
    public class Bat : Character

    {

        private Moving moving = new Moving();
        public Bat()
        {
            this.Health = 10;
            this.Strength = 4;

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
            Debug.Log("Oh no! I want to live!");
        }

        public override int DefaultSpriteId { get => 409; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Bat";

        protected override void OnUpdate(float deltaTime)
        {
            if(Time.time - lastTime > waitTime)
            {
                TryMove(moving.GetRandomDirection());
                Thread.Sleep(10);
            }
           
        }
        
    }
}
