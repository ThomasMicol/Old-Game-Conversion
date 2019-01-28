using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class StandardGround : Entity
    {
        new public static Texture2D texture;

        public StandardGround(Vector2 aPosition)
        {
            type = GameEntitiesEnum.ground;
            position = aPosition;
            SetCollisionMask(texture);
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width * 2, texture.Height * 2), null, Color.White);
            base.Draw(gameTime, context);
        }

        public override void SetCollisionMask(Texture2D aText)
        {
            Rectangle colMask = new Rectangle((int)position.X, (int)position.Y + 25, aText.Width * 2 , aText.Height * 2);
            collisionMask = colMask;
        }
    }
}
