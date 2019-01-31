using System.Collections.Generic;

namespace Old_Game_Conversion.Game_Items
{
    class GameStats
    {
        protected float currency = 0;
        public BattleReport currentBattle;
        protected List<BattleReport> battleHistory;
        protected StateManager context;

        public GameStats(StateManager aContext)
        {
            battleHistory = new List<BattleReport>();
            context = aContext;
        }

        public void AddStats(StatEnum statType, int alterable)
        {
            switch (statType)
            {
                case StatEnum.currency:
                    currency += alterable;
                    break;
                default:
                    throw new System.Exception("tried to add stats to something that doesnt exist");
            }
        }

        public void RemoveStats(StatEnum statType, int alterable)
        {

        }

        public float GetCurrency()
        {
            return currency;
        }

        public void StartBattleReport()
        {
            currentBattle = new BattleReport();
        }

        public void EndBattleReport()
        {

        }


    }
}