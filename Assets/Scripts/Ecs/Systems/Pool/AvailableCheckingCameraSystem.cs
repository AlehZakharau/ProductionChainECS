using DataBase;
using Ecs.Components;
using Ecs.Systems.Pool.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Pool
{
    public class AvailableCheckingCameraSystem : IEcsRunSystem
    {
        private readonly IGameConfig gameConfig = null;
        private readonly EcsFilter<CameraComponent, LinkComponent> camera = default;
        private readonly EcsFilter<Available, LinkComponent> available = default;
        private readonly EcsFilter<Pooled, LinkComponent>.Exclude<Available> notAvailable = default;

        public void Run()
        {
            foreach (var i in available)
            {
                var view = available.Get2(i).View;
                var cameraView = camera.Get2(0).View;

                if (!CheckDistance(view.Transform.position, cameraView.Transform.position))
                {
                    available.GetEntity(i).Get<RequestPoolFlag>();
                    //Debug.Log($"Request");
                }
            }

            foreach (var i in notAvailable)
            {
                var view = notAvailable.Get2(i).View;
                var cameraView = camera.Get2(0).View;

                if (CheckDistance(view.Transform.position, cameraView.Transform.position))
                {
                    notAvailable.GetEntity(i).Get<ReturnPoolFlag>();
                    
                    //Debug.Log($"Return {notAvailable.GetEntity(i).Has<LinkComponent>()}");
                }
            }
        }


        private bool CheckDistance(Vector3 availablePosition, Vector3 cameraPosition)
        {
            var offset = (availablePosition - cameraPosition).sqrMagnitude;
            return offset > gameConfig.TileSettings.poolRadius;
        }
    }
}