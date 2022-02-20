using Ecs;
using Ecs.Components;
using Fabrics.Templates;
using Leopotam.Ecs;

namespace Fabrics
{
    public interface IMonoConstructor
    {
        public EcsEntity CreateCamera();
    }
    public class MonoConstructor : IMonoConstructor
    {
        private readonly EcsWorld world;
        private readonly MonoTemplate monoTemplate;
        
        public MonoConstructor(EcsWorld world, MonoTemplate monoTemplate)
        {
            this.world = world;
            this.monoTemplate = monoTemplate;
        }
        
        
        public EcsEntity CreateCamera()
        {
            var cameraEntity = world.NewEntity();
            var cameraView = monoTemplate.Get(EMono.Camera);
            cameraEntity.Get<CameraComponent>();
            cameraEntity.Get<LinkComponent>().View = cameraView;
            cameraView.Link(cameraEntity);
            return cameraEntity;
        }
    }
}