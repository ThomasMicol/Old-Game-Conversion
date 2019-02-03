using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Old_Game_Conversion.Game_Items;
using Old_Game_Conversion.Loot_State_Items;

namespace Old_Game_Conversion.InteractionSets
{
    class LootStateInteractionSet : InteractionSet
    {
        protected BattleReport report;

        public LootStateInteractionSet()
        {
            guiElements = new List<GuiElement>()
            {
                new LootScreenFrame(),
                new LootVictoryLabel(report),
                new ExpGainedBars(report),
                new LootGainedBoxes(report),
                new ContinueButton()
            };

        }

    }
}
