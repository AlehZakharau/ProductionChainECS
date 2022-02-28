using TMPro;
using UnityEngine;

namespace Ecs.View.Impl
{
    public interface IUpgradeView
    {
        public Transform Transform { get; }
        public void Init(Resource addedResource, int maxResource, Sprite resourceIcon);
        public void DrawUpgradeResource(Resource addedResource, int amount);

    }
    public sealed class UpgradeView : MonoBehaviour, IUpgradeView
    {
        [SerializeField] private SpriteRenderer icon;
        [SerializeField] private TMP_Text amountText;
        private Resource resource;
        private int currentAmountResources;
        private int maxAmountResources;
        public Transform Transform => gameObject.transform;

        public void Init(Resource addedResource, int maxResource, Sprite resourceIcon)
        {
            resource = addedResource;
            maxAmountResources = maxResource;
            this.icon.sprite = resourceIcon;

            Debug.Log($"Init {addedResource} : Max {maxResource}");
            
            DrawUpgradeResource(addedResource, 0);
        }
        
        public void DrawUpgradeResource(Resource addedResource, int amount)
        {
            if(addedResource != resource) return;

            currentAmountResources += amount;
            amountText.text = $"{currentAmountResources} / {maxAmountResources}";
            Debug.Log($"{this.resource}: {currentAmountResources} / {maxAmountResources}");
        }
    }
}