using Ecs.Components;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Manufacture.Production
{
    public sealed class ProductionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ResourceComponent, ProductionSpeedComponent, 
            LevelComponent>.Exclude<ProduceComponent> manufactures = default;
        public void Run()
        {
            foreach (var i in manufactures)
            {
                var currentLevel = manufactures.Get3(i).Level;
                if(currentLevel < 0) continue;
                ref var productionSpeed = ref manufactures.Get2(i);
                productionSpeed.Timer += Time.deltaTime;
                if (productionSpeed.Timer > productionSpeed.ProductionSpeed)
                {
                    //Debug.Log($" Produce Component, Current level {currentLevel} ProductionSpeed {productionSpeed.ProductionSpeed}");
                    manufactures.GetEntity(i).Get<ProduceComponent>().Amount = 1;
                    productionSpeed.Timer = 0;
                }
            }
        }
    }
}