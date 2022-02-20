using Ecs.Components;
using Leopotam.Ecs;

namespace Ecs.Systems.Upgrade
{
    public sealed class AddUpgradeResourceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransportComponent, UpgradeResourcesComponent, UpgradeViewsComponent> buildings = default;
        public void Run()
        {
            if(buildings.IsEmpty()) return;

            foreach (var i in buildings)
            {
                ref var transport = ref buildings.Get1(i);
                buildings.Get2(i).DemandUpgradeResources[transport.Resource] -= transport.Amount;

                var views = buildings.Get3(i).UpgradeViews;

                foreach (var j in views)
                {
                    j.DrawUpgradeResource(transport.Resource, transport.Amount);
                }
                var entity = buildings.GetEntity(i);
                entity.Del<TransportComponent>();
                entity.Get<CheckUpgradeOpportunityFlag>();
            }
        }
    }
}