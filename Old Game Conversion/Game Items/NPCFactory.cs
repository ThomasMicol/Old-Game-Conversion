using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion.Game_Items
{
    class NPCFactory
    {
        protected Game1 context;

        public Entity GetNPC(NPCTypeEnum type, Game1 context)
        {
            switch (type)
            {
                case NPCTypeEnum.foot_soldier:
                    FootSoldier.texture = context.Content.Load<Texture2D>("enemy");
                    return new FootSoldier();
                default:
                    throw new Exception("tried to spawn a entity which doesnt exist.");
            }
                

        }
    }
}
