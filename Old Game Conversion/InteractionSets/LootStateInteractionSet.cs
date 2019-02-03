using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Old_Game_Conversion.Game_Items;
using Old_Game_Conversion.Loot_State_Items;

namespace Old_Game_Conversion.InteractionSets
{
    class LootStateInteractionSet : InteractionSet
    {
        protected BattleReport report;

        public LootStateInteractionSet(Game1 aContext)
        {
            context = aContext;
            context.stateManager.gameStats.EndBattleReport();
            guiElements = new List<GuiElement>()
            {
                new LootScreenFrame(new Vector2(50, 50), context) //TODO: convert absolute placement to relative
            };

        }

    }
}
