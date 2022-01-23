using UnityEngine;

namespace UnityTemplateProjects
{
    [RequireComponent(typeof(Camera))]
    public sealed class MouseClicker : MonoBehaviour
    {
        private Camera camera;
        
        private IClickable currentObject;

        private int clicableMask;

        private void Start()
        {
            camera = GetComponent<Camera>();
            clicableMask = LayerMask.GetMask("Manufacture");
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentObject?.UnSelect();
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clicableMask))
                {
                    if (hit.collider.TryGetComponent(out IClickable clickable))
                    {
                        currentObject = clickable;
                        currentObject.Select();
                        currentObject.Click();
                    };
                }
            }
        }
    }
}