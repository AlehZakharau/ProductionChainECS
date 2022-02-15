using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View.Impl
{
    public sealed class CameraView : LinkView
    {
        public Camera camera;
        

        public void CancelSelection()
        {
            Entity.Get<ClearTransportFlag>();
        }
    }
}