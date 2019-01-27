using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class Button : GuiElement
    {
        protected int height;
        protected int width;
        protected GuiElementType elementType = GuiElementType.button;
        protected Rectangle sourceRectangle;

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(context.texture, sourceRectangle, Color.Aquamarine);
            if(text != "")
            {
                context.spriteBatch.DrawString(context.font, text, position, textColor);
            }
        }

        public override bool Intersects(MouseState mouseState)
        {
            Point topLeft, topRight, btmLeft, btmRight;
            topLeft = new Point((int)position.X, (int)position.Y);
            topRight = new Point(topLeft.X + width, topLeft.Y);
            btmLeft = new Point(topLeft.X, topLeft.Y + height);
            btmRight = new Point(btmLeft.X + width, btmLeft.Y);
            if(mouseState.X >= topLeft.X && mouseState.X <= topRight.X)
            {
                if(mouseState.Y >= topLeft.Y && mouseState.Y <= btmRight.Y)
                {
                    return true;
                }
            }
            return false;
        }

        protected Rectangle CalculateSourceRectangle()
        {
            int x = Int32.Parse(position.X.ToString());
            int y = Int32.Parse(position.Y.ToString());
            Rectangle srcRect = new Rectangle(x, y, width, height);
            return srcRect;
        }
    }
}
