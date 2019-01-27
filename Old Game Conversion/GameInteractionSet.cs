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
        public override List<GuiElement> GetGUIelements()
        {
            List<GuiElement> guiElements = new List<GuiElement>
            {
                new CurrencyLabel (new Vector2(60, 50), Color.Black)
            };
            return guiElements;
        }

        public override void CheckInteractions(Game1 game)
        {
            if (!CheckLastButtonPressed(Keys.Space) && Keyboard.GetState().IsKeyDown(Keys.Space))
                game.stateManager.ChangeState(StateEnum.MenuState);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                game.stateManager.GetPlayer().Fire();
            base.CheckInteractions(game);
            SetLastButtonPressed(Keyboard.GetState());
        }
    }
}
