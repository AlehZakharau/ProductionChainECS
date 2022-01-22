using Ecs.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Systems.Manufacture.Production
{
    public class ProductionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ResourceComponent, ProductionSpeedComponent>.Exclude<ProduceFlag> manufactures;
        public void Run()
        {
            foreach (var i in manufactures)
            {
                ref var productionSpeed = ref manufactures.Get2(i);
                productionSpeed.Timer += Time.deltaTime;
                if (productionSpeed.Timer > productionSpeed.ProductionSpeed)
                {
                    manufactures.GetEntity(i).Get<ProduceFlag>();
                    productionSpeed.Timer = 0;
                }
            }
        }
    }
}