﻿using System.Collections.Generic;
using Ecs;
using Ecs.Systems;
using Ecs.Systems.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Ecs.TowerOpenNewTiles.Components;
using Fabrics.Templates;
using Leopotam.Ecs;

namespace Fabrics.Extension
{
    public static class BuildingExtension
    {
        private static int index;
        
        public static EcsEntity CreateExtractor(this EcsWorld world, IExtractorTemplate extractorTemplate)
        {
            var config = extractorTemplate.ExtractorConfig;
            var extractorEntity = world.NewEntity();
            extractorEntity.Get<Extractor>();
            extractorEntity.Get<ExtractorConfigComponent>().Template = extractorTemplate;
            extractorEntity.Get<ProductionSpeedComponent>().ProductionSpeed = config.productionSpeed;
            extractorEntity.Get<ResourceComponent>().Resource = config.resource;
            extractorEntity.Get<LevelComponent>().Level = config.startLevel;
            extractorEntity.Get<NewLevelComponent>().NewLevel = config.startLevel;
            extractorEntity.Get<UpgradeViewsComponent>();
            ref var upgrade = ref extractorEntity.Get<UpgradeResourcesComponent>();
            upgrade.DemandUpgradeResources = new Dictionary<Resource, int>();

            for (var i = 0; i < config.resources.Length; i++)
            {
                upgrade.DemandUpgradeResources.Add(config.resources[i], config.amountResource[i]);
            }

            return extractorEntity;
        }

        public static EcsEntity CreateTower(this EcsWorld world, ITowerTemplate towerTemplate)
        {
            var config = towerTemplate.TowerConfig;
            var towerEntity = world.NewEntity();
            towerEntity.Get<Tower>();
            towerEntity.Get<TowerConfigComponent>().Template = towerTemplate;
            towerEntity.Get<TowerRadius>().Radius = config.radius;
            towerEntity.Get<LevelComponent>().Level = config.startLevel;
            towerEntity.Get<NewLevelComponent>().NewLevel = config.startLevel;
            towerEntity.Get<UpgradeViewsComponent>();
            ref var upgrade = ref towerEntity.Get<UpgradeResourcesComponent>();
            upgrade.DemandUpgradeResources = new Dictionary<Resource, int>();

            for (var i = 0; i < config.resources.Length; i++)
            {
                upgrade.DemandUpgradeResources.Add(config.resources[i], config.amountResource[i]);
            }

            return towerEntity;
        }

        public static EcsEntity CreateBorough(this EcsWorld world, IBoroughTemplate boroughTemplate)
        {
            var config = boroughTemplate.BoroughConfig;
            var boroughEntity = world.NewEntity();
            boroughEntity.Get<Borough>();
            boroughEntity.Get<BoroughConfigComponent>().BoroughTemplate = boroughTemplate;
            boroughEntity.Get<LevelComponent>().Level = config.startLevel;
            boroughEntity.Get<NewLevelComponent>().NewLevel = config.startLevel;
            boroughEntity.Get<UpgradeViewsComponent>();
            ref var upgrade = ref boroughEntity.Get<UpgradeResourcesComponent>();
            upgrade.DemandUpgradeResources = new Dictionary<Resource, int>();

            for (var i = 0; i < config.resources.Length; i++)
            {
                upgrade.DemandUpgradeResources.Add(config.resources[i], config.amountResource[i]);
            }
            
            return boroughEntity;
        }
    }
}