using System;
using Old_Game_Conversion.Game_Items.Loot_Tables.Ground_Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class LootTableFactory
    {
        public static LootTable GetLootTable(NPCTypeEnum type)
        {
            switch(type)
            {
                case NPCTypeEnum.foot_soldier:
                    return GetFootSoldierLootTable();
                default:
                    throw new Exception("tried to get loot table for a npc that doesnt exist");
            }
        }

        protected static LootTable GetFootSoldierLootTable()
        {
            return new FootSoldierLootTable();
        }
    }
}
