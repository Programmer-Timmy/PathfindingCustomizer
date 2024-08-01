using Game.Pathfind;
using Game.Prefabs;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
{
    public partial class TrackPathFindSystem : PathFindSystemBase<PathfindConnectionData>
    {
        protected override PathfindConnectionData AdjustPathfindingData(PathfindConnectionData data, Setting settings)
        {
            return data;
        }
        
    }
}