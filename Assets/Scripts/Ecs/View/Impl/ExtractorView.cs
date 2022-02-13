using CameraService;
using Ecs.Components;
using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View.Impl
{
    public sealed class ExtractorView : LinkView, IClickable
    {
        [SerializeField] private SpriteRenderer tileRender;
        public void Click()
        {
            Entity.Get<ClickFlag>();
        }

        public void Select()
        {
            tileRender.color = new Color(0.61f, 1f, 0.96f);
        }

        public void UnSelect()
        {
            tileRender.color = Color.white;
        }
    }
}