using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Old_Game_Conversion.Game_Items;
using System;

namespace Old_Game_Conversion
{
    abstract class Entity
    {
        protected GameEntitiesEnum type;
        protected Game1 context;
        protected double lastUpdate;
        protected Vector2 position;
        protected int health;
        protected Texture2D texture;
        protected Vector2 velocity;
        protected Rectangle collisionMask;
        //protected double vertVelocity;
        //protected double horizVelocity;
        protected double mass;
        protected bool physics;

        public virtual void SetCollisionMask(Texture2D aText)
        {
            Rectangle colMask = new Rectangle((int)position.X, (int)position.Y, aText.Width, aText.Height);
            collisionMask = colMask;
        }

        public virtual void Draw(GameTime gameTime, Game1 context)
        {

        }

        public virtual void Update(GameTime gameTime, Game1 context)
        {
            lastUpdate = double.Parse(gameTime.TotalGameTime.TotalSeconds.ToString());
        }

        public virtual void SetAllegiance(GameEntitiesEnum allegiance)
        {
            type = allegiance;
        }

        public virtual void AddConnectedEntity(Entity aEntity) { }

        public virtual Vector2 GetPosition() { return position; }
        public virtual void SetPosition(Vector2 aPos) { position = aPos; }
        public virtual Rectangle GetCollisionMask() { return collisionMask; }
        public virtual void ApplyDamage(Entity aProjectile) { }
        public virtual float CalculateDamage() { return float.NaN; }

        protected virtual double GetTimeSinceLastUpdate(GameTime gameTime)
        {
            double timeDiff = double.Parse(gameTime.TotalGameTime.TotalSeconds.ToString());
            timeDiff = timeDiff - lastUpdate;
            return timeDiff;
        }

        protected virtual void ApplyGravity(GameTime gameTime)
        {
            velocity.Y -= (float)mass * (float)0.0982;
        }

        new public GameEntitiesEnum GetType() { return type; }
    }
}