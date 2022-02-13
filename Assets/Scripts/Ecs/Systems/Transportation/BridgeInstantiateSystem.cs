﻿using Ecs.Components;
using Ecs.Systems.Transportation.Components;
using Fabrics;
using Leopotam.Ecs;

namespace Ecs.Systems.Transportation
{
    public sealed class BridgeInstantiateSystem : IEcsRunSystem
    {
        private readonly IBuildingConstructor buildingConstructor;
        private readonly EcsFilter<Bridge, NewBridgeFlag, TransportBridgeComponent> bridge;
        public void Run()
        {
            foreach (var i in bridge)
            {
                var view = buildingConstructor.CreateBridge(bridge.GetEntity(i));
                ref var transport = ref bridge.Get3(i);
                var senderPosition = transport.Sender.Get<LinkComponent>().View.Transform.position;
                var receiverPosition = transport.Receiver.Get<LinkComponent>().View.Transform.position;
                view.SetConnection(senderPosition, receiverPosition);
            }
        }
    }
}