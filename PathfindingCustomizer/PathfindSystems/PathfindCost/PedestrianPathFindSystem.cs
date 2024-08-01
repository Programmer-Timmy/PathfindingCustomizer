using PathfindingCustomizer;
using Colossal.Logging;
using Game.Pathfind;
using Game.Prefabs;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
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
            
            data.m_CrosswalkCost = new PathfindCosts(
                AdjustCost(data.m_CrosswalkCost.m_Value[0], settings.CrossingSlider),
                AdjustCost(data.m_CrosswalkCost.m_Value[1], settings.CrossingSlider),
                AdjustCost(data.m_CrosswalkCost.m_Value[2], settings.CrossingSlider),
                AdjustCost(data.m_CrosswalkCost.m_Value[3], settings.CrossingSlider)
            );
            
            data.m_SpawnCost = new PathfindCosts(
                AdjustCost(data.m_SpawnCost.m_Value[0], settings.SpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[1], settings.SpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[2], settings.SpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[3], settings.SpawnSlider)
            );
            
            data.m_WalkingCost = new PathfindCosts(
                AdjustCost(data.m_WalkingCost.m_Value[0], settings.WalkingSlider),
                AdjustCost(data.m_WalkingCost.m_Value[1], settings.WalkingSlider),
                AdjustCost(data.m_WalkingCost.m_Value[2], settings.WalkingSlider),
                AdjustCost(data.m_WalkingCost.m_Value[3], settings.WalkingSlider)
            );

            return data;
        }
    }
}
