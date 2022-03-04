using Ecs;
using Ecs.View.Impl;
using UnityEngine;

namespace Fabrics.BuildingsConfigs
{
    [CreateAssetMenu(fileName = "BoroughConfig", menuName = "Configs/BoroughConfig", order = 0)]
    public sealed class BoroughConfig : ScriptableObject
    {
        [Header("Prefab")] public BoroughView boroughView;
        [Header("Building Data")]
        public int startLevel;
        [Header("Upgrade Demand Resource")] 
        public Resource[] resources;
        public int[] amountResource;
        public int[] levelToOpenBorough;
    }
}