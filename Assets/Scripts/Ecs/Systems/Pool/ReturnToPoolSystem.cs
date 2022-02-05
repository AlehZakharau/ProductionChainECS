using Ecs.Components;
using Ecs.Systems.Pool.Components;
using Leopotam.Ecs;

namespace Ecs.Systems.Pool
{
    public class ReturnToPoolSystem : IEcsRunSystem
    {
        private EcsFilter<ReturnPoolFlag, LinkComponent>.Exclude<Available> notAvailable; 
        public void Run()
        {
            foreach (var i in notAvailable)
            {
                var view = notAvailable.Get2(i).View;
                view.Transform.gameObject.SetActive(false);

                var entity = notAvailable.GetEntity(i);
                entity.Get<Available>();
            }
        }
    }
}