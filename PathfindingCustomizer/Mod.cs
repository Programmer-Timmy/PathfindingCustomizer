using System;
using System.Collections.Generic;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using Colossal.IO.AssetDatabase;
using PathfindingCustomizer.PathfindSystems;
using PathfindingCustomizer.PathfindSystems.PathfindCost;
using Unity.Entities;

namespace PathfindingCustomizer
{
    public class Mod : IMod
    { 
        private static ILog _log = LogManager.GetLogger($"{nameof(PathfindingCustomizer)}.{nameof(Mod)}")
            .SetShowsErrorsInUI(false);

        public static Setting M_Setting;

        public void OnLoad(UpdateSystem updateSystem)
        {
            _log.Info(nameof(OnLoad));
            try
            {
                // Register settings and localization
                RegisterSettings();
                LoadLocalization();

                // Apply updates to systems
                ApplySystemUpdates(updateSystem);

                _log.Info("Pathfinding customizer mod has been loaded");
            }
            catch (Exception ex)
            {
                _log.Error($"Error loading mod: {ex.Message}");
                throw;
            }
        }
        
        private void RegisterSettings()
        {
            M_Setting = new Setting(this);
            M_Setting.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(M_Setting));
        }

        private void LoadLocalization()
        {
            AssetDatabase.global.LoadSettings(nameof(PathfindingCustomizer), M_Setting, new Setting(this));
        }

        private void ApplySystemUpdates(UpdateSystem updateSystem)
        {
            updateSystem.UpdateAfter<TraficPathfindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<PedestrianPathFindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<TrackPathFindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<TransportPathFindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<ConnectionPathFindSystem>(SystemUpdatePhase.LoadSimulation);
        }

        public void OnDispose()
        {
            _log.Info(nameof(OnDispose));
            if (M_Setting != null)
            {
                M_Setting.UnregisterInOptionsUI();
                M_Setting = null;
            }
        }
        
    }
}