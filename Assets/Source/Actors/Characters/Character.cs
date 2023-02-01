using DungeonCrawl.Core;
using UnityEngine;
using System;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        private static int _currentID;
        public int ID { get; set; }
        protected int GenerateNextID()
        {
            return ++_currentID;
        }

        public int Health { get; set; }
        public int Strength { get; set; }
        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

        protected virtual void Act()
        {
            Debug.Log("Rusza sie");
        }
        





    }
}
