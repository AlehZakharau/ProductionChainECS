using Ecs;
using Fabrics.BuildingsConfigs;
using UnityEngine;

namespace Fabrics.Templates
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