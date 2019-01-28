using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Old_Game_Conversion.Game_Items;
using System;

namespace Old_Game_Conversion
{
    class NPCSpawner : Entity
    {
        protected float lastSpawn;
        protected NPCFactory npcFactory;
        protected bool isFriendly;
        protected bool spawnPacket;
        protected Game1 context;
        
        public NPCSpawner(Vector2 aPosition, SpawnPacket spawnPacket)
        {
            position = aPosition;
            lastSpawn = 0;
            type = GameEntitiesEnum.NPCspawner;
            npcFactory = new NPCFactory();
        }

        public NPCSpawner(Vector2 aPosition)
        {
            position = aPosition;
            lastSpawn = 0;
            type = GameEntitiesEnum.NPCspawner;
            npcFactory = new NPCFactory();
        }

        public override void Update(GameTime gameTime, Game1 aContext)
        {
            context = aContext;
            if (gameTime.TotalGameTime.TotalSeconds - lastSpawn >= 5) 
            {
                Spawn(NPCTypeEnum.foot_soldier);
                lastSpawn = (float)gameTime.TotalGameTime.TotalSeconds;
            }
            base.Update(gameTime, context);
        }

        protected void Spawn(params NPCTypeEnum[] spawns)
        {
            foreach (NPCTypeEnum spawn in spawns)
            {
                Entity npc = npcFactory.GetNPC(spawn, context);
                npc.SetPosition(new Vector2(position.X, position.Y));
                context.stateManager.AddEntity(npc);
            }
        }
    }
}