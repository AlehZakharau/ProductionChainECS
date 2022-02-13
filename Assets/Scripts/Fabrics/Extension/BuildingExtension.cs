using System.Collections.Generic;
using Ecs;
using Ecs.Systems;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
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
            extractorEntity.Get<ProductionSpeedComponent>().ProductionSpeed = config.productionSpeed;
            extractorEntity.Get<ResourceComponent>().Resource = config.resource;
            extractorEntity.Get<LevelComponent>().Level = config.startLevel;
            extractorEntity.Get<NewLevelComponent>().NewLevel = config.startLevel;
            ref var upgrade = ref extractorEntity.Get<UpgradeResourcesComponent>();
            upgrade.DemandUpgradeResources = new Dictionary<Resource, int>();

            for (var i = 0; i < config.resources.Length; i++)
            {
                upgrade.DemandUpgradeResources.Add(config.resources[i], config.amountResource[i]);
            }

            return extractorEntity;
        }
    }
}