using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class ArcherArm
    {
        protected Vector2 myPosition;
        protected Texture2D myTexture;
        protected float myRotation = 90;
        protected Entity myBody;
        protected Texture2D[] armSprites;
        protected Game1 context;
        protected Vector2 origin;

        public ArcherArm(Entity aBody, Game1 aContext)
        {
            myBody = aBody;
            context = aContext;
            armSprites = GetArmSprites();
            myPosition = aBody.GetPosition();
            myPosition.X += 15;
            myPosition.Y += 25;
            SetTexture(armSprites[0]);
        }

        public void SetTexture(Texture2D aTexture)
        {
            myTexture = aTexture;
            origin = new Vector2(30, 34);
        }

        public void SetRotation(MouseState mouseState)
        {
            float opposite, adjacent, hypotenuse;
            opposite = mouseState.X - myPosition.X;
            adjacent = Math.Abs( mouseState.Y - myPosition.Y);
            hypotenuse = (float)Math.Sqrt(Math.Pow((double)opposite, 2) + (double)Math.Pow(adjacent, 2));
            float AdjOverHypo = adjacent / hypotenuse;
            float result = (float)Math.Acos((double)AdjOverHypo) * (3.27f / (float)Math.PI);
            myRotation = result ;
        }

        public void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(myTexture, new Rectangle((int)myPosition.X, (int)myPosition.Y, myTexture.Width, myTexture.Height), null, Color.White, myRotation, origin, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime, Game1 context)
        {
            SetRotation(Mouse.GetState());
        }

        protected Texture2D[] GetArmSprites()
        {
            Texture2D[] result = new Texture2D[13]
            {
                context.Content.Load<Texture2D>("archer_arm/sprite_00"),
                context.Content.Load<Texture2D>("archer_arm/sprite_01"),
                context.Content.Load<Texture2D>("archer_arm/sprite_02"),
                context.Content.Load<Texture2D>("archer_arm/sprite_03"),
                context.Content.Load<Texture2D>("archer_arm/sprite_04"),
                context.Content.Load<Texture2D>("archer_arm/sprite_05"),
                context.Content.Load<Texture2D>("archer_arm/sprite_06"),
                context.Content.Load<Texture2D>("archer_arm/sprite_07"),
                context.Content.Load<Texture2D>("archer_arm/sprite_08"),
                context.Content.Load<Texture2D>("archer_arm/sprite_09"),
                context.Content.Load<Texture2D>("archer_arm/sprite_10"),
                context.Content.Load<Texture2D>("archer_arm/sprite_11"),
                context.Content.Load<Texture2D>("archer_arm/sprite_12")
            };
            return result;
        }
    }
}
