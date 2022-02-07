using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Leopotam.Ecs;

namespace Ecs.Extension
{
    public static class TransportService
    {
        private static EcsEntity sender;
        private static EcsEntity receiver;

        
        public static void SetTransportMember(this EcsWorld world, EcsEntity newMember)
        {
            if (sender.IsNull())
            {
                sender = newMember;
            }
            else if(receiver.IsNull())
            {
                receiver = newMember;
                if (CheckMatchingResources(sender, receiver))
                {
                    // Create transport
                }
                else
                {
                    //Cancel
                }
            }
        }




        private static bool CheckMatchingResources(EcsEntity sender, EcsEntity receiver)
        {
            var resource = sender.Get<ResourceComponent>().Resource;
            //if(receiver.Has<>()) if refinery => add first to upgrade, then to production demand
            var demands = receiver.Get<UpgradeResourcesComponent>().DemandUpgradeResources;

            foreach (var demand in demands.Keys)
            {
                if (demand == resource)
                {
                    return true;
                }
            }
            return false;
        }
    }
}