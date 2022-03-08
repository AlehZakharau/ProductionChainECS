using Ecs.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Transportation.Components;
using Ecs.Systems.Upgrade;
using Ecs.View.Impl;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Transportation
{
    public sealed class BridgeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransportBridgeComponent, TransportationSpeedComponent> bridges = default;
        public void Run()
        {
            foreach (var i in bridges)
            {
                ref var bridge = ref bridges.Get1(i);
                ref var speed = ref bridges.Get2(i);

                var senderView = bridge.Sender.Get<LinkComponent>().View;
                var receiverView = bridge.Receiver.Get<LinkComponent>().View;

                var destination = Vector3.Distance(receiverView.Transform.position, senderView.Transform.position);
                speed.Timer += Time.deltaTime;
                if (speed.Timer >= destination / speed.Speed)
                {
                    ref var senderResource = ref bridge.Sender.Get<ResourceComponent>();
                    if (CheckReceiver(bridge.Receiver, senderResource.Resource))
                    {
                        bridge.Sender.Get<ProduceComponent>().Amount = -1;

                        var transport = new TransportComponent { Resource = senderResource.Resource, Amount = 1 };
                        bridge.Receiver.Get<TransportComponent>() = transport;
                    
                        speed.Timer = 0f;
                    }
                    else
                    {
                        var bridgeView = (BridgeView)bridges.GetEntity(i).Get<LinkComponent>().View;
                        bridgeView.Cancel();
                    }
                }
            }
        }

        private bool CheckReceiver(EcsEntity receiver, Resource senderResource)
        {
            var resources = receiver.Get<UpgradeResourcesComponent>().DemandUpgradeResources;

            foreach (var resource in resources)
            {
                if (senderResource == resource.Key && resource.Value > 0)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}