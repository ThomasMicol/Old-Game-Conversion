using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class CurrencyLabel : Label
    {
        public CurrencyLabel(Vector2 aPosition, Color aColor)
        {
            position = aPosition;
            textColor = aColor;
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            GameStats stat = context.stateManager.GetStats();
            text = "Gold Coins: " + stat.GetCurrency().ToString();
            base.Draw(gameTime, context);
        }

    }
}
