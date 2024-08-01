using Game.Prefabs;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
{
    public partial class TransportPathFindSystem : PathFindSystemBase<PathfindTransportData>
    {
        protected override PathfindTransportData AdjustPathfindingData(PathfindTransportData data, Setting settings)
        {
            return data;
        }
        
    }

}