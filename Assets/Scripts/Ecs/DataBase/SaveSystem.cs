using System.Linq;
using Leopotam.Ecs;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects
{
    public class SaveSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly IDataManager dataManager = default;
        private readonly IGameDataBase dataBase = default;
        
        private readonly EcsFilter<Manufacture, DemandUpgradeResource, ResourceComponent> manufactures = default;
        private readonly EcsFilter<Save> save = default;

        public void Init()
        {
            dataBase.GameData = new GameData
            {
                manufactureData = new ManufactureData[manufactures.GetEntitiesCount()],
                transportData = new TransportData[manufactures.GetEntitiesCount()]
            };
        }

        public void Run()
        {
            if (save.IsEmpty())
            {
                return;
            }
            
            foreach (var i in manufactures)
            {
                ref var manufacture = ref manufactures.Get1(i);
                ref var demandResource = ref manufactures.Get2(i);
                ref var resourceComponent = ref manufactures.Get3(i);

                dataBase.GameData.manufactureData[manufacture.index] = new ManufactureData
                {
                    level = manufacture.level,
                    resourceAmount = resourceComponent.resourceAmount,
                    demandUpgradeResource = new int[demandResource.demandResources.Count]
                };
                dataBase.GameData.manufactureData[manufacture.index].demandUpgradeResource =
                    demandResource.demandResources.Values.ToArray();
            }    
            
            dataManager.SaveToJson("GameData", dataBase.GameData);
        }
    }
}