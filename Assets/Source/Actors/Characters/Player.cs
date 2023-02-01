using System.Collections.Generic;
using System.Linq;
using Assets.Source.Actors.Static.Items;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;
using Door = DungeonCrawl.Actors.Static.Door;
using Item = DungeonCrawl.Actors.Static.Items.Item;
using Key = DungeonCrawl.Actors.Static.Items.Key;
using Heart = DungeonCrawl.Actors.Static.Items.Heart;
using Crown = DungeonCrawl.Actors.Static.Items.Crown;
using System.Threading;



namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Player()
        {
            this.Health = 10;
            this.Strength = 5;
        }

        public override int DefaultSpriteId { get => 24; set => throw new System.NotImplementedException(); }
        public override string DefaultName => "Player";
        public bool isInventory = true;
        public List<Item> Inventory = new List<Item>();
        public int doorCount = 0;
        




        protected override void OnUpdate(float deltaTime)
        {
            Thread.Sleep(0);
            DisplayStats();
            NextLevel(doorCount);
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMove(Direction.Up);
                OpenDoor(Direction.Up);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                TryMove(Direction.Down);
                OpenDoor(Direction.Down);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                TryMove(Direction.Left);
                OpenDoor(Direction.Left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                TryMove(Direction.Right);
                OpenDoor(Direction.Right);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
           
               
                var objItem = ActorManager.Singleton.GetActorAt<Item>(this.Position);

                if(!(objItem is Heart heart))
                {
                    Inventory.Add(objItem);
                }
                
                
                Debug.Log(objItem);

                if (objItem != null)
                {
                    UserInterface.Singleton.SetText("", UserInterface.TextPosition.BottomRight);
                }
              
                if (objItem is Weapon weapon)
                {
                    Strength += weapon.AttackPoint;
                    Health += weapon.HealthPoint;

                }
                ActorManager.Singleton.DestroyActor(objItem);
                Debug.Log(objItem);
                ShowInventory();
            }


            if (Input.GetKeyDown(KeyCode.I))
            {
                ShowInventory();
            }  
        }



        private void ShowInventory()
        {
            if (isInventory)
            {
                //var displyInventory = Enumerable.Range(0, Inventory.Count).Aggregate("Inventory\n", (p, c) => p + c); shows number because Enumerable.Range(0, Inventory.Count);
                var displayInventory = Inventory.Aggregate("Your Inventory\n", (p, c) => p + c.DefaultName + $"{DisplayAttackStat(c)}\n");
                UserInterface.Singleton.SetText(displayInventory, UserInterface.TextPosition.TopRight);
             
            }
            else
            {
                UserInterface.Singleton.SetText("", UserInterface.TextPosition.TopRight);
                isInventory = SwitchState(isInventory);
            }
        }



        private void DisplayStats()
        {
            UserInterface.Singleton.SetText($"HEALTH: {Health.ToString()}\nAttack: {Strength.ToString()}", UserInterface.TextPosition.TopLeft);
        }



        private string DisplayAttackStat(Item c)
        {
            return c is Weapon w ? $" + {w.AttackPoint.ToString()} att" : "";
        }

      



        public bool SwitchState(bool toSwitch)
        {
            return toSwitch == true ? false : true;
        }

        public void AfterDeath(Player player)
        {
            Inventory = player.Inventory;
            Strength = player.Strength - 1;
            Health = (int)player.Health / 2;
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Skull)
            {
                OnDeath();

                var afterDeathPlayer = ActorManager.Singleton.Spawn<Player>((7, -17));
                afterDeathPlayer.AfterDeath(this);
                ActorManager.Singleton.DestroyActor(this);
                return true;
            }
            return false;
        }



        protected override void OnDeath()
        {
            UserInterface.Singleton.SetText("Oh no! I'm dead... \n GAME OVER", UserInterface.TextPosition.MiddleCenter);
        }

        private void OpenDoor(Direction direction)
        {
            
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);
            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition is Door door)
            {
                foreach (var obj in Inventory)
                {
                    if (obj is Key key)
                    {
                        ActorManager.Singleton.DestroyActor(door);
                        
                        doorCount++;
                        Inventory.Remove(obj); 
                        ShowInventory();
                    }
                }
            }
        }
        public void NextLevel(int doorCount)
        {
            if(doorCount == 3)
            {
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap(2);
            }
            foreach(var obj in Inventory)
                {
                if (obj is Crown crown)
                {
                    ActorManager.Singleton.DestroyAllActors();
                    UserInterface.Singleton.SetText("Will be continued...", UserInterface.TextPosition.MiddleCenter);

                }
            }
        }
        
    }
}
