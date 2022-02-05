using System;
using DataBase;
using Ecs.Systems;
using Ecs.Systems.Manufacture;
using Ecs.Systems.Manufacture.Production;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Pool;
using Ecs.Systems.Pool.Components;
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
        private readonly ITileConstructor tileConstructor;
        private EcsSystems systems;
        
        public EcsStartUp(EcsWorld world, IBuildingConstructor buildingConstructor, 
            ITileConstructor tileConstructor)
        {
            this.world = world;
            this.buildingConstructor = buildingConstructor;
            this.tileConstructor = tileConstructor;
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
                
                .Add(new AvailableCheckingCameraSystem())
                .Add(new RequestTilePoolSystem())
                .Add(new ReturnToPoolSystem())
                
                .Inject(dataManager)
                .Inject(gameDataBase)
                
                .OneFrame<ProduceFlag>()
                .OneFrame<NewLevelFlag>()
                .OneFrame<CheckUpgradeOpportunityFlag>()
                .OneFrame<ReturnPoolFlag>()
                .OneFrame<RequestPoolFlag>()
                
                .Init();
            
            Debug.Log($"CreateWorld {world.IsAlive().ToString()}");
            buildingConstructor.CreateBuildings();
            buildingConstructor.CreateCamera();
            tileConstructor.CreateTilesField();
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