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
        protected override void ActivateTrigger(Game1 aContext)
        {
            aContext.stateManager.ChangeState(StateEnum.LootState);
        }

    }
}
