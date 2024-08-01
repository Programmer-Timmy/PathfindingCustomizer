﻿using System;
using Colossal.Logging;
using Game;
using ComponentType = Unity.Entities.ComponentType;
using IComponentData = Unity.Entities.IComponentData;
using Colossal.Serialization.Entities;
using Game.Pathfind;
using Unity.Collections;
using Unity.Entities;

namespace PathfindingCustomizer.PathfindSystems.PathfindCost
{
    
    public partial class PathFindSystemBase<T> : GameSystemBase where T : unmanaged, IComponentData // Yess it is unmanaged... I know what I'm doing :) Unity is just annoying
{
    private readonly ILog _logger = LogManager.GetLogger($"{nameof(PathfindingCustomizer)}.{nameof(PathFindSystemBase<T>)}");
    
    protected override void OnUpdate()
    {
        _logger.Info(nameof(OnUpdate));
        ApplyPathfindingSettings();
    }

    protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
    {
        base.OnGameLoadingComplete(purpose, mode);
        _logger.Info(nameof(OnGameLoadingComplete));
        ApplyPathfindingSettings();
    }

    private void ApplyPathfindingSettings()
    {
        _logger.Info($"Applying pathfinding settings for {typeof(T).Name}");
        try
        {
            NativeArray<Entity> entities = EntityManager.CreateEntityQuery(ComponentType.ReadWrite<T>())
                .ToEntityArray(Unity.Collections.Allocator.Persistent);

            var settings = Mod.M_Setting;

            foreach (var entity in entities)
            {
                T oldData = EntityManager.GetComponentData<T>(entity);
                T newData = AdjustPathfindingData(oldData, settings);
                
                EntityManager.SetComponentData(entity, newData);
            }

            entities.Dispose();
            _logger.Info($"Pathfinding settings have been applied for {typeof(T).Name}");

        }
        catch (Exception e)
        {
            _logger.Error($"An error occurred while applying pathfinding settings for {typeof(T).Name}: {e}");
            throw;
        }
    }

    protected virtual T AdjustPathfindingData(T data, Setting settings)
    {
        // Implement specific adjustments for your component data
        // This example assumes T has similar properties as PathfindPedestrianData
        // Adjust according to your actual component data
        return data;
    }

    protected float AdjustCost(float value, int slider)
    {
        return value == 0 ? 0 : value * slider / 100;
    }
}
}