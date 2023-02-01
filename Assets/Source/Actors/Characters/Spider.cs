using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Source.Actors.Static.Items;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;
using Item = DungeonCrawl.Actors.Static.Items.Item;
using System.Threading;

namespace DungeonCrawl.Actors.Characters {

    public class Spider : Character
    {
        public override int DefaultSpriteId { get => 268; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Spider";



        //var SpiderRenderer = Spider.GetComponent<Renderer>();
        //SpiderRenderer.material.SetColor("_Color",Color.red);


        //private SpriteRenderer renderer;
        //renderer = GetComponent<SpriteRenderer>();
        //renderer.color = Color.blue;
        private Moving moving = new Moving();


        public Spider()
        {
            this.Health = 10;
            this.Strength = 2;
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
            Debug.Log("Don't hurts small insects!");
        }


        protected override void OnUpdate(float deltaTime)
        {
            TryMove(moving.ThereAndBackMovements(moving.VerticalDirections));
            Thread.Sleep(50);
        }
    } 
 }
