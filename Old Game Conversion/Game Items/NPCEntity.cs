using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Old_Game_Conversion.Game_Items
{
    class NPCEntity : Entity
    {
        protected List<Entity> connectedEntities = new List<Entity>();
        protected int killWorth;
        protected bool isFriendly;

        public override void SetCollisionMask(Texture2D aText)
        {
            base.SetCollisionMask(aText);
        }

        public override void AddConnectedEntity(Entity anEntity)
        {
            connectedEntities.Add(anEntity);
        }

        protected bool StandingOnSolidGround()
        {
            foreach (Entity aEnt in context.stateManager.GetSpecificEntities(GameEntitiesEnum.ground))
            {
                if (aEnt.GetCollisionMask().Intersects(GetCollisionMask()))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual void Die()
        {
            context.stateManager.AddStats(StatEnum.currency, killWorth);
            foreach(Entity connected in connectedEntities)
            {
                context.stateManager.GetEntities().Remove(connected);
            }
            context.stateManager.RemoveEntity(this);
        }
    }
}