using System.Collections.Generic;

namespace Ecs.Systems.Upgrade
{
    public struct UpgradeResourcesComponent
    {
        public Dictionary<Resource, int> DemandUpgradeResources;
    }
}