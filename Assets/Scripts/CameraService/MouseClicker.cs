using Ecs.View.Impl;
using UnityEngine;

namespace CameraService
{
    public sealed class MouseClicker : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private CameraView view;
        
        private IClickable currentObject;

        private int clicableMask;

        private void Start()
        {
            clicableMask = LayerMask.GetMask("Manufacture");
        }

        // private void Update()
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         currentObject?.UnSelect();
        //         Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //         if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clicableMask))
        //         {
        //             if (hit.collider.TryGetComponent(out IClickable clickable))
        //             {
        //                 currentObject = clickable;
        //                 currentObject.Select();
        //                 currentObject.Click();
        //             };
        //         }
        //     }
        //
        //     if (Input.GetMouseButtonDown(1))
        //     {
        //         currentObject?.UnSelect();
        //         currentObject = null;
        //         view.CancelSelection();
        //         Debug.Log($"Cancel");
        //     }
        // }
    }
}