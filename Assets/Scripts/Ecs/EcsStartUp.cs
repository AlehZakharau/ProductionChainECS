using Ecs.Fabrics;
using Leopotam.Ecs;
using UnityEngine;
using UnityTemplateProjects;
using VContainer.Unity;

namespace Ecs
{
    public class EcsStartUp : IStartable
    {
        private readonly EcsWorld world;
        private readonly IBuildingConstructor buildingConstructor;
        private EcsSystems systems;
        
        public EcsStartUp(EcsWorld world, IBuildingConstructor buildingConstructor)
        {
            this.world = world;
            this.buildingConstructor = buildingConstructor;
        }
        public void Start()
        {
            var dataManager = new DataManager();
            var gameDataBase = new GameDataBase();
            

            systems = new EcsSystems(world);
            
            systems
                .Inject(dataManager)
                .Inject(gameDataBase)
                
                .Init();
            
            buildingConstructor.CreateBuildings();
            Debug.Log($"CreateWorld {world.IsAlive().ToString()}");
        }
    }
}