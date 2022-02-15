using Leopotam.Ecs;
using PlayerInput;
using UnityEngine;

namespace Ecs.PlayerInput
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly Controls controls = null;
        public void Init()
        {
            controls.Enable();
        }

        public void Run()
        {
            var leftClick = controls.Clicks.LeftClick.triggered;
            var rightClick = controls.Clicks.RightClick.triggered;
            var cursorPosition = controls.Clicks.CursorPosition.ReadValue<Vector2>();

            if (leftClick)
            {
                Debug.Log($"Left Click");
            }

            if (rightClick)
            {
                Debug.Log($"Right Click");
            }
        }
    }
}