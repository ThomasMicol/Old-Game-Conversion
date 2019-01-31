using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Old_Game_Conversion.Game_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class GameInteractionSet : InteractionSet
    {
        protected ArrowTrajectory arrowTrajectory = new ArrowTrajectory();

        public GameInteractionSet()
        {
            
            guiElements = new List<GuiElement>()
            {
                new CurrencyLabel (new Vector2(60, 50), Color.Black)
            };
        }

        public override List<GuiElement> GetGUIelements()
        {
            return guiElements;
        }

        public override void CheckInteractions(Game1 game)
        {
            arrowTrajectory.Context = game; 
            if (!CheckLastButtonPressed(Keys.Space) && Keyboard.GetState().IsKeyDown(Keys.Space))
                game.stateManager.ChangeState(StateEnum.MenuState);
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                if (arrowTrajectory.GetInitialMouseStateIsSet() == true)
                {
                    arrowTrajectory.SetFinalMouseState(Mouse.GetState());
                    game.stateManager.GetPlayer().Fire(arrowTrajectory);
                    arrowTrajectory.Clear();
                }
            }
            else if(arrowTrajectory.GetInitialMouseStateIsSet() == false)
            {
                arrowTrajectory.SetInitialMouseState(Mouse.GetState());
            }
            base.CheckInteractions(game);
            SetLastButtonPressed(Keyboard.GetState());
        }
    }
}
