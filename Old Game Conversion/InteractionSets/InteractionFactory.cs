using Old_Game_Conversion.InteractionSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class InteractionFactory
    {
        protected Game1 context;

        public InteractionSet GetInteractionSet(StateEnum state, Game1 aContext)
        {
            context = aContext;
            switch (state)
            {
                case StateEnum.MenuState:
                    return new MenuInteractionSet();
                case StateEnum.GameState:
                    return new GameInteractionSet();
                case StateEnum.ShopState:
                    return new ShopInteractionSet();
                case StateEnum.DeathState:
                    return new DeathStateInteractionSet();
                case StateEnum.LootState:
                    return new LootStateInteractionSet(context);
                default:
                    return new MenuInteractionSet();
            }
            
        }
    }
}
