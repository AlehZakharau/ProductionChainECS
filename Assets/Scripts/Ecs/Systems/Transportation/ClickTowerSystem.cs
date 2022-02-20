using System;
using Ecs.Components;
using Ecs.Extension;
using Ecs.Systems.Components;
using Ecs.Systems.Upgrade;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Transportation
{
    public sealed class ClickTowerSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<Tower, UpgradeResourcesComponent, ClickFlag> tower = default;
        public void Run()
        {
            foreach (var i in tower)
            {
                var entity = tower.GetEntity(i);
                world.SetReceiverMember(entity);
                Debug.Log($"Tower call Transport service");
            }
        }
    }
}