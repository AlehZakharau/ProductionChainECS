using Ecs.Components;
using Ecs.Systems.PlayerInput.Components;
using Ecs.View.Impl;
using Leopotam.Ecs;
using PlayerInput;
using UnityEngine;

namespace Ecs.Systems.PlayerInput
{
    public class CameraMovementSystem : IEcsRunSystem
    {
        private readonly Controls controls = null;
        
        private readonly EcsFilter<CameraMovementEnableFlag> enable = default;
        private readonly EcsFilter<CameraMovementDisableFlag> disable = default;
        private readonly EcsFilter<CameraComponent, LinkComponent> camera = default;

        private Vector3 offset;
        private bool isMoving;
        public void Run()
        {
            foreach (var i in enable)
            {
                isMoving = true;
                var cursorPosition = controls.Clicks.CursorPosition.ReadValue<Vector2>();
                var cameraView = (CameraView)camera.Get2(0).View;
                var cursorWorldPosition = cameraView.camera.ScreenToWorldPoint(
                    new Vector3(cursorPosition.x, cursorPosition.y, cameraView.camera.transform.position.z));
                offset = cameraView.Transform.position - cursorWorldPosition;
            }

            foreach (var i in disable)
            {
                isMoving = false;
            }

            if (isMoving)
            {
                var cursorPosition = controls.Clicks.CursorPosition.ReadValue<Vector2>();
                var cameraView = (CameraView)camera.Get2(0).View;
                var cursorWorldPosition = cameraView.camera.ScreenToWorldPoint(
                    new Vector3(cursorPosition.x, cursorPosition.y, cameraView.camera.transform.position.z));
                var cameraPosition = cursorWorldPosition + offset;
                cameraView.Transform.position = Vector3.Lerp(cameraView.Transform.position, cameraPosition,
                    cameraView.smoothness * Time.deltaTime);
            }
            
        }
    }
}