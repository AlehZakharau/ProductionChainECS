using System;
using CameraService;
using Ecs.Components;
using Ecs.Systems.Transportation.Components;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Ecs.View.Impl
{
    public sealed class ExtractorView : LinkView, IClickable
    {
        [SerializeField] private SpriteRenderer tileRender;
        [SerializeField] private SpriteRenderer manufactureRender;
        [SerializeField] private TMP_Text resourceAmountText;
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

        public void AddResource(int amount)
        {
            resourceAmountText.text = amount.ToString();
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
            currentTile = manufactureRender;
            manufactureRender.gameObject.SetActive(true);
            tileRender.gameObject.SetActive(false);
        }
    }
}