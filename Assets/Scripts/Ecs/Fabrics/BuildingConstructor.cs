using System.Collections.Generic;
using UnityEngine;

namespace Ecs.Fabrics
{
    public interface IBuildingConstructor
    {
        public void CreateBuildings();
    }
    public class BuildingConstructor : IBuildingConstructor
    {
    private readonly Templates templates;
    
    private List<IBuildingTemplate> buildingTemplates;

    public BuildingConstructor(Templates templates)
    {
        this.templates = templates;
    }

    public void CreateBuildings()
    {
        buildingTemplates = templates.GetTemplates();
        foreach (var template in buildingTemplates)
        {
            switch (template.Building)
            {
                case Building.Extractor:
                    Debug.Log($"Create Extractor");
                    break;
                default:
                    Debug.Log($"This type doesn't exist");
                    break;
            }
        }
    }
    }
}