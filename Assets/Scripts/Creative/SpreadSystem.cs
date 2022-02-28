using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInput.Creative
{
    public class SpreadSystem : MonoBehaviour
    {
        public Transform center;
        public float size = 10;
        public GameObject[] objects;
        private int index = 0;

        public void AddTesters()
        {
            if(index >= objects.Length) return;
            testers.Add(objects[index++]);
        }


        private List<GameObject> testers = new List<GameObject>();


        private void Update()
        {
            SpreadObjects();
        }

        private void SpreadObjects()
        {
            var distanceBetween = size / (testers.Count + 1);
            var leftBounce = center.position + new Vector3(-size / 2, 0, 0);
            Debug.Log(distanceBetween);

            for (int i = 0; i < testers.Count; i++)
            {
                testers[i].transform.position = leftBounce + new Vector3(distanceBetween * (i + 1), 0, 0);
            }
        }
        
        
        void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(center.position, 0.5f);
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(center.position + new Vector3(-size / 2, 0, 0), 0.5f);
            Gizmos.DrawSphere(center.position + new Vector3(size / 2, 0, 0), 0.5f);
        }
    }
}