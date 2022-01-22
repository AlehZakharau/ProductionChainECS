using System.Linq;
using Leopotam.Ecs;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects
{
    public class LoadSystem : IEcsRunSystem
    {
        private readonly IDataManager dataManager = default;
        private readonly IGameDataBase dataBase = default;
        
        //private readonly EcsFilter<Manufacture, DemandUpgradeResource, ResourceComponent> manufactures = default;
        private readonly EcsFilter<LoadFlag> load = default;

        public void Run()
        {
            if (load.IsEmpty())
            {
                return;
            }

            dataManager.LoadFromJson("GameData", dataBase.GameData);
            
            // foreach (var i in manufactures)
            // {
            //     ref var manufacture = ref manufactures.Get1(i);
            //     ref var demandResource = ref manufactures.Get2(i);
            //     ref var resourceComponent = ref manufactures.Get3(i);
            //
            //
            //     var manufactureData = dataBase.GameData.manufactureData[manufacture.index];
            //     manufacture.level = manufactureData.level;
            //     resourceComponent.resourceAmount = manufactureData.resourceAmount;
            //
            //     var resourceArray = demandResource.demandResources.Keys.ToArray();
            //     for (var j = 0; j < manufactureData.demandUpgradeResource.Length; j++)
            //     {
            //         demandResource.demandResources[resourceArray[j]] = manufactureData.demandUpgradeResource[j];
            //     }
            // }
        }
    }
}