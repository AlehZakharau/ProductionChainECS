using Fabrics.BuildingsConfigs;
using UnityEngine;

namespace Fabrics.Templates
{
    public class PrefabTemplate : MonoBehaviour
    {
        [SerializeField] private BridgeConfig bridgeConfig;
        [SerializeField] private Transform bridgeParent;
        
        
        public BridgeConfig GetBridge()
        {
            bridgeConfig.Parent = bridgeParent;
            return bridgeConfig;
        }
    }
}