﻿using Ecs;
using Fabrics.BuildingsConfigs;
using UnityEngine;

namespace Fabrics.Templates
{
    public interface IBoroughTemplate : IBuildingTemplate
    {
        public Transform Transform { get; }
        public BoroughConfig BoroughConfig { get; }
        public BoroughTemplate[] NewBoroughs { get; }
        public bool HasChildBorough { get; }
    }
    public sealed class BoroughTemplate : MonoBehaviour, IBoroughTemplate
    {
        [SerializeField] private BoroughConfig boroughConfig;
        [Header("New Boroughs")] 
        [SerializeField] private BoroughTemplate[] boroughTemplates;
        
        public Building Building => Building.Borough;
        public Transform Transform => transform;
        public BoroughConfig BoroughConfig => boroughConfig;
        public BoroughTemplate[] NewBoroughs => boroughTemplates;

        public bool HasChildBorough => boroughTemplates.Length > 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Tower.png", true);
        }
    }
}