using System;
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
    public class Boss:Character
    {

        public override int DefaultSpriteId { get => 167; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Boss";

        private Moving moving = new Moving();
        public Boss()
        {
            this.Health = 20;
            this.Strength = 3;

        }
        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
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

        protected override void OnDeath()
        {
            Debug.Log("Don't mess with the Boss!");
        }

        protected float waitTime = 1.0f;
        protected float lastTime;

        protected override void OnUpdate(float deltaTime)
        {

            ActorManager.Singleton.Spawn<Bullet>(Position);
            TryMove(moving.ThereAndBackMovements(moving.HorizontalDirections));
            Thread.Sleep(50);
        }


    }
}
