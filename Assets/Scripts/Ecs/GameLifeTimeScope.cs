using Ecs.Fabrics;
using Ecs.Fabrics.Fabrics;
using Leopotam.Ecs;
using UnityEngine;
using UnityTemplateProjects;
using VContainer;
using VContainer.Unity;

namespace Ecs
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private DataView dataView;
        [SerializeField] private Templates templates;
        [SerializeField] private BuildingFabric buildingFabric;
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterWorld(builder);
            
            builder.RegisterEntryPoint<DataController>();
            builder.Register<IBuildingConstructor, BuildingConstructor>(Lifetime.Singleton);
            
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
            builder.RegisterComponent(templates);
            builder.RegisterInstance(buildingFabric).As<IBuildingFactory>();

        }
    }
}