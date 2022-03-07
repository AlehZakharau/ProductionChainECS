using Ecs.Components;
using Leopotam.Ecs;

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
                buildings.Get3(i).View.UpgradeBuilding(buildings.Get1(i).NewLevel);
                buildings.Get2(i).Level++;
                ref var level = ref buildings.Get2(i);
                level.Level++;

                if (level.Level == 0)
                {
                    
                }

                var entity = buildings.GetEntity(i);
                entity.Get<UpgradedFlag>();
            }   
        }
    }
}