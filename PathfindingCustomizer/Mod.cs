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

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                _log.Info($"Current mod asset at {asset.path}");

            // Register mod settings to game options UI.
            M_Setting = new Setting(this);
            M_Setting.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(M_Setting));
            
            // Load saved settings.
            AssetDatabase.global.LoadSettings(nameof(PathfindingCustomizer), M_Setting, new Setting(this));
            
            updateSystem.UpdateAfter<TraficPathfindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<PedestrianPathFindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<TrackPathFindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<TransportPathFindSystem>(SystemUpdatePhase.LoadSimulation);
            updateSystem.UpdateAfter<ConnectionPathFindSystem>(SystemUpdatePhase.LoadSimulation);
            
            // log that the mod has been loaded
            _log.Info("Pathfinding customizer mod has been loaded");
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