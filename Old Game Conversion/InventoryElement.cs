using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class InventoryElement
    {
        public ItemEnum item { get; set; }
        public int amount { get; set; }

        public InventoryElement(ItemEnum aItem, int anAmount)
        {
            item = aItem;
            amount = anAmount;
        }
    }
}
