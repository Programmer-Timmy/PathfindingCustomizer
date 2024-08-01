using System;
using Colossal.Logging;
using Colossal.Serialization.Entities;
using Game;
using Game.Pathfind;
using Game.Prefabs;
using Unity.Entities;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
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
            
            data.m_DrivingCost = new PathfindCosts(
                AdjustCost(data.m_DrivingCost.m_Value[0], settings.DrivingSlider),
                AdjustCost(data.m_DrivingCost.m_Value[1], settings.DrivingSlider),
                AdjustCost(data.m_DrivingCost.m_Value[2], settings.DrivingSlider),
                AdjustCost(data.m_DrivingCost.m_Value[3], settings.DrivingSlider)
            );
            
            data.m_ParkingCost = new PathfindCosts(
                AdjustCost(data.m_ParkingCost.m_Value[0], settings.ParkingSlider),
                AdjustCost(data.m_ParkingCost.m_Value[1], settings.ParkingSlider),
                AdjustCost(data.m_ParkingCost.m_Value[2], settings.ParkingSlider),
                AdjustCost(data.m_ParkingCost.m_Value[3], settings.ParkingSlider)
            );
            
            data.m_TurningCost = new PathfindCosts(
                AdjustCost(data.m_TurningCost.m_Value[0], settings.TurningSlider),
                AdjustCost(data.m_TurningCost.m_Value[1], settings.TurningSlider),
                AdjustCost(data.m_TurningCost.m_Value[2], settings.TurningSlider),
                AdjustCost(data.m_TurningCost.m_Value[3], settings.TurningSlider)
            );
            
            data.m_SpawnCost = new PathfindCosts(
                AdjustCost(data.m_SpawnCost.m_Value[0], settings.SpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[1], settings.SpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[2], settings.SpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[3], settings.SpawnSlider)
            );
            
            data.m_LaneCrossCost = new PathfindCosts(
                AdjustCost(data.m_LaneCrossCost.m_Value[0], settings.LaneCrossingSlider),
                AdjustCost(data.m_LaneCrossCost.m_Value[1], settings.LaneCrossingSlider),
                AdjustCost(data.m_LaneCrossCost.m_Value[2], settings.LaneCrossingSlider),
                AdjustCost(data.m_LaneCrossCost.m_Value[3], settings.LaneCrossingSlider)
            );
            
            data.m_SpawnCost = new PathfindCosts(
                AdjustCost(data.m_SpawnCost.m_Value[0], settings.TraficSpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[1], settings.TraficSpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[2], settings.TraficSpawnSlider),
                AdjustCost(data.m_SpawnCost.m_Value[3], settings.TraficSpawnSlider)
            );
            
            return data;
        }
    }
}