using Ecs.Systems.PlayerInput.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.PlayerInput
{
    public class CameraMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraMovementEnableFlag> enable = default;
        private readonly EcsFilter<CameraMovementDisableFlag> disable = default;

        private bool isMoving;
        public void Run()
        {
            foreach (var i in enable)
            {
                isMoving = true;
            }

            foreach (var i in disable)
            {
                isMoving = false;
            }
            
            
        }
    }
}