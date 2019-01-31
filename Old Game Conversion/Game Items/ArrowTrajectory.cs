using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class ArrowTrajectory
    {
        protected MouseState initialMouseState;
        protected MouseState finalMouseState;
        protected bool initialStateSet = false;
        protected bool finalStateSet = false;
        public Game1 Context { get; set; }

        public void SetInitialMouseState(MouseState aState)
        {
            initialMouseState = aState;
            initialStateSet = true;
        }
        public MouseState GetInitialMouseState() { return initialMouseState; }
        public bool GetInitialMouseStateIsSet() { return initialStateSet; }

        public void SetFinalMouseState(MouseState aState)
        {
            finalMouseState = aState;
            finalStateSet = true;
        }

        public MouseState GetFinalMouseState() { return finalMouseState; }
        public bool GetFinalMouseStateIsSet() { return finalStateSet; }

        public void Clear()
        {
            initialStateSet = false;
            finalStateSet = false;

        }

        public Vector2 GetPowerSplit()
        {
            Vector2 playerPosition = Context.stateManager.GetPlayer().GetPosition();
            Point startPoint = GetInitialMouseState().Position;
            Point endPoint = GetFinalMouseState().Position;
            float adjacent = startPoint.X - endPoint.X;
            float opposite = startPoint.Y - endPoint.Y;
            if(opposite > 0 )
            {
                opposite = 0;
            }
            System.Diagnostics.Debug.WriteLine("Adjacent: " + adjacent.ToString() + " - Opposite: " + opposite.ToString());
            float hypotenuse = (float)Math.Sqrt(Math.Pow((double)opposite, 2) + (double)Math.Pow(adjacent, 2));
            double oppositeOverAdjacent = adjacent / hypotenuse;
            double angle = Math.Acos(oppositeOverAdjacent) * (180/Math.PI);
            double ratio = angle / 90;
            if(ratio > 1)
            {
                ratio = 1;
            }
            if (ratio < 0)
            {
                ratio = 0;
            }
            Vector2 split = new Vector2(1 - (float)ratio, (float)ratio);
            return split;
        }

        public float GetShotPower()
        {
            Point startPoint = GetInitialMouseState().Position;
            Point endPoint = GetFinalMouseState().Position;
            float adjacent = startPoint.X - endPoint.X;
            float opposite = startPoint.Y - endPoint.Y;
            float hypotenuse = (float)Math.Sqrt(Math.Pow((double)opposite, 2) + (double)Math.Pow(adjacent, 2));
            float shotPower = hypotenuse / 200;
            if(shotPower > 1)
            {
                return 1;
            }else
            {
                return shotPower;
            }

        }
    }
}
