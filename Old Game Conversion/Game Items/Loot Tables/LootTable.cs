using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    abstract class LootTable
    {
        protected List<Tuple<ItemEnum, int, int>> guaranteedTable;
        protected List<Tuple<float, float, ItemEnum, int, int>> rollTable;
        protected int rolls;

        protected virtual Tuple<ItemEnum, int> Roll()
        {
            double rand = new Random().NextDouble();
            foreach(Tuple<float, float, ItemEnum, int, int> tableEntry in rollTable)
            {
                if(rand >= tableEntry.Item1 && rand <= tableEntry.Item2)
                {
                    int quantity = new Random().Next(tableEntry.Item4, tableEntry.Item5);
                    return new Tuple<ItemEnum, int>(tableEntry.Item3, quantity);
                }
            }
            return new Tuple<ItemEnum, int>(ItemEnum.nothing, 0);
        }

        public virtual List<Tuple<ItemEnum, int>> DoRolls()
        {
            List<Tuple<ItemEnum, int>> rolledItems = new List<Tuple<ItemEnum, int>>();
            for(int i = 0; i <= rolls; i++)
            {
                rolledItems.Add(Roll());
            }
            return rolledItems;
        }
    }
}
