using Ecs.Components;
using Leopotam.Ecs;

namespace Ecs.Systems.Upgrade
{
    public sealed class UpgradeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<NewLevelComponent, LinkComponent> buildings;
        
        public void Run()
        {
            if (buildings.IsEmpty()) return;
            
            foreach (var i in buildings)
            { 
                buildings.Get2(i).View.UpgradeBuilding(buildings.Get1(i).NewLevel);

                var entity = buildings.GetEntity(i);
                entity.Get<UpgradedFlag>();
            }   
        }
    }
}