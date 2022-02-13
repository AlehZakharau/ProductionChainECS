using Ecs.Components;
using Ecs.Systems.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Transportation
{
    public sealed class CancelSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CancelComponent, LinkComponent> cancel = default;
        public void Run()
        {
            foreach (var i in cancel)
            {
                var entity = cancel.GetEntity(i);
                var isCanceled = cancel.Get1(i).IsCanceled;
                if (isCanceled)
                {
                    Debug.Log($"You cancel selection");
                }
                else
                {
                    Debug.Log($"Cancel, can't transfer this resource");
                }
                //Var show wrong resoult
            }
        }
    }
}