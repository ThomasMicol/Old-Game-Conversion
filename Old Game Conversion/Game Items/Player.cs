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
        protected int shotFlatPower = 12;
        protected ArcherArm myArm;

        public Player(Vector2 aPositon, Game1 aContext)
        {
            context = aContext;
            type = GameEntitiesEnum.player;
            texture = aContext.Content.Load<Texture2D>("Player");
            Arrow.texture = aContext.Content.Load<Texture2D>("arrow");
            position = aPositon;
            myArm = new ArcherArm(this, context);
        }

        public override void Draw(GameTime gameTime, Game1 context)
        {
            context.spriteBatch.Draw(texture, position, Color.Red);
            myArm.Draw(gameTime, context);
            base.Draw(gameTime, context);
        }

        public override void Update(GameTime gameTime, Game1 context)
        {
            myArm.Update(gameTime, context);
            base.Update(gameTime, context);
        }

        public void Fire(ArrowTrajectory aTraj)
        {
            float shotPower = CalcShotPower(aTraj.GetShotPower());
            context.stateManager.AddEntity(new Arrow(new Vector2(position.X + 10, position.Y + 30), 90, shotPower, aTraj.GetPowerSplit()));
        }

        protected float CalcShotPower(float powerMult)
        {
            return shotFlatPower * powerMult;
        }
    }
}
