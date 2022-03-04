using Ecs.View.Impl;
using Fabrics.BuildingsConfigs;
using UnityEngine;

namespace Fabrics.Templates
{
    public class PrefabTemplate : MonoBehaviour
    {
        [SerializeField] private BridgeConfig bridgeConfig;
        [SerializeField] private Transform bridgeParent;
        [SerializeField] private UpgradeViewConfig upgradeViewConfig;
        
        
        public BridgeConfig GetBridge()
        {
            bridgeConfig.Parent = bridgeParent;
            return bridgeConfig;
        }

        public UpgradeViewConfig GetUpgradeView()
        {
            return upgradeViewConfig;
        }
    }
}