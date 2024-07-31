using System;
using Colossal.Logging;
using Colossal.Serialization.Entities;
using Game;
using Game.Pathfind;
using Game.Prefabs;
using Unity.Entities;

namespace PathfindingCustomizer
{
    public partial class TraficPathfindSystem : PathFindSystemBase<PathfindCarData>
    {
        protected override PathfindCarData AdjustPathfindingData(PathfindCarData data, Setting settings)
        {
            data.m_UnsafeTurningCost = new PathfindCosts(
                AdjustCost(data.m_UnsafeTurningCost.m_Value[0], settings.UnsafeTurningSlider),
                AdjustCost(data.m_UnsafeTurningCost.m_Value[1], settings.UnsafeTurningSlider),
                AdjustCost(data.m_UnsafeTurningCost.m_Value[2], settings.UnsafeTurningSlider),
                AdjustCost(data.m_UnsafeTurningCost.m_Value[3], settings.UnsafeTurningSlider)
            );
            
            data.m_UnsafeUTurnCost = new PathfindCosts(
                AdjustCost(data.m_UnsafeUTurnCost.m_Value[0], settings.UnsafeTurningSlider),
                AdjustCost(data.m_UnsafeUTurnCost.m_Value[1], settings.UnsafeTurningSlider),
                AdjustCost(data.m_UnsafeUTurnCost.m_Value[2], settings.UnsafeTurningSlider),
                AdjustCost(data.m_UnsafeUTurnCost.m_Value[3], settings.UnsafeTurningSlider)
            );
            
            data.m_ForbiddenCost = new PathfindCosts(
                AdjustCost(data.m_ForbiddenCost.m_Value[0], settings.UnsafeTurningSlider),
                AdjustCost(data.m_ForbiddenCost.m_Value[1], settings.UnsafeTurningSlider),
                AdjustCost(data.m_ForbiddenCost.m_Value[2], settings.UnsafeTurningSlider),
                AdjustCost(data.m_ForbiddenCost.m_Value[3], settings.UnsafeTurningSlider)
            );
            
            return data;
        }
    }
}