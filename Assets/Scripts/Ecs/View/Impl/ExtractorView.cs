using Camera;
using Ecs.Components;
using Leopotam.Ecs;

namespace Ecs.View.Impl
{
    public sealed class ExtractorView : LinkView, IClickable
    {
        public void Click()
        {
            Entity.Get<ClickFlag>();
        }

        public void Select()
        {
            throw new System.NotImplementedException();
        }

        public void UnSelect()
        {
            throw new System.NotImplementedException();
        }
    }
}