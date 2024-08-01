using Game.Pathfind;
using Game.Prefabs;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
{
    public partial class TrackPathFindSystem : PathFindSystemBase<PathfindTrackData>
    {
        protected override PathfindTrackData AdjustPathfindingData(PathfindTrackData data, Setting settings)
        {
            return data;
        }
        
    }
}