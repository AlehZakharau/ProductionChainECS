using Ecs;
using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.BuildingsConfigs
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig", order = 0)]
    public sealed class TowerConfig : ScriptableObject
    {
        [Header("Prefab")] public TowerView towerView;
        [Header("Building Data")]
        public int startLevel;
        public float radius;
        
        [Header("Upgrade Demand Resource")] 
        public Resource[] resources;
        public int[] amountResource;
    }
}