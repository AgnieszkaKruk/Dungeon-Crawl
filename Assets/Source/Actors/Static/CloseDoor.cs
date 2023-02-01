using System.Linq;
using Assets.Source.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace Assets.Source.Actors.Static
{
    public class CloseDoor : Actor
    {
        public override int DefaultSpriteId { get => 434; set => throw new System.NotImplementedException(); }

        public override string DefaultName => "OpenDoor";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)

        {
            if (anotherActor is Player player)
            {
                bool isAccess = player.Inventory.Any(x => x.DefaultSpriteId == 559);
                Debug.Log(isAccess);
                if (isAccess)
                {
                    Debug.Log(anotherActor);

                    ActorManager.Singleton.DestroyActor(this);
                    ActorManager.Singleton.Spawn<OpenDoor>((this.Position));
                    return true;
                } else
                {
                    UserInterface.Singleton.SetText("No Key!", UserInterface.TextPosition.BottomRight);
                }
            }

            return false;
        }

    }
}
