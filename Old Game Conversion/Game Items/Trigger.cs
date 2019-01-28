using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Old_Game_Conversion.Game_Items
{
    class Trigger : Entity
    {

        public override void Update(GameTime gameTime, Game1 context)
        {
            Rectangle mask = GetCollisionMask();
            foreach (Entity aEnt in context.stateManager.GetSpecificEntities(GameEntitiesEnum.enemy, GameEntitiesEnum.friendly))
            {
                if (mask.Intersects(aEnt.GetCollisionMask()))
                {
                    ActivateTrigger(context);
                }
            }
            
        }

        protected virtual void ActivateTrigger(Game1 aContext)
        {

        }
    }
}
