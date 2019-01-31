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
        public int currencyGained;

        public BattleReport()
        {
            hasBeenEvaluated = false;
            currencyGained = 0;
        }

        public void EnemyKilled(NPCEntity aEnt)
        {
            currencyGained += aEnt.GetKillWorth();
        }
    }
}
