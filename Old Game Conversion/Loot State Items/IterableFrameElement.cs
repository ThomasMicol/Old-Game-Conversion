
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Old_Game_Conversion.Menu_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Loot_State_Items
{
    class IterableFrameElement : Frame
    {
        new protected List<BattleGainIterable> frameElements;
        protected Label gainFrameTitle;

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(texture, GetFrameBounds(), Color.White);
            gainFrameTitle.Draw(gameTime, context);
            base.Draw(gameTime, context);
        }

        public override void Update(GameTime gameTime, Game1 context)
        {
            base.Update(gameTime, context);
        }

        protected virtual void SetGainFrameTitle(string aTitle)
        {
            
            
        }

        protected virtual void SetGainFrameTitle(string aTitle, Vector2 aPosition)
        {
            gainFrameTitle = new Label();
            gainFrameTitle.SetPosition(aPosition);
            gainFrameTitle.SetText(aTitle);
        }

    }
}
