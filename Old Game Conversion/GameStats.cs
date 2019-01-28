namespace Old_Game_Conversion.Game_Items
{
    class GameStats
    {
        protected float currency = 0;

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

    }
}