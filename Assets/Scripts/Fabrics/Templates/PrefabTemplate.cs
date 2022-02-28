using Ecs.View.Impl;
using Fabrics.BuildingsConfigs;
using UnityEngine;

namespace Fabrics.Templates
{
    public class PrefabTemplate : MonoBehaviour
    {
        [SerializeField] private BridgeConfig bridgeConfig;
        [SerializeField] private Transform bridgeParent;
        [SerializeField] private UpgradeConfig upgradeConfig;
        
        
        public BridgeConfig GetBridge()
        {
            bridgeConfig.Parent = bridgeParent;
            return bridgeConfig;
        }

        public UpgradeConfig GetUpgradeView()
        {
            return upgradeConfig;
        }
    }
}