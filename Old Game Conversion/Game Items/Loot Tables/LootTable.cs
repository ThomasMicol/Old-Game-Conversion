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
        protected Random rand = new Random();
        protected double doubleRoll;
        protected int quantity;
        protected int rolls;

        protected virtual InventoryElement Roll()
        {
            doubleRoll = rand.NextDouble();
            foreach(Tuple<float, float, ItemEnum, int, int> tableEntry in rollTable)
            {
                if(doubleRoll >= tableEntry.Item1 && doubleRoll <= tableEntry.Item2)
                {
                    quantity = rand.Next(tableEntry.Item4, tableEntry.Item5);
                    return new InventoryElement(tableEntry.Item3, quantity);
                }
            }
            return new InventoryElement(ItemEnum.nothing, 0);
        }

        public virtual List<InventoryElement> DoRolls()
        {
            List<InventoryElement> rolledItems = new List<InventoryElement>();
            for(int i = 0; i < rolls; i++)
            {
                rolledItems.Add(Roll());
            }
            foreach(InventoryElement aLoot in GetGuaranteedLoot())
            {
                rolledItems.Add(aLoot);
            }
             return rolledItems;
        }

        protected virtual List<InventoryElement> GetGuaranteedLoot()
        {
            List<InventoryElement> guaranteed = new List<InventoryElement>();
            foreach (Tuple<ItemEnum, int, int> tableEntry in guaranteedTable)
            {
                quantity = rand.Next(tableEntry.Item2, tableEntry.Item3);
                guaranteed.Add(new InventoryElement(tableEntry.Item1, quantity));
            }
            return guaranteed;
        }
    }
}
