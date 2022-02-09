using Ecs.Components;
using Ecs.Extension;
using Ecs.Systems.Manufacture.Production.Components;
using Leopotam.Ecs;

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

                //if false
                //cancel flag
            }
        }
    }
}