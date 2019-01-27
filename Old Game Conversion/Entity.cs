using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Old_Game_Conversion
{
    class Entity
    {
        protected Game1 context;
        protected double lastUpdate;
        protected Vector2 position;
        protected int health;
        protected Texture2D texture;
        protected Vector2 velocity;
        //protected double vertVelocity;
        //protected double horizVelocity;
        protected double mass;
        protected bool physics;

        public virtual void Draw(GameTime gameTime, Game1 context)
        {
            
        }

        public virtual void Update(GameTime gameTime, Game1 context)
        {
            lastUpdate = double.Parse(gameTime.TotalGameTime.TotalSeconds.ToString());
        }

        public virtual Vector2 GetPosition() { return position; }

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
    }
}