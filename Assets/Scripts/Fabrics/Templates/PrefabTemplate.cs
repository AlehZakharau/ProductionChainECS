using Ecs.View.Impl;
using Fabrics.BuildingsConfigs;
using UnityEngine;

namespace Fabrics.Templates
{
    public class PrefabTemplate : MonoBehaviour
    {
        [SerializeField] private BridgeConfig bridgeConfig;
        [SerializeField] private Transform bridgeParent;
        [SerializeField] private UpgradeView upgradeView;
        
        
        public BridgeConfig GetBridge()
        {
            bridgeConfig.Parent = bridgeParent;
            return bridgeConfig;
        }

        public UpgradeView GetUpgradeView()
        {
            return upgradeView;
        }
    }
}