using System.Collections.Generic;
using Ecs.Components;
using Ecs.Systems.Components;
using Ecs.Systems.Pool.Components;
using Ecs.Systems.Upgrade;
using Ecs.Towers.Components;
using Fabrics.BuildingsConfigs;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Towers
{
    public sealed class TowerUpgradeOpenTilesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tower, UpgradedFlag, TowerRadius, LevelComponent, LinkComponent> tower = default;
        private readonly EcsFilter<Tile, LinkComponent>.Exclude<ActiveTileFlag> tiles = default;
        public void Run()
        {
            foreach (var i in tower)
            {
                var towerEntity = tower.GetEntity(i);
                var radius = tower.Get3(i).Radius;
                var towerPosition = tower.Get5(i).View.Transform.position;
                var currentLevel = tower.Get4(i).Level;
                if(currentLevel < 0) continue;
                
                UpgradeDemandResource(towerEntity.Get<TowerConfigComponent>().Template.TowerConfig,
                    ref towerEntity.Get<UpgradeResourcesComponent>(), currentLevel);

                foreach (var j in tiles)
                {
                    var tilePosition = tiles.Get2(j).View.Transform.position;
                    var tileEntity = tiles.GetEntity(j);

                    if (!CheckDistance(tilePosition, towerPosition, radius))
                    {
                        tileEntity.Get<ActiveTileFlag>();
                        tileEntity.Get<Pooled>();
                        tileEntity.Get<Available>();
                        tileEntity.Get<RequestPoolFlag>();
                        Debug.Log($"Activate");
                    }
                }
            }
        }
        
        
        
        private bool CheckDistance(Vector3 tilePosition, Vector3 towerPosition, float radius)
        {
            var offset = (tilePosition - towerPosition).sqrMagnitude;
            return offset > radius * radius;
        }
        
        private void UpgradeDemandResource(TowerConfig config, 
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