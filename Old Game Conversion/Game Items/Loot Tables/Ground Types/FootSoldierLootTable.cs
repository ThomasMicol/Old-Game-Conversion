using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items.Loot_Tables.Ground_Types
{
    class FootSoldierLootTable : LootTable
    {
        public FootSoldierLootTable()
        {
            rollTable = new List<Tuple<float, float, ItemEnum, int, int>>
            {
                new Tuple<float, float, ItemEnum, int, int>(0.0f, 0.1f, ItemEnum.arrow_shafts, 10, 20),
                new Tuple<float, float, ItemEnum, int, int>(0.1f, 0.2f, ItemEnum.arrow_heads, 5, 10),
                new Tuple<float, float, ItemEnum, int, int>(0.2f, 0.4f, ItemEnum.gold, 5, 10)
            };

            rolls = 2;
        }
    }

}
