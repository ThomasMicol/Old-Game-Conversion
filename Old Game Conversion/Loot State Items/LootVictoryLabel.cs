using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Old_Game_Conversion.Game_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Loot_State_Items
{
    class LootVictoryLabel : Label
    {
        protected BattleReport myReport;
        protected SpriteFont font;

        public LootVictoryLabel(BattleReport report, GameStats aGameStats, SpriteFont aFont)
        {
            myReport = report;
            font = aFont;
            text = GenerateText();
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            font = context.font;
            context.spriteBatch.DrawString(font, text, position, Color.Black);
            base.Draw(gameTime, context);
        }

        public override void SetPosition(Rectangle frameBounds)
        {
            position = new Vector2((frameBounds.Width / 2) - (font.MeasureString(text).X / 2), frameBounds.Y + 40);
        }

        protected string GenerateText()
        {
            return "We have won the day.";
        }
    }
}
