using System.Collections.Generic;
using Ecs.View;
using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.Templates
{
    public sealed class TemplatesKeeper : MonoBehaviour
    {
        [SerializeField] private List<ExtractorTemplate> extractorTemplate;
        [SerializeField] private TileView[] tileViews;
        [SerializeField] private CameraView cameraView;
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

        public ILinkable GetCamera()
        {
            return cameraView.GetComponent<ILinkable>();
        }
    }
}