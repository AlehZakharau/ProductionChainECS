using System;
using UnityEngine;

namespace DataBase
{
    public interface IGameConfig
    {
        public TileSettings TileSettings { get; }
        public UpgradeSettings UpgradeSettings { get; }
    }
    
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 0)]
    public sealed class GameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private TileSettings tileSettings;
        [SerializeField] private UpgradeSettings upgradeSettings;

        public TileSettings TileSettings => tileSettings;
        public UpgradeSettings UpgradeSettings => upgradeSettings;
    }


    [Serializable]
    public class TileSettings
    {
        public float upgradeViewCenterY;
        public float upgradeViewSize;
    }

    [Serializable]
    public class UpgradeSettings
    {
        public float[] extractorProductionSpeedCoefficient;
    }
}