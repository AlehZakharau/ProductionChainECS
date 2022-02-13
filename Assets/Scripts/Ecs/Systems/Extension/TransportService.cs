using CameraService;
using Ecs.Components;
using Ecs.Systems.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Transportation;
using Ecs.Systems.Transportation.Components;
using Ecs.Systems.Upgrade;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Extension
{
    public static class TransportService
    {
        private static EcsEntity sender;
        private static EcsEntity receiver;

        
        public static void SetTransportMember(this EcsWorld world, EcsEntity newMember)
        {
            if (sender.IsNull() && !newMember.Has<SenderBusyFlag>())
            {
                sender = newMember;
            }
            else if(receiver.IsNull() && !sender.IsNull())
            {
                receiver = newMember;
                if (CheckMatchingResources(sender, receiver))
                {
                    // Create transport
                    sender.Get<SenderBusyFlag>();
                    var transportEntity = world.NewEntity();
                    transportEntity.Get<Bridge>();
                    transportEntity.Get<NewBridgeFlag>();
                    var transport = new TransportBridgeComponent { Sender = sender, Receiver = receiver };
                    transportEntity.Get<TransportBridgeComponent>() = transport;
                    ClearTransportService(world, ECancelMessage.Cancel);
                }
                else
                {
                    ClearTransportService(world, ECancelMessage.Wrong);
                }
            }
            else if (newMember.Has<SenderBusyFlag>())
            {
                newMember.Get<CancelComponent>().Message = ECancelMessage.Busy;
            }
        }

        public static void ClearTransportService(this EcsWorld world, ECancelMessage message)
        {
            if(sender.IsNull()) return;
            Debug.Log($"Add Cancel Flag");
            sender.Get<CancelComponent>().Message = message;
            sender = EcsEntity.Null;
            if(receiver.IsNull()) return;
            receiver.Get<CancelComponent>().Message = message;
            receiver = EcsEntity.Null;
        }
        
        private static bool CheckMatchingResources(EcsEntity checkedSender, EcsEntity checkedReceiver)
        {
            var senderID = checkedSender.Get<LinkComponent>().View.UnityInstanceId;
            var receiverID = checkedReceiver.Get<LinkComponent>().View.UnityInstanceId;
            if (senderID == receiverID) return false;
            var resource = checkedSender.Get<ResourceComponent>().Resource;
            //if(receiver.Has<>()) if refinery => add first to upgrade, then to production demand
            var demands = checkedReceiver.Get<UpgradeResourcesComponent>().DemandUpgradeResources;

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