using Old_Game_Conversion.Game_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Loot_State_Items
{
    class LootGainedBoxes : IterableFrameElement
    {
        protected BattleReport myReport;

        public LootGainedBoxes(BattleReport aReport, GameStats aGameStats)
        {
            myReport = aReport;
        }


    }
}
