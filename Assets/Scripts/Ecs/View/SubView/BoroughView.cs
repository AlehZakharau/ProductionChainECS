using CameraService;
using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View.Impl
{
    public class BoroughView : LinkView, IClickable
    {
        [SerializeField] private SpriteRenderer tileRender;
        [SerializeField] private SpriteRenderer boroughRender;

        private SpriteRenderer currentTile;

        private void Start()
        {
            currentTile = tileRender;
        }
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

        public void Cancel()
        {
            
        }
        
        public override void UpgradeBuilding(int level)
        {
            base.UpgradeBuilding(level);
            if (level == -1)
            {
                Activate();
            }
        }
        
        private void Activate()
        {
            currentTile = boroughRender;
            boroughRender.gameObject.SetActive(true);
            tileRender.gameObject.SetActive(false);
        }
    }
}