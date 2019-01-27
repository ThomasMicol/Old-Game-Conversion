using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Old_Game_Conversion.Game_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class EntityFactory
    {

        protected Game1 context;

        public List<Entity> GetStateEntities(StateEnum state, Game1 aContext)
        {
            context = aContext;
            switch(state)
            {
                case StateEnum.MenuState:
                    return GetMenuEntityList();
                case StateEnum.GameState:
                    return GetGameEntityList();
                case StateEnum.ShopState:
                    return GetShopEntityList();
                default:
                    List<Entity> emptyEntityList = new List<Entity>();
                    return emptyEntityList;
            }
        }

        protected List<Entity> GetMenuEntityList()
        {
            List<Entity> menuEntityList = new List<Entity>();
            return menuEntityList;
        }

        protected List<Entity> GetGameEntityList()
        {
            List<Entity> gameEntityList = new List<Entity>();
            Player player = new Player(new Vector2(90, 350), context);
            gameEntityList.Add(player);
            context.stateManager.SetPlayer(player);
            return gameEntityList;
        }

        protected List<Entity> GetShopEntityList()
        {
            List<Entity> shopEntityList = new List<Entity>();
            return shopEntityList;
        }
    }
}
