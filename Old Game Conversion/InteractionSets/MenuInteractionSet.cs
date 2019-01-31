using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class MenuInteractionSet : InteractionSet
    {
        public override List<GuiElement> GetGUIelements()
        {
            List<GuiElement> guiElements = new List<GuiElement>
            {
                new StartButton("Start the game", new Vector2(100, 100), Color.Red, 50, 100),
                new OptionsButton("Options", new Vector2(100, 200), Color.Red, 50, 100),
                new HelpButton("Help", new Vector2(100, 300), Color.Red, 50, 100),
                new ExitButton("Exit", new Vector2(100, 400), Color.Red, 50, 100)
            };

            

            return guiElements;
        }


        public override void CheckInteractions(Game1 game)
        {
            if (!CheckLastButtonPressed(Keys.Space) && Keyboard.GetState().IsKeyDown(Keys.Space))
                game.stateManager.ChangeState(StateEnum.GameState);
            base.CheckInteractions(game);
            SetLastButtonPressed(Keyboard.GetState());
        }
        
    }
}
