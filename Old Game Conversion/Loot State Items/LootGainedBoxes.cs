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
    class LootGainedBoxes : IterableFrameElement
    {
        protected BattleReport myReport;

        public LootGainedBoxes(BattleReport aReport, GameStats aGameStats, Game1 aContext)
        {
            context = aContext;
            myReport = aReport;
            texture = context.Content.Load<Texture2D>("clear");
            SetGainFrameTitle("Loot Gained");
        }

        protected override void SetGainFrameTitle(string aTitle)
        {
            Rectangle aRect = GetFrameBounds();
            int x, y;
            x = (aRect.X + (aRect.Width / 2)) - 200;
            y = (aRect.Y + (aRect.Height / 2)) - 100;
            Vector2 aPosition = new Vector2(0, 0);
            base.SetGainFrameTitle(aTitle, aPosition);
        }


    }
}
