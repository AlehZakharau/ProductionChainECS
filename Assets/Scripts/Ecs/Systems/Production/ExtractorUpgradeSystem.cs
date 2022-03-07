using System.Collections.Generic;
using DataBase;
using Ecs.Systems.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Fabrics.BuildingsConfigs;
using Leopotam.Ecs;

namespace Ecs.Systems.Manufacture.Production
{
    public sealed class ExtractorUpgradeSystem : IEcsRunSystem
    {
        private readonly IGameConfig gameConfig = null;
        private readonly EcsFilter<Extractor, ProductionSpeedComponent, LevelComponent,
            UpgradeResourcesComponent, ExtractorConfigComponent, UpgradedFlag> extractors = default;
        public void Run()
        {
            foreach (var i in extractors)
            {
                ref var speed = ref extractors.Get2(i);
                var currentLevel = extractors.Get3(i).Level;
                if(currentLevel < 0) continue;
                speed.ProductionSpeed *= gameConfig.UpgradeSettings.extractorProductionSpeedCoefficient[currentLevel];
                
                UpgradeDemandResource(extractors.Get5(i).Template.ExtractorConfig, 
                    ref extractors.Get4(i), currentLevel);
            }
        }



        private void UpgradeDemandResource(ExtractorConfig config, 
            ref UpgradeResourcesComponent upgradeResourcesComponent, int level)
        {
            level++;
            if(level >= config.maxLevel) return;
            upgradeResourcesComponent.DemandUpgradeResources = new Dictionary<Resource, int>();
            var upgradeResource = config.upgradeDemandResources[level];
            for (var i = 0; i < upgradeResource.resources.Length; i++)
            {
                upgradeResourcesComponent.DemandUpgradeResources
                    .Add(upgradeResource.resources[i], upgradeResource.amountResource[i]);
            }
        }
    }
}