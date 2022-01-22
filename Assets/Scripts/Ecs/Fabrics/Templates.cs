using System.Collections.Generic;
using UnityEngine;

namespace Ecs.Fabrics
{
    public class Templates : MonoBehaviour
    {
        [SerializeField] private List<ExtractorTemplate> extractorTemplate;
        
        public List<IBuildingTemplate> GetTemplates()
        {
            var templates = new List<IBuildingTemplate>();

            foreach (var extractorTemplate in extractorTemplate)
            {
                templates.Add(extractorTemplate);
            }

            return templates;
        }
    }
}