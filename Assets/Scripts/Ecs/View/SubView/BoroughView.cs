using CameraService;
using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View.Impl
{
    public class BoroughView : LinkView, IClickable
    {
        public void Click()
        {
            Entity.Get<ClickFlag>();
        }

        public void Select()
        {
           
        }

        public void UnSelect()
        {
            
        }
    }
}