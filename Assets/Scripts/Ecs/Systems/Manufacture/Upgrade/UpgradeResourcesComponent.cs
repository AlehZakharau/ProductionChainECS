using System.Collections.Generic;

namespace Ecs.Systems.Manufacture.Upgrade
{
    public struct UpgradeResourcesComponent
    {
        public Dictionary<Resource, int> DemandUpgradeResources;
    }
}