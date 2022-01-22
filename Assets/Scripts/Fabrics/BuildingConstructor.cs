using System.Collections.Generic;
using Ecs.Components;
using Ecs.Fabrics.Fabrics;
using Ecs.View;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Fabrics
{
    public interface IBuildingConstructor
    {
        public void CreateBuildings();
    }

    public class BuildingConstructor : IBuildingConstructor
    {
        private readonly EcsWorld world;
        private readonly Templates templates;
        private readonly IBuildingFactory buildingFabric;

        private List<IBuildingTemplate> buildingTemplates;

        public BuildingConstructor(EcsWorld world, Templates templates, IBuildingFactory buildingFabric )
        {
            this.world = world;
            this.templates = templates;
            this.buildingFabric = buildingFabric;
        }

        public void CreateBuildings()
        {
            buildingTemplates = templates.GetTemplates();
            foreach (var template in buildingTemplates)
            {
                switch (template.Building)
                {
                    case Building.Extractor:
                        var extractorTemplate = (IExtractorTemplate)template;
                        var instance = buildingFabric.CreateExtractor(
                            extractorTemplate.ExtractorConfig.extractorView.gameObject,
                            extractorTemplate.Transform.position);
                        var view = instance.GetComponent<ILinkable>();
                        var extractorEntity = world.NewEntity();
                        extractorEntity.Get<LinkComponent>().View = view;
                        view.Link(extractorEntity);
                        break;
                    default:
                        Debug.Log($"This type doesn't exist");
                        break;
                }
            }
        }
    }
}