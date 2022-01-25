using Leopotam.Ecs;
using UnityEngine;

namespace Ecs.View
{
    public interface ILinkable
    {
        int Hash { get; }
        Transform Transform { get; }
        int UnityInstanceId { get; }
        void Link(EcsEntity entity);
        void UpgradeBuilding(int level);
    }
}