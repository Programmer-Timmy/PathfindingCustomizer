using Game.Prefabs;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
{
    public partial class ConnectionPathFindSystem : PathFindSystemBase<PathfindConnectionData>
    {
        protected override PathfindConnectionData AdjustPathfindingData(PathfindConnectionData data, Setting settings)
        {
            return data;
        }
        
    }
}