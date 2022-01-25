using Ecs.Components;
using Leopotam.Ecs;
using UnityEditor.UI;

namespace Ecs.Systems.Manufacture.Upgrade
{
    public class LevelSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LevelComponent, LinkComponent> buildings;
        
        public void Run()
        {
            foreach (var i in buildings)
            { 
                buildings.Get2(i).View.UpgradeBuilding(buildings.Get1(i).Level);
            }   
        }
    }
}