using System;
using System.Collections.Generic;
using DataBase;
using Ecs.Components;
using Ecs.View.Impl;
using Fabrics;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Upgrade
{
    public class CreateUpgradeViewsSystem : IEcsRunSystem
    {
        private readonly IGameConfig gameConfig = null;
        private readonly IBuildingConstructor buildingConstructor = null;
        private readonly EcsFilter<UpgradeResourcesComponent, LinkComponent, UpgradeViewsComponent, 
            UpgradeViewsFlag> buildings = default;
        public void Run()
        {
            foreach (var i in buildings)
            {
                var demandResource = buildings.Get1(i).DemandUpgradeResources;
                var parent = buildings.Get2(i).View.Transform;
                ref var upgradeViews = ref buildings.Get3(i);

                if (upgradeViews.UpgradeViews.Count > 0)
                {
                    foreach (var resource in upgradeViews.UpgradeViews)
                    {
                        resource.DestroyView();
                    }
                }
                upgradeViews.UpgradeViews = new List<IUpgradeView>(demandResource.Count);
                foreach (var resource in demandResource)
                {
                    var upgrade = buildingConstructor.CreateUpgradeViews(resource.Key, resource.Value, parent);
                    upgrade.Transform.localPosition = Vector3.zero;
                    upgradeViews.UpgradeViews.Add(upgrade);
                }
                SpreadObjects(upgradeViews.UpgradeViews);
                var entity = buildings.GetEntity(i);
                entity.Del<UpgradeViewsFlag>();
            }
        }
        
        
        
        private void SpreadObjects(List<IUpgradeView> views)
        {
            var size = gameConfig.TileSettings.upgradeViewSize;
            var distanceBetween =  size / (views.Count + 1);
            var leftBounce =  new Vector3(-size / 2, gameConfig.TileSettings.upgradeViewCenterY, 0);

            for (var i = 0; i < views.Count; i++)
            {
                views[i].Transform.position += leftBounce + new Vector3(distanceBetween * (i + 1), 0, 0);
            }
        }
    }
}