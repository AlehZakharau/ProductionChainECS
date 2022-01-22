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
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterWorld(builder);
            builder.RegisterEntryPoint<DataController>();
            builder.RegisterComponent(dataView);
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
    }
}