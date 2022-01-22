using Leopotam.Ecs;
using UnityEngine;
using VContainer.Unity;

namespace Ecs
{
    public class EcsStartUp : IStartable
    {
        private readonly EcsWorld world;
        private EcsSystems systems;
        
        public EcsStartUp(EcsWorld world)
        {
            this.world = world;
        }
        public void Start()
        {
            systems = new EcsSystems(world);
            Debug.Log($"CreateWorld {world.IsAlive().ToString()}");
        }
    }
}