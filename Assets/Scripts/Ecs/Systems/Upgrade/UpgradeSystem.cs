using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Upgrade
{
    public sealed class UpgradeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<NewLevelComponent, LevelComponent, LinkComponent> buildings = default;
        
        public void Run()
        {
            if (buildings.IsEmpty()) return;
            
            foreach (var i in buildings)
            {
                var newLevel = buildings.Get1(i).NewLevel;
                buildings.Get3(i).View.UpgradeBuilding(buildings.Get1(i).NewLevel);
                ref var level = ref buildings.Get2(i);
                level.Level = newLevel;
                Debug.Log($"Building Level {buildings.Get3(i).View.Transform.gameObject.name} : {newLevel}");

                var entity = buildings.GetEntity(i);
                entity.Get<UpgradedFlag>();
                entity.Del<NewLevelComponent>();
            }   
        }
    }
}