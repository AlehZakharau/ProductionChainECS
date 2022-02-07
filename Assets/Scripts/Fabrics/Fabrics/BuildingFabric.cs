using UnityEngine;

namespace Fabrics.Fabrics
{
    public interface IBuildingFactory
    {
        public GameObject CreateBuilding(GameObject prefab, Vector3 startPosition);
    }
    [CreateAssetMenu(fileName = "BuildingFabric", menuName = "Fabrics/BuildingFabric", order = 0)]
    public sealed class BuildingFabric : ScriptableObject, IBuildingFactory
    {
        public GameObject CreateBuilding(GameObject prefab, Vector3 startPosition)
        {
            return Instantiate(prefab, startPosition, Quaternion.identity);
        }
    }
}