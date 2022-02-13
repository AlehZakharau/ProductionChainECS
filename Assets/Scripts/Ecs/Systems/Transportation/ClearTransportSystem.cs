using Ecs.Extension;
using Ecs.Systems.Components;
using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Transportation
{
    public class ClearTransportSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<ClearTransportFlag> clear = default;
        public void Run()
        {
            foreach (var i in clear)
            {
                world.ClearTransportService(ECancelMessage.Cancel);
                Debug.Log($"Call ClearTransportService");
            }
        }
    }
}