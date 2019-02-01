using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class BattleReport
    {
        public bool hasBeenEvaluated;
        public List<InventoryElement> lootGained;
        public List<SkillElement> expGained;

        public BattleReport()
        {
            hasBeenEvaluated = false;
            lootGained = new List<InventoryElement>();
            expGained = new List<SkillElement>();
        }

        public void EnemyKilled(NPCEntity aEnt)
        {
            foreach(InventoryElement roll in aEnt.RollLoot())
            {
                AddLootGained(roll.item, roll.amount);
            }
        }

        public List<SkillElement> GetExperienceGained()
        {
            return expGained;
        }

        public List<InventoryElement> GetItemsGained()
        {
            return lootGained;
        }

        public void AddExprienceGained(SkillEnum aSkill, int expAmount)
        {
            foreach (SkillElement skillElement in expGained)
            {
                if (skillElement.skill == aSkill)
                {
                    skillElement.expAmount += expAmount;
                    return;
                }
            }
            expGained.Add(new SkillElement(aSkill, expAmount));

        }

        protected void AddLootGained(ItemEnum aItem, int amountGained)
        {
            foreach (InventoryElement lootEntry in lootGained)
            {
                if (lootEntry.item == aItem)
                {
                    lootEntry.amount += amountGained;
                    return;
                }
            }
            lootGained.Add(new InventoryElement(aItem, amountGained));
        }
    }
}
