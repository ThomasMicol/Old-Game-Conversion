using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Old_Game_Conversion
{
    class Label : GuiElement
    {

        protected GuiElementType elementType = GuiElementType.label;
        
        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.DrawString(context.font, text, position, textColor);
            base.Draw(gameTime, context);
        }
    }
}
