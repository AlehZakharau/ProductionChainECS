using Ecs.Components;
using Ecs.Systems.Components;
using Ecs.Systems.Upgrade;
using Ecs.TowerOpenNewTiles.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.TowerOpenNewTiles
{
    public sealed class OpenTilesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tower, UpgradedFlag, TowerRadius, LinkComponent> tower = default;
        private readonly EcsFilter<Tile, LinkComponent>.Exclude<ActiveTileFlag> tiles = default;
        public void Run()
        {
            foreach (var i in tower)
            {
                var radius = tower.Get3(i).Radius;
                var towerPosition = tower.Get4(i).View.Transform.position;

                foreach (var j in tiles)
                {
                    var tilePosition = tiles.Get2(j).View.Transform.position;
                    var tileEntity = tiles.GetEntity(j);

                    if (!CheckDistance(tilePosition, towerPosition, radius))
                    {
                        tileEntity.Get<ActiveTileFlag>();
                    }
                }
            }
        }
        
        
        
        private bool CheckDistance(Vector3 tilePosition, Vector3 towerPosition, float radius)
        {
            var offset = (tilePosition - towerPosition).sqrMagnitude;
            return offset > radius * radius;
        }
    }
}