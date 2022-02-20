using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View.Impl
{
    public sealed class CameraView : LinkView
    {
        public float smoothness = 2f;
        public Camera camera;
        

        public void CancelSelection()
        {
            Entity.Get<ClearTransportFlag>();
        }
    }
}