using System.Collections.Generic;
using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.Templates
{
    public class TemplatesKeeper : MonoBehaviour
    {
        [SerializeField] private List<ExtractorTemplate> extractorTemplate;
        [SerializeField] private TileView[] tileViews;
        public List<IBuildingTemplate> GetTemplates()
        {
            var templates = new List<IBuildingTemplate>();

            foreach (var extractorTemplate in extractorTemplate)
            {
                templates.Add(extractorTemplate);
            }

            return templates;
        }

        public TileView[] GetTiles()
        {
            return tileViews;
        }
    }
}