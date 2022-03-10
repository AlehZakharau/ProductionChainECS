using CameraService;
using Ecs.Components;
using Ecs.Systems.PlayerInput.Components;
using Ecs.View.Impl;
using Leopotam.Ecs;
using PlayerInput;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace Ecs.Systems.PlayerInput
{
    public class MobileInputSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsWorld world = null;
        private readonly Controls controls = null;
        private readonly EcsFilter<CameraComponent, LinkComponent> cameraFilter = default;

        private IClickable currentClickable;
        private int clickableMask;
        private CameraView cameraView;

        private Vector2 startPosition;
        private float startTime;
        private Vector2 endPosition;
        private float endTime;
        private bool tap;
        public void Init()
        {
            EnhancedTouchSupport.Enable();
            controls.Enable();
            Touch.onFingerDown += StartTouch;
            Touch.onFingerUp += EndTouch;
            // controls.Touch.PrimaryContact.started += StartTouchPrimary;
            // controls.Touch.PrimaryContact.canceled += EndTouchPrimary;
            // controls.Touch.Tap.started += context => tap = true;
            // controls.Touch.Release.started += context => tap = false;
            cameraView = (CameraView)cameraFilter.Get2(0).View;
            clickableMask = LayerMask.GetMask("Manufacture");
        }

        private void StartTouch(Finger obj)
        {
            Debug.Log("Start Touch");
            var ray = cameraView.camera.ScreenPointToRay(controls.Touch.PrimatyPosition.ReadValue<Vector2>());
            Debug.DrawRay(ray.origin, ray.direction, Color.blue, 5f);
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

        private void EndTouch(Finger obj)
        {
            world.NewEntity().Get<CameraMovementDisableFlag>();
            Debug.Log("End Touch");
        }

        private void DetectSwipe()
        {
            if (Vector3.Distance(startPosition, endPosition) >= 0.1f && (endTime - startTime) <= 1f)
            {
                var direction = (endPosition - startPosition).normalized;
                if (Vector2.Dot(Vector2.down, direction) > 0.9f)
                {
                    Debug.DrawLine(startPosition, endPosition, Color.blue, 5f);
                    currentClickable?.Cancel();
                    currentClickable?.UnSelect();
                    currentClickable = null;
                    cameraView.CancelSelection();
                }
            }
        }

        public void Run()
        {
            foreach (var touch in Touch.activeTouches)
            {
                switch (touch)
                {
                    case { phase: TouchPhase.Began }:
                        startPosition = cameraView.camera.ScreenToWorldPoint(touch.startScreenPosition);
                        startTime = (float)touch.startTime;
                        break;
                    case { phase: TouchPhase.Ended }:
                        endPosition = cameraView.camera.ScreenToWorldPoint(touch.screenPosition);
                        endTime = (float)touch.time;
                        break;
                }
                DetectSwipe();
            }
        }

        public void Destroy()
        {
            EnhancedTouchSupport.Disable();
            controls.Disable();
            Touch.onFingerDown -= StartTouch;
            Touch.onFingerUp -= EndTouch;
        }
    }
}