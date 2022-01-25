using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Fabrics.Templates;
using Leopotam.Ecs;

namespace Fabrics.Extension
{
    public static class BuildingExtension
    {
        public static EcsEntity CreateExtractor(this EcsWorld world, IExtractorTemplate extractorTemplate)
        {
            var extractorEntity = world.NewEntity();
            extractorEntity.Get<ExtractorFlag>();
            extractorEntity.Get<ProductionSpeedComponent>().ProductionSpeed =
                extractorTemplate.ExtractorConfig.productionSpeed;
            extractorEntity.Get<ResourceComponent>().Resource = 
                extractorTemplate.ExtractorConfig.resource;
            extractorEntity.Get<LevelComponent>().Level = 
                extractorTemplate.ExtractorConfig.startLevel;
            extractorEntity.Get<NewLevelComponent>().NewLevel =
                extractorTemplate.ExtractorConfig.startLevel;

            return extractorEntity;
        }
    }
}