using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.Fabrics.Fabrics
{
    public interface IBuildingFactory
    {
        public GameObject CreateExtractor(GameObject prefab, Vector3 startPosition);
    }
    [CreateAssetMenu(fileName = "BuildingFabric", menuName = "Fabrics/BuildingFabric", order = 0)]
    public class BuildingFabric : ScriptableObject, IBuildingFactory
    {
        public GameObject CreateExtractor(GameObject prefab, Vector3 startPosition)
        {
            return Instantiate(prefab, startPosition, Quaternion.identity);
        }
    }
}