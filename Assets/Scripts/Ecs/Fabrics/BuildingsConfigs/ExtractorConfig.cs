using UnityEngine;
using UnityTemplateProjects;

namespace Ecs.Fabrics.BuildingsConfigs
{
    [CreateAssetMenu(fileName = "ExtractorConfig", menuName = "Configs/ExtractorConfig", order = 0)]
    public class ExtractorConfig : ScriptableObject
    {
        [Header("Prefab")] public ExtractorView extractorView;
        [Header("Building Data")]
        public int startLevel;
        [Header("Extractor Data")]
        public Resource resource;
        public float productionSpeed;
    }
}