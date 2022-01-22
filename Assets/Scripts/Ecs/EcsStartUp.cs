using Leopotam.Ecs;
using UnityEngine;
using UnityTemplateProjects;
using VContainer.Unity;

namespace Ecs
{
    public class EcsStartUp : IStartable
    {
        private readonly EcsWorld world;
        private EcsSystems systems;
        
        public EcsStartUp(EcsWorld world)
        {
            this.world = world;
        }
        public void Start()
        {
            systems = new EcsSystems(world);

            var dataManager = new DataManager();
            var gameDataBase = new GameDataBase();
            
            systems
                .Inject(dataManager)
                .Inject(gameDataBase)
                
                .Init();
            Debug.Log($"CreateWorld {world.IsAlive().ToString()}");
        }
    }
}