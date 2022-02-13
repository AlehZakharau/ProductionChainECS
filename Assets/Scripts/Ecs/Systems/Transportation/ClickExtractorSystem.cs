using Ecs.Components;
using Ecs.Extension;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Transportation
{
    public sealed class ClickExtractorSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<ResourceComponent, ClickFlag, Extractor> manufactures = default;
        public void Run()
        {
            foreach (var i in manufactures)
            {
                var entity = manufactures.GetEntity(i);
                world.SetTransportMember(entity);
                Debug.Log($"Call Transport Service");
                //if false
                //cancel flag
            }
        }
    }
}