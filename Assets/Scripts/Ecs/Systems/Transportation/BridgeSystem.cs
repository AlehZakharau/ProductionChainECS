using Ecs.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Transportation
{
    public sealed class BridgeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransportBridgeComponent, TransportationSpeedComponent> bridges;
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
                    bridge.Sender.Get<ProduceComponent>().Amount = -1;

                    var transport = new TransportComponent { Resource = senderResource.Resource, Amount = 1 };
                    bridge.Receiver.Get<TransportComponent>() = transport;
                    
                    speed.Timer = 0f;
                }
            }
        }
    }
}