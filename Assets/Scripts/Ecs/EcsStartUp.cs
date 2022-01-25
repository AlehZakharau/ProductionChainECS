using System;
using DataBase;
using Ecs.Systems.Manufacture;
using Ecs.Systems.Manufacture.Production;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Fabrics;
using Leopotam.Ecs;
using UnityEngine;
using VContainer.Unity;

namespace Ecs
{
    public class EcsStartUp : IStartable, ITickable, IDisposable
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
                .Add(new ProductionSystem())
                .Add(new ExtractorProductionSystem())
                .Add(new UpgradeSystem())
                
                .Inject(dataManager)
                .Inject(gameDataBase)
                
                .Init();
            
            Debug.Log($"CreateWorld {world.IsAlive().ToString()}");
            buildingConstructor.CreateBuildings();
            world.NewEntity().Get<ResourceComponent>();
        }

        public void Tick()
        {
            systems?.Run();
        }

        public void Dispose()
        {
            if (systems != null)
            {
                systems.Destroy();
                systems = null;
                world.Destroy();
                //world = null;
            }
        }
    }
}