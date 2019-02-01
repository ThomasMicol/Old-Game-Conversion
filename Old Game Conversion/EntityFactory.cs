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
            context.stateManager.gameStats.StartBattleReport();
            StandardGround.texture = context.Content.Load<Texture2D>("ground_texture");
            Player player = new Player(new Vector2(90, 350), context);
            List<StandardGround> ground = GetGround();
            WinTrigger wt = new WinTrigger();
            LoseTrigger lt = new LoseTrigger();
            gameEntityList.Add(wt);
            gameEntityList.Add(lt);
            gameEntityList.Add(player);
            //gameEntityList.Add(new NPCSpawner(new Vector2(0, 350), true));
            gameEntityList.Add(new NPCSpawner(new Vector2(850, 350), false));
            foreach(StandardGround aground in ground)
            {
                gameEntityList.Add(aground);
            }
            context.stateManager.SetPlayer(player);
            return gameEntityList;
        }

        protected List<Entity> GetShopEntityList()
        {
            List<Entity> shopEntityList = new List<Entity>();
            return shopEntityList;
        }

        protected List<StandardGround> GetGround()
        {
            List<StandardGround> ground = new List<StandardGround>
            {
                new StandardGround(new Vector2(0, 410)),
                new StandardGround(new Vector2(200, 410)),
                new StandardGround(new Vector2(400, 410)),
                new StandardGround(new Vector2(600, 410)),
                new StandardGround(new Vector2(800, 410))
            };
            return ground;
        }
        
    }
}
