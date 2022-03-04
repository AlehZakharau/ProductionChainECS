using System;
using Ecs;
using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.BuildingsConfigs
{
    [CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Configs/UpgradeView", order = 0)]
    public class UpgradeViewConfig : ScriptableObject
    {
        public UpgradeView upgradeView;
        [Header("Resource icons")]
        [SerializeField] private ResourceIcons[] resourceIcons;


        public Sprite GetIcon(Resource resource)
        {
            foreach (var data in resourceIcons)
            {
                if (data.Resource == resource)
                {
                    return data.Icon;
                }
            }

            throw new Exception($"UpgradeConfig Doesn't have {resource}'s Icon");
        }
    }

    [Serializable]
    public class ResourceIcons
    {
        public Resource Resource;
        public Sprite Icon;
    }
}