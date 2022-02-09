using Leopotam.Ecs;

namespace Ecs.Systems.Transportation
{
    public struct TransportBridgeComponent
    {
        public EcsEntity Sender;
        public EcsEntity Receiver;
    }
}