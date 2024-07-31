using Better_trafic_AI;
using Colossal.Logging;
using Game.Pathfind;
using Game.Prefabs;

namespace Better_trafic_AI
{
    public partial class PedestrianPathFindSystem : PathFindSystemBase<PathfindPedestrianData>
    {
        protected override PathfindPedestrianData AdjustPathfindingData(PathfindPedestrianData data, Setting settings)
        {
            data.m_UnsafeCrosswalkCost = new PathfindCosts(
                AdjustCost(data.m_UnsafeCrosswalkCost.m_Value[0], settings.UnsafeCrossingSlider),
                AdjustCost(data.m_UnsafeCrosswalkCost.m_Value[1], settings.UnsafeCrossingSlider),
                AdjustCost(data.m_UnsafeCrosswalkCost.m_Value[2], settings.UnsafeCrossingSlider),
                AdjustCost(data.m_UnsafeCrosswalkCost.m_Value[3], settings.UnsafeCrossingSlider)
            );

            return data;
        }
    }
}
