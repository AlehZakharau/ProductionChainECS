using Ecs.Fabrics.BuildingsConfigs;
using UnityEngine;
using UnityTemplateProjects;

namespace Ecs.Fabrics
{
    public interface IExtractorTemplate : IBuildingTemplate
    {
        public Transform Transform { get; }
        public ExtractorConfig ExtractorConfig { get;  }
    }
    public class ExtractorTemplate : MonoBehaviour, IExtractorTemplate
    {
        [SerializeField]private ExtractorConfig extractorConfig;

        public Transform Transform => transform;
        public ExtractorConfig ExtractorConfig => extractorConfig;
        public Building Building => Building.Extractor;
    }
}