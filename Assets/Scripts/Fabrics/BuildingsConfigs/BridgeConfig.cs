using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.BuildingsConfigs
{
    [CreateAssetMenu(fileName = "BridgeConfig", menuName = "Configs/BridgeConfig", order = 0)]
    public sealed class BridgeConfig : ScriptableObject
    {
        [Header("Prefab")] public BridgeView bridgeView;
        [Header("Transport Data")] public float transportSpeed;
        public Transform Parent { get; set; }
    }
}