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

        public Entity GetNPC(NPCTypeEnum type, bool isFriendly, Game1 context)
        {
            switch (type)
            {
                case NPCTypeEnum.foot_soldier:
                    FootSoldier.enemyTexture = context.Content.Load<Texture2D>("enemy");
                    FootSoldier.friendlyTexture = context.Content.Load<Texture2D>("friendly");
                    return new FootSoldier(isFriendly);
                default:
                    throw new Exception("tried to spawn a entity which doesnt exist.");
            }
                

        }
    }
}
