using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Old_Game_Conversion.Game_Items
{
    class ParticleEmitter
    {
        protected List<Particle> particles;
        protected Particle[] particleSet;
        protected Vector2 position;
        protected int particleAmount;
        protected Vector2 particleVelocityMin;
        protected Vector2 particleVelocityMax;
        protected Timer timer;
        protected int emissionCounter;

        public ParticleEmitter(Vector2 aPosition, int aParticleAmount, Vector2 aParticleVelocityMin, Vector2 aParticleVelocityMax, params Particle[] aParticleSet)
        {
            particles = new List<Particle>();
            particleSet = aParticleSet;
            position = aPosition;
            particleAmount = aParticleAmount;
            particleVelocityMin = aParticleVelocityMin;
            particleVelocityMax = aParticleVelocityMax;
            emissionCounter = 0;
            timer = new Timer(500);
            timer.AutoReset = true;
        }

        public void Draw(GameTime gameTime, Game1 context)
        {
            foreach(Particle aPart in particles)
            {
                aPart.Draw(gameTime, context);
            }
        }

        public void Update(GameTime gameTime, Game1 context)
        {
            if(emissionCounter > particleAmount)
            {
                timer.AutoReset = false;
            }
            foreach (Particle aPart in particles)
            {
                aPart.Update(gameTime, context);
            }
        }
    }   
}
