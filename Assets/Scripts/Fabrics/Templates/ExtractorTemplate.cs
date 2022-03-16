using System;
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
    public sealed class ExtractorTemplate : MonoBehaviour, IExtractorTemplate
    {
        [SerializeField]private ExtractorConfig extractorConfig;

        public Transform Transform => transform;
        public ExtractorConfig ExtractorConfig => extractorConfig;
        public Building Building => Building.Extractor;
        
        
        void OnDrawGizmos()
            {
                switch (extractorConfig.resource)
                {
                    case Resource.Wood:
                        Gizmos.DrawIcon(transform.position, "Wood.png", true);
                        break;
                    case Resource.Stone:
                        Gizmos.DrawIcon(transform.position, "Stone.png", true);
                        break;
                    case Resource.Coal:
                        Gizmos.DrawIcon(transform.position, "Coal.png", true);
                        break;
                    case Resource.GoldOre:
                        Gizmos.DrawIcon(transform.position, "Ore.png", true);
                        break;
                    case Resource.IronOre:
                        Gizmos.DrawIcon(transform.position, "Ore.png",true);
                        break;
                    default:
                        throw new Exception("You need add Icon for new type of resource");
                }
                
            }
    }
}