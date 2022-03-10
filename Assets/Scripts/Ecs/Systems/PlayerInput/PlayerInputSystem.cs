using CameraService;
using Ecs.Components;
using Ecs.Systems.PlayerInput.Components;
using Ecs.View.Impl;
using Leopotam.Ecs;
using PlayerInput;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ecs.PlayerInput
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsWorld world = null;
        private readonly Controls controls = null;
        private readonly EcsFilter<CameraComponent, LinkComponent> camera = default;

        private IClickable currentClickable;
        private int clickableMask;
        private CameraView cameraView;
        public void Init()
        {
            controls.Enable();
            clickableMask = LayerMask.GetMask("Manufacture");
            controls.Clicks.LeftClick.canceled += LeftClickOnCanceled;
            cameraView = (CameraView)camera.Get2(0).View;
        }

        public void Run()
        {
            var leftClick = controls.Clicks.LeftClick.triggered;
            var rightClick = controls.Clicks.RightClick.triggered;
            var cursorPosition = controls.Clicks.CursorPosition.ReadValue<Vector2>();
            if (leftClick)
            {
                var ray = cameraView.camera.ScreenPointToRay(cursorPosition);
                world.NewEntity().Get<CameraMovementEnableFlag>();
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, clickableMask))
                {
                    if(hit.collider.TryGetComponent(out IClickable clickable))
                    {
                        currentClickable?.UnSelect();
                        currentClickable = clickable;
                        currentClickable.Select();
                        currentClickable.Click();
                    }
                }
            }
            if (rightClick)
            {
                currentClickable?.Cancel();
                currentClickable?.UnSelect();
                currentClickable = null;
                cameraView.CancelSelection();
            }
        }

        private void LeftClickOnCanceled(InputAction.CallbackContext obj)
        {
            world.NewEntity().Get<CameraMovementDisableFlag>();
        }

        public void Destroy()
        {
            controls.Clicks.LeftClick.canceled -= LeftClickOnCanceled;
            controls.Disable();
        }
    }
}