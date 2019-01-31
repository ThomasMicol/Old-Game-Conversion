using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Old_Game_Conversion.Game_Items
{
    class FootSoldier : NPCEntity
    {
        public static Texture2D friendlyTexture;
        public static Texture2D enemyTexture;

        //public FootSoldier(Vector2 aPosition)
        //{
        //    position = aPosition;
        //    physics = true;
        //    velocity = new Vector2(0, 0);
        //    type = GameEntitiesEnum.enemy;
        //    mass = 1;
        //    SetCollisionMask(texture);
        //    isFriendly = true;
        //    System.Diagnostics.Debug.WriteLine("im a foot soldier kill me");
        //}

        public FootSoldier(bool friendly)
        {
            physics = true;
            velocity = new Vector2(0, 0);
            mass = 1;
            health = 100;
            killWorth = 20;
            isFriendly = friendly;
            SetType();
            if (type == GameEntitiesEnum.friendly)
                texture = friendlyTexture;
            else if (type == GameEntitiesEnum.enemy)
                texture = enemyTexture;
            SetCollisionMask(texture);
            System.Diagnostics.Debug.WriteLine("im a foot soldier kill me");
            
        }

        protected void SetType()
        {
            if (isFriendly)
                type = GameEntitiesEnum.friendly;
            else
                type = GameEntitiesEnum.enemy;
        }

        public override void Update(GameTime gameTime, Game1 aContext)
        {
            context = aContext;
            if(health <= 0)
            {
                Die();
            }
            if(physics)
            {
                if(StandingOnSolidGround())
                {
                    velocity.Y = 0;
                    if (type == GameEntitiesEnum.friendly)
                        velocity.X = 2;
                    else
                        velocity.X = -2;
                }
                else
                {
                    ApplyGravity(gameTime);
                }
                position.X += velocity.X;
                position.Y -= velocity.Y;
            }
            foreach(Entity aEnt in connectedEntities)
            {
                Vector2 currentPos = aEnt.GetPosition();
                aEnt.SetPosition(new Vector2(currentPos.X + velocity.X, currentPos.Y - velocity.Y));
            }
                
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), Color.White);
        }

        public override Rectangle GetCollisionMask()
        {
            SetCollisionMask(texture);
            return base.GetCollisionMask();

        }

        public override void SetCollisionMask(Texture2D aText)
        {
            Rectangle colMask = new Rectangle((int)position.X, (int)position.Y + 26, aText.Width, aText.Height -1);
            collisionMask = colMask;
        }

        public override void ApplyDamage(Entity aProjectile)
        {
            float dmgTaken = aProjectile.CalculateDamage();
            health -= (int)Math.Round(dmgTaken, MidpointRounding.AwayFromZero);
        }
        
    }
}
