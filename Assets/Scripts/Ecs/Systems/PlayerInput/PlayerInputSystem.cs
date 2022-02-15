using CameraService;
using Ecs.Components;
using Ecs.View.Impl;
using Leopotam.Ecs;
using PlayerInput;
using UnityEditor;
using UnityEngine;

namespace Ecs.PlayerInput
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly Controls controls = null;
        private readonly EcsFilter<CameraComponent, LinkComponent> camera = default;

        private IClickable currentClickable;
        private int clickableMask;
        public void Init()
        {
            controls.Enable();
            clickableMask = LayerMask.GetMask("Manufacture");
        }

        public void Run()
        {
            var leftClick = controls.Clicks.LeftClick.triggered;
            var rightClick = controls.Clicks.RightClick.triggered;
            var cursorPosition = controls.Clicks.CursorPosition.ReadValue<Vector2>();
            var cameraView = (CameraView)camera.Get2(0).View;
            if (leftClick)
            {
                currentClickable?.UnSelect();
                var ray = cameraView.camera.ScreenPointToRay(cursorPosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clickableMask))
                {
                    if (hit.collider.TryGetComponent(out IClickable clickable))
                    {
                        currentClickable = clickable;
                        currentClickable.Select();
                        currentClickable.Click();
                    }
                }
            }

            if (rightClick)
            {
                currentClickable?.UnSelect();
                currentClickable = null;
                cameraView.CancelSelection();
            }
        }
    }
}