using System.Collections.Generic;
using Ecs;
using Ecs.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Ecs.View;
using Fabrics.BuildingsConfigs;
using Fabrics.Extension;
using Fabrics.Fabrics;
using Fabrics.Templates;
using Leopotam.Ecs;
using UnityEngine;

namespace Fabrics
{
    public interface IBuildingConstructor
    {
        public void CreateBuildings();
    }

    public class BuildingConstructor : IBuildingConstructor
    {
        private readonly EcsWorld world;
        private readonly TemplatesKeeper templatesKeeper;
        private readonly IBuildingFactory buildingFabric;

        private List<IBuildingTemplate> buildingTemplates;

        public BuildingConstructor(EcsWorld world, TemplatesKeeper templatesKeeper, IBuildingFactory buildingFabric )
        {
            this.world = world;
            this.templatesKeeper = templatesKeeper;
            this.buildingFabric = buildingFabric;
        }

        public void CreateBuildings()
        {
            var index =0;
            buildingTemplates = templatesKeeper.GetTemplates();
            foreach (var template in buildingTemplates)
            {
                switch (template.Building)
                {
                    case Building.Extractor:
                        var extractorTemplate = (IExtractorTemplate)template;
                        
                        var instance = buildingFabric.CreateBuilding(
                            extractorTemplate.ExtractorConfig.extractorView.gameObject,
                            extractorTemplate.Transform.position);
                        var view = instance.GetComponent<ILinkable>();
                        view.Transform.SetParent(extractorTemplate.Transform);

                        var extractorEntity = world.CreateExtractor(extractorTemplate);
                        extractorEntity.Get<LinkComponent>().View = view;
                        view.Link(extractorEntity);
                        
                        view.Transform.gameObject.name = "Extractor_" + index++;
                        break;
                    default:
                        Debug.Log($"This type doesn't exist");
                        break;
                }
            }
        }
    }
}