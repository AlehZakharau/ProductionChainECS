﻿using Ecs.Components;
using Ecs.Systems.Pool.Components;
using Ecs.TowerOpenNewTiles.Components;
using Ecs.View;
using Ecs.View.Impl;
using Fabrics.Templates;
using Leopotam.Ecs;
using UnityEngine;

namespace Fabrics
{
    public interface ITileConstructor
    {
        public void CreateTilesField();
    }
    
    public sealed class TileConstructor : ITileConstructor
    {
        private readonly EcsWorld world;
        private readonly TemplatesKeeper templates;
        
        public TileConstructor(EcsWorld world, TemplatesKeeper templates)
        {
            this.world = world;
            this.templates = templates;
        }
        
        public void CreateTilesField()
        {
            var tileViews = templates.GetTiles();
            var index = 0;
            
            foreach (var tile in tileViews)
            {
                var tileEntity = world.NewEntity();
                tileEntity.Get<Tile>();
                var view = (TileView)tile.GetComponent<ILinkable>();
                view.Link(tileEntity);
                tileEntity.Get<LinkComponent>().View = view;
                if (view.active)
                {
                    tileEntity.Get<ActiveTileFlag>();
                }
                

                view.Transform.gameObject.name = "Tile_" + index++;
            }
        }
    }
}