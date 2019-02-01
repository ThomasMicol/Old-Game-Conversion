using System;
using System.Collections.Generic;

namespace Old_Game_Conversion.Game_Items
{
    class GameStats
    {
        public BattleReport currentBattle;
        protected List<BattleReport> battleHistory;
        protected List<InventoryElement> inventory; // tuple<ItemIDEnum, item count>
        protected List<SkillElement> skillExp; // tuple<SkillIDEnum, exp count>
        protected StateManager context;

        public GameStats(StateManager aContext)
        {
            battleHistory = new List<BattleReport>();
            inventory = new List<InventoryElement>();
            skillExp = new List<SkillElement>();
            context = aContext;
        }

        public int GetItemAmount(ItemEnum itemType)
        {
            foreach(InventoryElement item in inventory)
            {
                if(item.item == itemType)
                {
                    return item.amount;
                }
            }
            return 0;
        }

        public void StartBattleReport()
        {
            if (currentBattle == null)
            {
                currentBattle = new BattleReport();
            }
            else
                throw new Exception("tried to start a battle report while there was already one in progress");
            
        }

        public void EndBattleReport()
        {
            EvaluateBattleReport();
            currentBattle = null;
        }

        public void AddBattleExperience(SkillEnum aSkill, int expAmount)
        {
            if(currentBattle != null)
            {
                currentBattle.AddExprienceGained(aSkill, expAmount);
                AddExprienceGained(aSkill, expAmount);
            }
            else
            {
                throw new Exception("tried to add battle damage when no battle is happening");
            }
        }

        protected void EvaluateBattleReport()
        {
            foreach(SkillElement expGain in currentBattle.GetExperienceGained())
            {
                AddExprienceGained(expGain.skill, expGain.expAmount);
            }
            foreach (InventoryElement itemGain in currentBattle.GetItemsGained())
            {
                AddItemsGained(itemGain.item, itemGain.amount);
            }
        }

        protected void AddExprienceGained(SkillEnum aSkill, int expAmount)
        {
            foreach(SkillElement skillElement in skillExp)
            {
                if (skillElement.skill == aSkill)
                {
                    skillElement.expAmount += expAmount;
                    return;
                }
            }
            skillExp.Add(new SkillElement(aSkill, expAmount));

        }

        protected void AddItemsGained(ItemEnum aItem, int amountGained)
        {
            foreach(InventoryElement invElement in inventory)
            {
                if (invElement.item == aItem)
                {
                    invElement.amount += amountGained;
                    return;
                }
            }
            inventory.Add(new InventoryElement(aItem, amountGained));
        }

    }
}