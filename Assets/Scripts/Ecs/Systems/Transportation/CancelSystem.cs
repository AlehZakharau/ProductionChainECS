using CameraService;
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
                var massage = cancel.Get1(i).Message;
                switch (massage)
                {
                    case ECancelMessage.Cancel:
                        Debug.Log($"You cancel selection");
                        break;
                    case ECancelMessage.Wrong:
                        Debug.Log($"Cancel, can't transfer this resource");
                        break;
                    case ECancelMessage.Busy:
                        Debug.Log($"Cancel, Sender Busy");
                        break;
                }
                var clickable = (IClickable)cancel.Get2(i).View;
                clickable.UnSelect();
            }
        }
    }
}