using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Old_Game_Conversion.Menu_Items;
using Old_Game_Conversion.Game_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Loot_State_Items
{
    class LootScreenFrame : Frame
    {
        protected bool reportUpdated = false;
        protected BattleReport myReport;
        protected GameStats gameStats;

        public LootScreenFrame(Vector2 aPosition, Game1 aContext)
        {
            position = aPosition;
            context = aContext;
            if (texture == null)
            {
                texture = context.Content.Load<Texture2D>("loot_frame");
            }
            frameElements = new List<GuiElement>();

            
        }

        public override void Update(GameTime gameTime, Game1 context)
        {

            if (reportUpdated == false)
                myReport = context.stateManager.gameStats.GetLastReport();
                gameStats = context.stateManager.gameStats;
                SetFrameElements();
                reportUpdated = true;
            
            base.Update(gameTime, context);
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), Color.White); 
            base.Draw(gameTime, context);
        }

        protected override void SetFrameElements()
        {
            frameElements.Add(new LootVictoryLabel(myReport, gameStats, context.font));
            frameElements.Add(new ExpGainedBars(myReport, gameStats, context));
            frameElements.Add(new LootGainedBoxes(myReport, gameStats, context));
            //frameElements.Add(new ContinueButton());
            foreach (GuiElement element in frameElements)
            {
                element.SetPosition(GetFrameBounds());
            }

        }
    }
}
