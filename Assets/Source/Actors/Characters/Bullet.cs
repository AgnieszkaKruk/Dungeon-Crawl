using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Source.Actors.Static.Items;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;
using Item = DungeonCrawl.Actors.Static.Items.Item;
using System.Threading;
using Wall = DungeonCrawl.Actors.Static.Wall;
using Door = DungeonCrawl.Actors.Static.Door;

namespace DungeonCrawl.Actors.Characters
{
    public class Bullet : Character
    {

        public override int DefaultSpriteId { get => 253; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Bullet";
        
        private Moving moving = new Moving();
        public Bullet()
        {
            this.Health = 1;
            this.Strength = 1;

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
                    //ActorManager.Singleton.DestroyActor(this);

                }
            }

            return false;
        }

        protected override void OnDeath()
        {
            Debug.Log("Shooting");
        }

        protected float waitTime = 1.0f;
        protected float lastTime;

        protected override void OnUpdate(float deltaTime)
        {
            
           TryMove(moving.ThereAndBackMovements(moving.UpDirections));
           Thread.Sleep(50);
            DestroyBullet(Direction.Up);
        }
        public void DestroyBullet(Direction direction)
        
        {
            
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);
            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition is Door door || actorAtTargetPosition is Wall wall || actorAtTargetPosition is Bullet )
            {
                
                {
                  
                    ActorManager.Singleton.DestroyActor(this);
                    

                }
                
            }
        }



    }
}
