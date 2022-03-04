using System.Collections.Generic;
using Ecs;
using Ecs.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Transportation.Components;
using Ecs.Systems.Upgrade;
using Ecs.View;
using Ecs.View.Impl;
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
        public void CreateBorough(IBoroughTemplate template);
        public void CreateBuildings();
        public BridgeView CreateBridge(EcsEntity bridge);
        public IUpgradeView CreateUpgradeViews(Resource resource, int maxResource, Transform parent);
    }

    public sealed class BuildingConstructor : IBuildingConstructor
    {
        private readonly EcsWorld world;
        private readonly TemplatesKeeper templatesKeeper;
        private readonly PrefabTemplate prefabTemplate;
        private readonly IBuildingFactory buildingFabric;

        private List<IBuildingTemplate> buildingTemplates;

        private int bridgeCounter;
        private int boroughIndex;

        public BuildingConstructor(EcsWorld world, TemplatesKeeper templatesKeeper, PrefabTemplate prefabTemplate,
            IBuildingFactory buildingFabric )
        {
            this.world = world;
            this.templatesKeeper = templatesKeeper;
            this.prefabTemplate = prefabTemplate;
            this.buildingFabric = buildingFabric;
        }

        public void CreateBuildings()
        {
#if UNITY_EDITOR
            var index =0;
            var towerIndex = 0;
#endif
            buildingTemplates = templatesKeeper.GetTemplates();
            foreach (var template in buildingTemplates)
            {
                switch (template.Building)
                {
                    case Building.Extractor:
                        var extractorTemplate = (IExtractorTemplate)template;
                        
                        var extractorInstance = buildingFabric.CreateBuilding(
                            extractorTemplate.ExtractorConfig.extractorView.gameObject,
                            extractorTemplate.Transform.position);
                        var extractorView = extractorInstance.GetComponent<ILinkable>();
                        extractorView.Transform.SetParent(extractorTemplate.Transform);

                        var extractorEntity = world.CreateExtractor(extractorTemplate);
                        extractorEntity.Get<LinkComponent>().View = extractorView;
                        extractorView.Link(extractorEntity);
                        
#if UNITY_EDITOR
                        extractorView.Transform.gameObject.name = "Extractor_" + index++;
#endif
                        break;
                    case Building.Tower:
                        var towerTemplate = (ITowerTemplate)template;

                        var towerInstance = buildingFabric.CreateBuilding(
                            towerTemplate.TowerConfig.towerView.gameObject,
                            towerTemplate.Transform.position);
                        var towerView = towerInstance.GetComponent<ILinkable>();
                        towerView.Transform.SetParent(towerTemplate.Transform);

                        var towerEntity = world.CreateTower(towerTemplate);
                        towerEntity.Get<LinkComponent>().View = towerView;
                        towerView.Link(towerEntity);
#if UNITY_EDITOR
                        towerView.Transform.gameObject.name = "Tower_" + towerIndex++;
#endif
                        
                        break;
                    case Building.Borough:
                        var boroughTemplate = (IBoroughTemplate)template;

                        var boroughInstance = buildingFabric.CreateBuilding(
                            boroughTemplate.BoroughConfig.boroughView.gameObject,
                            boroughTemplate.Transform.position);
                        var boroughView = boroughInstance.GetComponent<ILinkable>();
                        boroughView.Transform.SetParent(boroughTemplate.Transform);

                        var boroughEntity = world.CreateBorough(boroughTemplate);
                        boroughEntity.Get<LinkComponent>().View = boroughView;
                        boroughView.Link(boroughEntity);
#if UNITY_EDITOR
                        boroughView.Transform.gameObject.name = "Borough" + boroughIndex++;
#endif

                        break;
                    default:
                        Debug.Log($"This type doesn't exist");
                        break;
                }
            }
        }

        public void CreateBorough(IBoroughTemplate template)
        {
            var config = template.BoroughConfig;
            var instance = buildingFabric.CreateBuilding(config.boroughView.gameObject, template.Transform.position);
            var view = instance.GetComponent<ILinkable>();
            view.Transform.SetParent(template.Transform);
            var boroughEntity = world.CreateBorough(template);
            boroughEntity.Get<LinkComponent>().View = view;
            view.Link(boroughEntity);

#if UNITY_EDITOR
            view.Transform.gameObject.name = "Borough" + boroughIndex++;
#endif
        }

        public BridgeView CreateBridge(EcsEntity bridge)
        {
            var config = prefabTemplate.GetBridge();
            var instance = buildingFabric.CreateBuilding(config.bridgeView.gameObject, Vector3.zero);
            var view = instance.GetComponent<ILinkable>();
            view.Transform.SetParent(config.Parent);
            view.Link(bridge);

            bridge.Get<LinkComponent>().View = view;
            bridge.Get<TransportationSpeedComponent>().Speed = config.transportSpeed;
#if UNITY_EDITOR
            view.Transform.gameObject.name = "Bridge_" + bridgeCounter++;
#endif
            return view as BridgeView;
        }

        public IUpgradeView CreateUpgradeViews(Resource resource, int maxResource, Transform parent)
        {
            var upgradeConfig = prefabTemplate.GetUpgradeView();
            var instance = buildingFabric.CreateBuilding(upgradeConfig.upgradeView.gameObject, Vector3.zero);
            var view = instance.GetComponent<IUpgradeView>();
            view.Init(resource, maxResource, upgradeConfig.GetIcon(resource));
            instance.transform.SetParent(parent);
            return view;
        }
    }
}