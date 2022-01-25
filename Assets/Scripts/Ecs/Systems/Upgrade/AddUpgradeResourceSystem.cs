using Leopotam.Ecs;

namespace Ecs.Systems.Upgrade
{
    public class AddUpgradeResourceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransportComponent, UpgradeResourcesComponent> buildings;
        public void Run()
        {
            if(buildings.IsEmpty()) return;

            foreach (var i in buildings)
            {
                ref var transport = ref buildings.Get1(i);
                buildings.Get2(i).DemandUpgradeResources[transport.Resource] -= transport.Amount;
                
                
                var entity = buildings.GetEntity(i);
                entity.Del<TransportComponent>();
                entity.Get<CheckUpgradeOpportunityComponent>();
            }
        }
    }
}