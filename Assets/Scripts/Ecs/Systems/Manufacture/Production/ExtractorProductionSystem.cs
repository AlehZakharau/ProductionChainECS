using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Manufacture
{
    public class ExtractorProductionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ExtractorFlag, ProduceFlag, ResourceComponent> extractors;
        public void Run()
        {
            foreach (var i in extractors)
            {
                var entity = extractors.GetEntity(i);
                ref var resource = ref extractors.Get3(i);
                resource.ResourceAmount++;
                Debug.Log($"Producing {entity.Get<LinkComponent>().View.Transform.gameObject.name}: {resource.ResourceAmount} ");
                entity.Del<ProduceFlag>();
            }
        }
    }
}