using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View
{
    public abstract class LinkableView : MonoBehaviour, ILinkable
    {
        protected EcsEntity Entity;
        public int Hash => transform.GetHashCode();
        public Transform Transform => transform;
        public int UnityInstanceId => gameObject.GetInstanceID();
        public void Link(EcsEntity entity)
        {
            Entity = entity;
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