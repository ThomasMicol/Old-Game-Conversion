using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class VictoryLabel : Label
    {
        static Texture2D texture;
        protected int timeSpawned;
        protected bool fadeOutStarted;
        protected ParticleEmitter particleEmit;

        public VictoryLabel(Vector2 aLocation, Game1 aContext)
        {
            position = aLocation;
            texture = aContext.Content.Load<Texture2D>("victory_label");
            particleEmit = new ParticleEmitter(position, 10, new Vector2(-5, 1), new Vector2(5, 10), new Particle());
            fadeOutStarted = false;
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            
            context.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), null, Color.White, 0, new Vector2(1,1), SpriteEffects.None, 0f);
            particleEmit.Draw(gameTime, context);
        }

        public override void Update(GameTime gameTime, Game1 context)
        {
            if (timeSpawned == 0)
            {
                timeSpawned = gameTime.TotalGameTime.Seconds;
            }
            if(timeSpawned + 6 == gameTime.TotalGameTime.Seconds && !fadeOutStarted)
            {
                context.stateManager.FadeOut(StateEnum.LootState);
                fadeOutStarted = true;
            }
            particleEmit.Update(gameTime, context);
        }
    }
}
