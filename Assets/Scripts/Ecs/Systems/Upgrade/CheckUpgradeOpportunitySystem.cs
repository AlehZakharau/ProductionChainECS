using Leopotam.Ecs;

namespace Ecs.Systems.Upgrade
{
    public sealed class CheckUpgradeOpportunitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<UpgradeResourcesComponent, 
            CheckUpgradeOpportunityFlag, LevelComponent> buildings;
        public void Run()
        {
            if(buildings.IsEmpty()) return;

            foreach (var i in buildings)
            {
                var entity = buildings.GetEntity(i);
                ref var upgradeResource = ref buildings.Get1(i);

                if (CheckUpgradeResource(ref upgradeResource))
                {
                    entity.Get<NewLevelComponent>().NewLevel = buildings.Get3(i).Level + 1;
                }
            }
        }

        private bool CheckUpgradeResource(ref UpgradeResourcesComponent upgradeResourcesComponent)
        {
            foreach (var resource in upgradeResourcesComponent.DemandUpgradeResources.Keys)
            {
                if (upgradeResourcesComponent.DemandUpgradeResources[resource] > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}