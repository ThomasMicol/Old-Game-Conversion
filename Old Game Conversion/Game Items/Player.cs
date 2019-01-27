using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class Player : Entity
    {

        public Player(Vector2 aPositon, Game1 aContext)
        {
            context = aContext;
            texture = aContext.Content.Load<Texture2D>("Player");
            Arrow.texture = aContext.Content.Load<Texture2D>("arrow");
            position = aPositon;
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(texture, position, Color.Red);
            base.Draw(gameTime, context);
        }

        public void Fire()
        {
            context.stateManager.AddEntity(new Arrow(new Vector2(position.X + 10, position.Y + 20), 90, 5));
        }
    }
}
