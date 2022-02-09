using Ecs;
using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.BuildingsConfigs
{
    [CreateAssetMenu(fileName = "ExtractorConfig", menuName = "Configs/ExtractorConfig", order = 0)]
    public sealed class ExtractorConfig : ScriptableObject
    {
        [Header("Prefab")] public ExtractorView extractorView;
        [Header("Building Data")]
        public int startLevel;
        [Header("Extractor Data")]
        public Resource resource;
        public float productionSpeed;
        [Header("Upgrade Demand Resource")] 
        public Resource[] resources;
        public int[] amountResource;
    }
}