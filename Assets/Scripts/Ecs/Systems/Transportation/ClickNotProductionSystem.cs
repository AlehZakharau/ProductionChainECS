using System;
using Ecs.Components;
using Ecs.Extension;
using Ecs.Systems.Components;
using Ecs.Systems.Upgrade;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Transportation
{
    public sealed class ClickNotProductionSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<Tower, UpgradeResourcesComponent, ClickFlag> tower = default;
        private readonly EcsFilter<Borough, UpgradeResourcesComponent, ClickFlag> borough = default;
        public void Run()
        {
            foreach (var i in tower)
            {
                var entity = tower.GetEntity(i);
                world.SetReceiverMember(entity);
                Debug.Log($"Tower call Transport service");
            }

            foreach (var i in borough)
            {
                var entity = borough.GetEntity(i);
                world.SetReceiverMember(entity);
                Debug.Log($"Borough call Transport service");
            }
        }
    }
}