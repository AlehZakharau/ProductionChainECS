using Ecs.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Ecs.View.Impl;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Manufacture.Production
{
    public sealed class ExtractorProductionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Extractor, ProduceComponent, ResourceComponent, LinkComponent> extractors = default;
        public void Run()
        {
            foreach (var i in extractors)
            {
                ref var resource = ref extractors.Get3(i);
                resource.ResourceAmount += extractors.Get2(i).Amount;
                var view = (ExtractorView)extractors.Get4(i).View;
                view.AddResource(resource.ResourceAmount);
                var extractorEntity = extractors.GetEntity(i);
                extractorEntity.Del<ProduceComponent>();
                //Debug.Log($"Producing {entity.Get<LinkComponent>().View.Transform.gameObject.name}: {resource.ResourceAmount} ");
            }
        }
    }
}