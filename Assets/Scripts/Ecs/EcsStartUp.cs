using System;
using DataBase;
using Ecs.Boroughs;
using Ecs.Components;
using Ecs.PlayerInput;
using Ecs.Systems;
using Ecs.Systems.Components;
using Ecs.Systems.Manufacture;
using Ecs.Systems.Manufacture.Production;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.PlayerInput;
using Ecs.Systems.PlayerInput.Components;
using Ecs.Systems.Pool;
using Ecs.Systems.Pool.Components;
using Ecs.Systems.Transportation;
using Ecs.Systems.Transportation.Components;
using Ecs.Systems.Upgrade;
using Ecs.Towers;
using Fabrics;
using Leopotam.Ecs;
using PlayerInput;
using UnityEngine;
using VContainer.Unity;

namespace Ecs
{
    public sealed class EcsStartUp : IStartable, ITickable, IDisposable
    {
        private readonly EcsWorld world;
        private readonly IBuildingConstructor buildingConstructor;
        private readonly ITileConstructor tileConstructor;
        private readonly IMonoConstructor monoConstructor;
        private readonly IGameConfig gameConfig;
        private readonly Controls controls;
        private EcsSystems systems;
        
        public EcsStartUp(EcsWorld world, IBuildingConstructor buildingConstructor, 
            ITileConstructor tileConstructor, IMonoConstructor monoConstructor, Controls controls, IGameConfig gameConfig)
        {
            this.world = world;
            this.buildingConstructor = buildingConstructor;
            this.tileConstructor = tileConstructor;
            this.monoConstructor = monoConstructor;
            this.gameConfig = gameConfig;
            this.controls = controls;
        }
        public void Start()
        {
            var dataManager = new DataManager();
            var gameDataBase = new GameDataBase();
            
            buildingConstructor.CreateBuildings();
            monoConstructor.CreateCamera();
            tileConstructor.CreateTilesField();

            systems = new EcsSystems(world);
            
            systems
                .Add(new PlayerInputSystem())
                .Add(new CameraMovementSystem())
                
                .Add(new ProductionSystem())
                .Add(new ExtractorProductionSystem())
                
                .Add(new CreateUpgradeViewsSystem())
                .Add(new AddUpgradeResourceSystem())
                .Add(new CheckUpgradeOpportunitySystem())
                .Add(new UpgradeSystem())
                .Add(new ExtractorUpgradeSystem())
                .Add(new BoroughUpgradeSystem())
                
                .Add(new ClickExtractorSystem())
                .Add(new ClickTowerSystem())
                .Add(new BridgeInstantiateSystem())
                .Add(new BridgeSystem())
                .Add(new ClearTransportSystem())
                .Add(new CancelSystem())
                
                .Add(new OpenTilesSystem())
                
                .Add(new AvailableCheckingCameraSystem())
                .Add(new RequestTilePoolSystem())
                .Add(new ReturnToPoolSystem())
                
                .Inject(dataManager)
                .Inject(gameDataBase)
                .Inject(buildingConstructor)
                .Inject(controls)
                .Inject(gameConfig)
                
                .OneFrame<ProduceFlag>()
                .OneFrame<NewLevelComponent>()
                .OneFrame<UpgradedFlag>()
                .OneFrame<CheckUpgradeOpportunityFlag>()
                .OneFrame<ReturnPoolFlag>()
                .OneFrame<RequestPoolFlag>()
                .OneFrame<ClickFlag>()
                .OneFrame<CancelComponent>()
                .OneFrame<ClearTransportFlag>()
                .OneFrame<NewBridgeFlag>()
                .OneFrame<CameraMovementEnableFlag>()
                .OneFrame<CameraMovementDisableFlag>()
                
                .Init();
            
            Debug.Log($"CreateWorld {world.IsAlive().ToString()}");
            
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