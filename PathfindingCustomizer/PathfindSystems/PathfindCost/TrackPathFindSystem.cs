using Game.Pathfind;
using Game.Prefabs;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
{
    public partial class TrackPathFindSystem : PathFindSystemBase<PathfindTrackData>
    {
        protected override PathfindTrackData AdjustPathfindingData(PathfindTrackData data, Setting settings)
        {
            data.m_SwitchCost = new PathfindCosts(
                AdjustCost(data.m_SwitchCost.m_Value[0], settings.LaneSwitchSlider),
                AdjustCost(data.m_SwitchCost.m_Value[1], settings.LaneSwitchSlider),
                AdjustCost(data.m_SwitchCost.m_Value[2], settings.LaneSwitchSlider),
                AdjustCost(data.m_SwitchCost.m_Value[3], settings.LaneSwitchSlider)
            );
            return data;
        }
        
    }
}