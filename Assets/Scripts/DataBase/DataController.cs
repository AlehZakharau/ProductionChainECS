using Leopotam.Ecs;
using UnityEngine;
using UnityTemplateProjects.Components;
using VContainer.Unity;

namespace UnityTemplateProjects
{
    public class DataController : IStartable
    {
        private readonly EcsWorld world;
        private readonly DataView view;

        public DataController(EcsWorld world, DataView view)
        {
            this.world = world;
            this.view = view;
        }

        public void Start()
        {
            view.load.onClick.AddListener(Load);
            view.save.onClick.AddListener(Save);
        }

        private void Save()
        {
            world.NewEntity().Get<SaveFlag>();
            Debug.Log("Save");
        }

        private void Load()
        {
            world.NewEntity().Get<LoadFlag>();
            Debug.Log("Load");
        }
    }
}