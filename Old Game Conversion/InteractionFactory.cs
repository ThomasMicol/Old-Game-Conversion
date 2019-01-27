using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class InteractionFactory
    {
        public InteractionSet GetInteractionSet(StateEnum state)
        {
            switch (state)
            {
                case StateEnum.MenuState:
                    return new MenuInteractionSet();
                case StateEnum.GameState:
                    return new GameInteractionSet();
                case StateEnum.ShopState:
                    return new ShopInteractionSet();
                default:
                    return new MenuInteractionSet();
            }
            
        }
    }
}
