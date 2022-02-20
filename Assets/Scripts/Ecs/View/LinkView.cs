using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View
{
    public abstract class LinkView : MonoBehaviour, ILinkable
    {
        protected int Level;
        protected EcsEntity Entity;
        public int Hash => transform.GetHashCode();
        public Transform Transform => transform;
        public int UnityInstanceId => gameObject.GetInstanceID();

        public void Link(EcsEntity entity)
        {
            Entity = entity;
        }

        public void UpgradeBuilding(int level)
        {
            Level = level;
        }

        protected virtual void DestroyObject()
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
                Destroy(gameObject);
            else
                DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
        }
    }
}