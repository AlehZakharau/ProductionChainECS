using UnityEngine;

namespace Ecs.View.Impl
{
    public class CityView : LinkView
    {
        [SerializeField] private BoroughView[] boroughViews;
        public BoroughView[] BoroughViews => boroughViews;
    }
}