using DataBase;
using Ecs.Systems.Manufacture.Production.Components;
using Ecs.Systems.Upgrade;
using Leopotam.Ecs;

namespace Ecs.Systems.Manufacture.Production
{
    public sealed class ExtractorUpgradeSystem : IEcsRunSystem
    {
        private readonly IGameConfig gameConfig = null;
        private readonly EcsFilter<Extractor, ProductionSpeedComponent, LevelComponent, UpgradedFlag> extractors = default;
        public void Run()
        {
            foreach (var i in extractors)
            {
                ref var speed = ref extractors.Get2(i);
                var currentLevel = extractors.Get3(i).Level;
                if(currentLevel < 0) return;
                speed.ProductionSpeed *= gameConfig.UpgradeSettings.extractorProductionSpeedCoefficient[currentLevel];
            }
        }
    }
}