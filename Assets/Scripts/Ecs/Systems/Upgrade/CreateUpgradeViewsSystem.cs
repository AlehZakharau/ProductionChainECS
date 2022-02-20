using System;
using System.Collections.Generic;
using Ecs.Components;
using Ecs.View.Impl;
using Fabrics;
using Leopotam.Ecs;

namespace Ecs.Systems.Upgrade
{
    public class CreateUpgradeViewsSystem : IEcsInitSystem
    {
        private readonly IBuildingConstructor buildingConstructor = null;
        private readonly EcsFilter<UpgradeResourcesComponent, LinkComponent, UpgradeViewsComponent> buildings = default;
        public void Init()
        {
            foreach (var i in buildings)
            {
                var demandResource = buildings.Get1(i).DemandUpgradeResources;
                var parent = buildings.Get2(i).View.Transform;
                ref var upgradeViews = ref buildings.Get3(i);

                upgradeViews.UpgradeViews = new List<UpgradeView>(demandResource.Count);
                foreach (var resource in demandResource)
                {
                    var upgrade = buildingConstructor.CreateUpgradeViews(resource.Key, resource.Value, parent);
                    upgradeViews.UpgradeViews.Add(upgrade);
                }
            }
        }
    }
}