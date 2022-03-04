using Ecs.Components;
using Ecs.Systems.Pool.Components;
using Ecs.Towers.Components;
using Leopotam.Ecs;

namespace Ecs.Systems.Pool
{
    public sealed class RequestTilePoolSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tile, LinkComponent, Available, ActiveTileFlag, RequestPoolFlag> availableTiles = default;
        public void Run()
        {
            foreach (var i in availableTiles)
            {
                var entity = availableTiles.GetEntity(i);
                var view = entity.Get<LinkComponent>().View;
                view.Transform.gameObject.SetActive(true);
                entity.Del<Available>();
            }
        }
    }
}