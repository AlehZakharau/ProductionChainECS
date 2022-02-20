using UnityEngine;

namespace Ecs.View.Impl
{
    public class UpgradeView : MonoBehaviour
    {
        private Resource resource;
        private int currentAmountResources;
        private int maxAmountResources;

        public void Init(Resource resource, int maxResource)
        {
            this.resource = resource;
            maxAmountResources = maxResource;

            Debug.Log($"Init {resource} : Max {maxResource}");
            
            DrawUpgradeResource(resource, 0);
        }
        
        public void DrawUpgradeResource(Resource resource, int amount)
        {
            if(resource != this.resource) return;

            currentAmountResources += amount;
            Debug.Log($"{this.resource}: {currentAmountResources} / {maxAmountResources}");
        }
    }
}