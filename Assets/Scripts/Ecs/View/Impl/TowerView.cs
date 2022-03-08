using CameraService;
using Ecs.Components;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Ecs.View.Impl
{
    public class TowerView : LinkView, IClickable
    {
        [SerializeField] private SpriteRenderer tileRender;
        [SerializeField] private SpriteRenderer towerRender;
        [SerializeField] private TMP_Text levelText;

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
            currentTile.color = new Color(0.61f, 1f, 0.96f);
        }

        public void UnSelect()
        {
            currentTile.color = Color.white;
        }

        public void Cancel()
        {
            
        }
        
        public override void UpgradeBuilding(int level)
        {
            base.UpgradeBuilding(level);
            if (level == 0)
            {
                Activate();
            }
            level++;
            levelText.text = level.ToString();
        }
        
        private void Activate()
        {
            currentTile = towerRender;
            towerRender.gameObject.SetActive(true);
            tileRender.gameObject.SetActive(false);
        }
    }
}