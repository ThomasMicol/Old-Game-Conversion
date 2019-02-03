using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    abstract class GuiElement
    {
        protected GuiElementType elementType;
        protected Vector2 position;
        protected string text;
        protected Color textColor;

        public GuiElementType GetType()
        {
            return elementType;
        }

        public string GetText()
        {
            return text;
        }

        public Vector2 GetPosition() { return position; }
        public virtual void SetPosition(Vector2 aPosition) { position = aPosition; }
        public virtual void SetPosition(Rectangle frameBounds) { }

        public Color GetColor()
        {
            return textColor;
        }

        public virtual void Draw(GameTime gameTime, Game1 context)
        {

        }

        public virtual void Update(GameTime gameTime, Game1 context)
        {

        }

        public virtual void Interact(Game1 context)
        {

            System.Diagnostics.Debug.WriteLine(Mouse.GetState().Position.ToString());
        }

        public virtual bool Intersects(MouseState mouseState)
        {
            return false;
        }
    }
}
