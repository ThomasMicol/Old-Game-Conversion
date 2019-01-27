using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class InteractionSet
    {
        protected List<GuiElement> guiElements;
        protected static List<string> lastButtonPressed = new List<string>();

        public virtual List<GuiElement> GetGUIelements()
        {
            return guiElements;
        }

        public virtual void CheckInteractions(Game1 game)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                foreach (GuiElement element in GetGUIelements())
                {
                    if (element.GetType() == GuiElementType.button && element.Intersects(Mouse.GetState()))
                    {
                        element.Interact(game);
                    }
                }
            }

            if (!CheckLastButtonPressed(Keys.Escape) && Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
            
        }

        public virtual bool SinglePress(Keys keytocheck)
        {
            if (CheckLastButtonPressed(keytocheck) || lastButtonPressed.Count == 0)
                return false;
            else
                return true;
        }

        protected virtual bool CheckLastButtonPressed(Keys keyStroke)
        {
            foreach(string aKey  in lastButtonPressed)
            {
                if (aKey == keyStroke.ToString())
                {
                    return true;
                }
                //foreach (Keys aStroke in keyStroke)
                //{
                //    if(aKey == aStroke.ToString())
                //    {
                //        return true;
                //    }

                //}
            }
            return false;
        }

        protected virtual void SetLastButtonPressed(KeyboardState keyboardState)
        {
            lastButtonPressed.Clear();
            foreach(Keys aKey in keyboardState.GetPressedKeys())
            {
                lastButtonPressed.Add(aKey.ToString());
            }
        }
    }

}
