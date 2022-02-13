using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;

namespace Ecs.View.Impl
{
    public sealed class CameraView : LinkView
    {



        public void CancelSelection()
        {
            Entity.Get<ClearTransportFlag>();
        }
    }
}