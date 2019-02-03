using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Menu_Items
{
    class Frame : GuiElement
    {
        protected Texture2D texture;
        protected List<GuiElement> frameElements;

        public void SetTexture(Texture2D aText) { texture = aText; }
        public Texture2D GetTexture() { return texture; }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            if(frameElements != null)
            {
                foreach(GuiElement element in frameElements)
                {
                    element.Draw(gameTime, context);
                }
            }
            base.Draw(gameTime, context);
        }

        public override void Update(GameTime gameTime, Game1 context)
        {
            if (frameElements != null)
            {
                foreach (GuiElement element in frameElements)
                {
                    element.Update(gameTime, context);
                }
            }
            base.Update(gameTime, context);
        }

        protected virtual void SetFrameElements() { }

        protected virtual Rectangle GetFrameBounds()
        {
            Rectangle rect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            return rect;
        }

    }
}
