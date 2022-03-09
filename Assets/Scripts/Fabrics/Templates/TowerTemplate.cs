using Ecs;
using Fabrics.BuildingsConfigs;
using UnityEngine;

namespace Fabrics.Templates
{
    public interface ITowerTemplate : IBuildingTemplate
    {
        public Transform Transform { get; }
        public TowerConfig TowerConfig { get; }
    }
    public sealed class TowerTemplate : MonoBehaviour, ITowerTemplate
    {
        [SerializeField] private TowerConfig towerConfig;
        public Transform Transform => transform;
        public TowerConfig TowerConfig => towerConfig;
        public Building Building => Building.Tower;
        
        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Tower.png", true);
        }
    }
}