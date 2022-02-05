
using System;
using Ecs.Components;
using Ecs.Systems.Pool.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View.Impl
{
    public class TileView : LinkView
    {

        public void Return()
        {
            Entity.Get<ReturnPoolFlag>();
        }

        public void Request()
        {
            Entity.Get<RequestPoolFlag>();
        }
    }
}