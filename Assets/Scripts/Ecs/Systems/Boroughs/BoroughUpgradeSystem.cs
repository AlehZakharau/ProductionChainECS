using Ecs.Systems.Components;
using Ecs.Systems.Upgrade;
using Fabrics;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Boroughs
{
    public sealed class BoroughUpgradeSystem : IEcsRunSystem
    {
        private readonly IBuildingConstructor buildingConstructor = null;
        private readonly EcsFilter<Borough, LevelComponent, 
            BoroughConfigComponent, UpgradedFlag> boroughs = default; 
        public void Run()
        {
            foreach (var i in boroughs)
            {
                var currentLevel = boroughs.Get2(i).Level;
                ref var config = ref boroughs.Get3(i);
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
    }
}