using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class WinTrigger : Trigger
    {
        public WinTrigger()
        {
            position = new Vector2(900, 350);
            collisionMask = new Rectangle((int)position.X, (int)position.Y, 2, 9999);
        }

        public override void Update(GameTime gameTime, Game1 context)
        {
            Rectangle mask = GetCollisionMask();
            foreach (Entity aEnt in context.stateManager.GetSpecificEntities(GameEntitiesEnum.friendly))
            {
                if (mask.Intersects(aEnt.GetCollisionMask()))
                {
                    ActivateTrigger(context);
                }
            }
        }

        protected override void ActivateTrigger(Game1 aContext)
        {
            aContext.stateManager.AddGuiElement(new VictoryLabel(new Vector2(50,50), aContext));  //TODO: Convert Absolute positioning to relative
            aContext.stateManager.RemoveEntity(this);
            base.ActivateTrigger(aContext);
            //aContext.stateManager.ChangeState(StateEnum.LootState);
        }

    }
}
