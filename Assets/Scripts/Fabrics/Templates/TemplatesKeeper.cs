using System.Collections.Generic;
using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.Templates
{
    public sealed class TemplatesKeeper : MonoBehaviour
    {
        [SerializeField] private List<ExtractorTemplate> extractorTemplates;
        [SerializeField] private List<TowerTemplate> towerTemplates;
        [SerializeField] private List<BoroughTemplate> boroughTemplates;
        [SerializeField] private TileView[] tileViews;
        public List<IBuildingTemplate> GetTemplates()
        {
            var templates = new List<IBuildingTemplate>();

            foreach (var extractorTemplate in extractorTemplates)
            {
                templates.Add(extractorTemplate);
            }

            foreach (var towerTemplate in towerTemplates)
            {
                templates.Add(towerTemplate);
            }

            foreach (var boroughTemplate in boroughTemplates)
            {
                templates.Add(boroughTemplate);
            }

            return templates;
        }

        public TileView[] GetTiles()
        {
            return tileViews;
        }
    }
}