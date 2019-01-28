using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class Arrow : Entity
    {
        new public static Texture2D texture;
        protected int bearing;
        protected Vector2 origin;
        protected float rotation;
        protected float finalRotation;

        public Arrow(Vector2 aPosition, int aBearing, float aVelocity, Vector2 powerSplit)
        {
            position = aPosition;
            bearing = aBearing;
            origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            velocity = new Vector2(aVelocity * powerSplit.X, aVelocity * powerSplit.Y);
            mass = 0.95;
            physics = true;
            type = GameEntitiesEnum.arrow;
            SetCollisionMask(texture);
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            if (physics)
                context.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), null, Color.White, rotation, origin, SpriteEffects.None, 0f);
            else
                context.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), null, Color.White, finalRotation, origin, SpriteEffects.None, 0f);
            base.Draw(gameTime, context);
        }

        public override void Update(GameTime gameTime, Game1 context)
        {
            if (physics)
            {
                ApplyGravity(gameTime);
                rotation = CalculateRotation();
                position.X += velocity.X;
                position.Y -= velocity.Y;
                foreach (Entity aEnt in context.stateManager.GetSpecificEntities(GameEntitiesEnum.ground, GameEntitiesEnum.enemy))
                {
                    if (aEnt.GetCollisionMask().Intersects(GetCollisionMask()))
                    {
                        finalRotation = CalculateRotation();
                        velocity = new Vector2(0, 0);
                        physics = false;
                    }
                }
            }
            else
                base.Update(gameTime, context);
        }

        protected float CalculateRotation()
        {
            float opposite, adjacent, hypotenuse;
            opposite = velocity.X;
            adjacent = velocity.Y;
            hypotenuse = (float)Math.Sqrt(Math.Pow((double)opposite, 2) + (double)Math.Pow(adjacent, 2));
            float AdjOverHypo = adjacent / hypotenuse;
            float result = (float)Math.Acos((double)AdjOverHypo);
            return result;
        }

        public override Rectangle GetCollisionMask()
        {
            base.SetCollisionMask(texture);
            return base.GetCollisionMask();

        }
    }
}
