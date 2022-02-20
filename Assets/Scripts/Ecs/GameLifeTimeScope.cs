﻿using DataBase;
using Ecs.View.Impl;
using Fabrics;
using Fabrics.Fabrics;
using Fabrics.Templates;
using Leopotam.Ecs;
using PlayerInput;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Ecs
{
    public sealed class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private DataView dataView;
        [SerializeField] private TemplatesKeeper templatesKeeper;
        [SerializeField] private PrefabTemplate prefabTemplate;
        [SerializeField] private MonoTemplate monoTemplate;
        [SerializeField] private BuildingFabric buildingFabric;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterWorld(builder);
            
            builder.RegisterEntryPoint<DataController>();
            builder.Register<IBuildingConstructor, BuildingConstructor>(Lifetime.Singleton);
            builder.Register<ITileConstructor, TileConstructor>(Lifetime.Singleton);
            builder.Register<IMonoConstructor, MonoConstructor>(Lifetime.Singleton);
            builder.Register<Controls>(Lifetime.Singleton);
            
            RegisterComponents(builder);
            
            base.Configure(builder);
        }
        
        private void RegisterWorld(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EcsStartUp>();
            builder.Register<EcsWorld>(x =>
            {
                var world = new EcsWorld();

                return world;
            }, Lifetime.Singleton);
        }


        private void RegisterComponents(IContainerBuilder builder)
        {
            builder.RegisterComponent(dataView);
            builder.RegisterComponent(templatesKeeper);
            builder.RegisterComponent(prefabTemplate);
            builder.RegisterComponent(monoTemplate);
            builder.RegisterInstance(buildingFabric).As<IBuildingFactory>();

        }
    }
}