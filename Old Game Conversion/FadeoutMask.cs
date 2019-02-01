using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class FadeoutMask : GuiElement
    {
        protected float maskAlpha = 0.00f;
        protected StateManager context;
        protected Texture2D texture;
        protected bool fullyFaded;
        protected StateEnum fadingToState;

        public bool GetFullyFaded() { return fullyFaded; }

        public FadeoutMask(StateManager aContext, StateEnum aState)
        {
            context = aContext;
            fadingToState = aState;
            texture = context.GetContext().Content.Load<Texture2D>("fade_mask");
            position = new Vector2(0, 0);
            elementType = GuiElementType.mask;
            fullyFaded = false;
            
        }

        public override void Update(GameTime gameTime, Game1 context)
        {
            if(maskAlpha < 1)
            {
                maskAlpha += 0.004f;
            }
            else
            {
                fullyFaded = true;
            }
            if (fullyFaded == true)
            {
                context.stateManager.ChangeState(fadingToState);
            }
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 999, 999), null, Color.White * maskAlpha, 0, new Vector2(1,1), SpriteEffects.None, 0.5f);
        }
    }
}
