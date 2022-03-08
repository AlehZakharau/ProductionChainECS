using System.Collections.Generic;
using Ecs.Systems.Components;
using Ecs.Systems.Upgrade;
using Fabrics;
using Fabrics.BuildingsConfigs;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Boroughs
{
    public sealed class BoroughUpgradeSystem : IEcsRunSystem
    {
        private readonly IBuildingConstructor buildingConstructor = null;
        private readonly EcsFilter<Borough, LevelComponent, 
            BoroughConfigComponent, UpgradeResourcesComponent, BoroughConfigComponent, UpgradedFlag> boroughs = default; 
        public void Run()
        {
            foreach (var i in boroughs)
            {
                var currentLevel = boroughs.Get2(i).Level;
                ref var config = ref boroughs.Get3(i);
                
                UpgradeDemandResource(boroughs.Get5(i).BoroughTemplate.BoroughConfig, 
                    ref boroughs.Get4(i), currentLevel);
                
                if (config.BoroughTemplate.BoroughConfig.levelToOpenBorough.Length <= config.NewBoroughsIndex)
                {
                    Debug.LogWarning($"Borough doesn't have reference to new Borough");
                    return;
                }
                if (config.BoroughTemplate.BoroughConfig.levelToOpenBorough[config.NewBoroughsIndex]
                    == currentLevel)
                {
                    buildingConstructor.CreateBorough(config.BoroughTemplate.NewBoroughs[config.NewBoroughsIndex]);
                    config.NewBoroughsIndex++;
                }
            }
        }
        
        private void UpgradeDemandResource(BoroughConfig config, 
            ref UpgradeResourcesComponent upgradeResourcesComponent, int level)
        {
            level++;
            if (level >= config.upgradeDemandResources.Length)
            {
                upgradeResourcesComponent.DemandUpgradeResources = new Dictionary<Resource, int>();
                return;
            }
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