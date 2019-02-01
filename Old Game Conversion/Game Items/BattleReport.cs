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
        public List<Tuple<ItemEnum, int>> lootGained;
        public List<Tuple<SkillEnum, int>> expGained;

        public BattleReport()
        {
            hasBeenEvaluated = false;
            lootGained = new List<Tuple<ItemEnum, int>>();
            expGained = new List<Tuple<SkillEnum, int>>();
        }

        public void EnemyKilled(NPCEntity aEnt)
        {
            foreach(Tuple<ItemEnum, int> roll in aEnt.RollLoot())
            {
                lootGained.Add(roll);
            }
        }
    }
}
