using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Old_Game_Conversion.Game_Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Game_Conversion
{
    class StateManager
    {
        protected InteractionFactory interactionFactory;
        protected EntityFactory entityFactory;
        protected Game1 context;
        protected StateEnum state;
        protected InteractionSet interactionSet;
        protected List<Entity> stateEntities;
        public GameStats gameStats;
        protected static Player player;
        protected bool debugMode;

        public StateManager(Game1 game, bool debugOption)
        {
            gameStats = new GameStats(this);
            interactionFactory = new InteractionFactory();
            entityFactory = new EntityFactory();
            interactionSet = GetStateInteractions();
            context = game;
            ChangeState(StateEnum.MenuState);
            debugMode = debugOption;
        }


        public void ChangeState(StateEnum aState)
        {
            state = aState;
            interactionSet = GetStateInteractions();
            stateEntities = entityFactory.GetStateEntities(state, context);

        }

        public InteractionSet GetStateInteractions()
        {
            return interactionFactory.GetInteractionSet(state);
        }

        public void CheckInteractions()
        {
            interactionSet.CheckInteractions(context);
        }

        public void RenderState(GameTime gameTime)
        {
            
            if(debugMode == true)
            {
                System.Diagnostics.Debug.WriteLine(Mouse.GetState().Position);
            }
            foreach(GuiElement element in interactionSet.GetGUIelements())
            {
                element.Draw(gameTime, context);
                //if(element.GetType() == GuiElementType.label)
                //{
                //    context.spriteBatch.DrawString(context.font, element.GetText(), element.GetPosition(), element.GetColor());
                //}
                
            }
            foreach(Entity aEntity in stateEntities)
            {
                aEntity.Draw(gameTime, context);
            }
        }

        public void Update(GameTime gameTime, Game1 context)
        {
            foreach(Entity aEntity in stateEntities.ToList())
            {
                Rectangle entityMask = new Rectangle(new Point((int)Math.Round(aEntity.GetPosition().X, 0), (int)Math.Round(aEntity.GetPosition().Y, 0)), new Point(1, 1));
                if (!context.Window.ClientBounds.Intersects(entityMask) && aEntity.GetType().ToString() == "Arrow")
                {
                    stateEntities.Remove(aEntity);
                }
                else
                {
                    aEntity.Update(gameTime, context);
                }
            }
            foreach (GuiElement element in interactionSet.GetGUIelements())
            {
                element.Update(gameTime, context);
            }
        }

        public GameStats GetStats()
        {
            return gameStats;
        }

        public void AddEntity(Entity aEntity)
        {
            stateEntities.Add(aEntity);
        }

        public void RemoveEntity(Entity aEntity)
        {
            stateEntities.Remove(aEntity);
        }

        public void AddGuiElement(GuiElement aElement)
        {
            interactionSet.SetGuiElement(aElement);
        }

        public Player GetPlayer() { return player; }
        public void SetPlayer(Player aPlayer) { player = aPlayer; }
        public List<Entity> GetEntities() { return stateEntities; }
        public void AddStats(StatEnum statType, int alterable) { gameStats.AddStats(statType, alterable); }
        public void RemoveStats(StatEnum statType, int alterable) { gameStats.RemoveStats(statType, alterable); }

        public void RemoveSpawners()
        {
            foreach(Entity aEnt in stateEntities.ToList())
            {
                if(aEnt.GetType() == GameEntitiesEnum.NPCspawner)
                {
                    stateEntities.Remove(aEnt);
                }
            }
        }

        public List<Entity> GetSpecificEntities(params GameEntitiesEnum[] entTypes)
        {
            List<Entity> entList = new List<Entity>();
            foreach(Entity aEnt in stateEntities)
            {
                foreach(GameEntitiesEnum aType in entTypes)
                {
                    if(aEnt.GetType() == aType)
                    {
                        entList.Add(aEnt);
                    }
                }
            }
            return entList;
        }
    }
}
