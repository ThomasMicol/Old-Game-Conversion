using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class ExitButton : Button
    {
        public ExitButton(string aText, Vector2 aPosition, Color aColor, int aHeight, int aWidth)
        {
            text = aText;
            position = aPosition;
            textColor = aColor;
            height = aHeight;
            width = aWidth;
            sourceRectangle = CalculateSourceRectangle();
        }

        public override void Interact(Game1 context)
        {
            context.Exit();
        }
    }
}
