using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System.Collections.Generic;

namespace PathfindingCustomizer
{
    [FileLocation(nameof(PathfindingCustomizer))]
    [SettingsUIGroupOrder(kVehicleSettings, kPedestrianSettings, kDetailsAndSupport, kAdvancedSettingsTemp)]
    [SettingsUIShowGroupName(kVehicleSettings, kPedestrianSettings, kDetailsAndSupport, kAdvancedSettingsTemp)]
    public class Setting : ModSetting
    {
        public const string kBasicSettings = "Basic";
        public const string kAdvancedSettings = "Advanced";
        public const string kVehicleSettings = "Vehicle Settings";
        public const string kPedestrianSettings = "Pedestrian Settings";
        public const string kDetailsAndSupport = "Version Details & Support";
        public const string kAdvancedSettingsTemp = "Advanced Settings";

        public Setting(IMod mod) : base(mod)
        {
            // Ensure default values are set if properties are uninitialized
            UnsafeTurningSlider = EnsureDefaultValue(UnsafeTurningSlider);
            UnsafeUTurnSlider = EnsureDefaultValue(UnsafeUTurnSlider);
            ForbiddenSlider = EnsureDefaultValue(ForbiddenSlider);
            UnsafeCrossingSlider = EnsureDefaultValue(UnsafeCrossingSlider);
            CrossingSlider = EnsureDefaultValue(CrossingSlider);
            SpawnSlider = EnsureDefaultValue(SpawnSlider);
            WalkingSlider = EnsureDefaultValue(WalkingSlider);
            DrivingSlider = EnsureDefaultValue(DrivingSlider);
            ParkingSlider = EnsureDefaultValue(ParkingSlider);
            TurningSlider = EnsureDefaultValue(TurningSlider);
            LaneSwitchSlider = EnsureDefaultValue(LaneSwitchSlider);
            TraficSpawnSlider = EnsureDefaultValue(TraficSpawnSlider);
        }

        private int EnsureDefaultValue(int value)
        {
            return value == 0 ? 100 : value;
        }

        // Vehicle settings
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        [SettingsUIMultilineText]
        public string ImportantNote => string.Empty;

        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        [SettingsUIMultilineText]
        public string Note => string.Empty;

        // Settings
        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int UnsafeTurningSlider { get; set; }

        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int UnsafeUTurnSlider { get; set; }

        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int ForbiddenSlider { get; set; }

        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int DrivingSlider { get; set; }

        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int ParkingSlider { get; set; }

        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int TurningSlider { get; set; }

        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int LaneSwitchSlider { get; set; }

        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kBasicSettings, kVehicleSettings)]
        public int TraficSpawnSlider { get; set; }

        [SettingsUISection(kBasicSettings, kPedestrianSettings)]
        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int UnsafeCrossingSlider { get; set; } 

        [SettingsUISection(kBasicSettings, kPedestrianSettings)]
        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int CrossingSlider { get; set; }

        [SettingsUISection(kBasicSettings, kPedestrianSettings)]
        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int SpawnSlider { get; set; }

        [SettingsUISection(kBasicSettings, kPedestrianSettings)]
        [SettingsUISlider(min = 0, max = 1000, step = 5, scalarMultiplier = 1, unit = Unit.kPercentage)]
        public int WalkingSlider { get; set; }

        [SettingsUISection(kBasicSettings, kDetailsAndSupport)]
        public string Version => "v1.0.9";

        [SettingsUISection(kBasicSettings, kDetailsAndSupport)]
        public string Author => "Programmer Timmy (Cosmic Pioneer)";

        [SettingsUISection(kBasicSettings, kDetailsAndSupport)]
        [SettingsUIMultilineText]
        public string Support => "For questions or assistance, visit the mod page on the workshop or report issues on our GitHub page. Log files useful for troubleshooting can be found at `%appdata%/../LocalLow/Colossal Order/Cities Skylines/Logs`.";

        // Advanced Settings
        [SettingsUISection(kAdvancedSettings, kAdvancedSettingsTemp)]
        public string ComingSoon => "COMING SOON: Advanced settings documentation and options are being developed. Stay tuned for updates. UPDATE: I dont have a lot of time to work on this mod anymore. If you want to contribute, go the the GitHub page and submit a pull request. I will review it and merge it if it is good. Thank you for your support.";

        public override void SetDefaults()
        {
            UnsafeTurningSlider = 100;
            UnsafeUTurnSlider = 100;
            ForbiddenSlider = 100;
            DrivingSlider = 100;
            ParkingSlider = 100;
            TurningSlider = 100;
            LaneSwitchSlider = 100;
            TraficSpawnSlider = 100;

            UnsafeCrossingSlider = 100;
            CrossingSlider = 100;
            SpawnSlider = 100;
            WalkingSlider = 100;
        }
    }

    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Main
                { m_Setting.GetSettingsLocaleID(), "Pathfinding Customizer" },
                { m_Setting.GetOptionTabLocaleID(Setting.kBasicSettings), "Basic"},
                { m_Setting.GetOptionTabLocaleID(Setting.kAdvancedSettings), "Advanced" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kVehicleSettings), "Vehicle Settings" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPedestrianSettings), "Pedestrian Settings" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDetailsAndSupport), "Version Details & Support" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kAdvancedSettingsTemp), "Advanced Settings" },

                // Labels
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeTurningSlider)), "Unsafe Turning Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeUTurnSlider)), "Unsafe U-turn Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ForbiddenSlider)), "Forbidden Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DrivingSlider)), "Driving Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkingSlider)), "Parking Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TurningSlider)), "Turning Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.LaneSwitchSlider)), "Lane Changing Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TraficSpawnSlider)), "Spawn Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeCrossingSlider)), "Unsafe Crossing Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CrossingSlider)), "Crosswalk Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SpawnSlider)), "Pedestrian Spawn Cost" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WalkingSlider)), "Walking Cost" },

                // Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Note)), "NOTE: Save your current game and reload it, or restart the game to apply changes." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ImportantNote)), "NOTE: These settings adjust the default values for all vehicles. The default value is 100%. Extreme values may cause unexpected behavior and hinder population growth. Each city is affected differently. Increase values gradually to find the optimal settings for your city. Use at your own risk. In very large cities, higher settings may impact performance." },

                // Version and support
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Version)), "Version" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Author)), "Author" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Support)), "For questions or assistance, visit the mod page on the workshop or report issues on our GitHub page. Log files useful for troubleshooting can be found at `%appdata%/../LocalLow/Colossal Order/Cities Skylines/Logs`." },

                // Descriptions
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeTurningSlider)), "Default is 100%. Increasing this value reduces the frequency of unsafe turns by vehicles, promoting more cautious driving. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeUTurnSlider)), "Default is 100%. Increasing this value reduces the frequency of unsafe U-turns by vehicles, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ForbiddenSlider)), "Default is 100%. Increasing this value reduces the frequency of forbidden turns by vehicles, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DrivingSlider)), "Default is 100%. Increasing this value reduces the frequency of driving by vehicles, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkingSlider)), "Default is 100%. Increasing this value reduces the frequency of parking by vehicles, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TurningSlider)), "Default is 100%. Increasing this value reduces the frequency of turns by vehicles, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.LaneSwitchSlider)), "Default is 100%. Increasing this value reduces the frequency of lane changes by vehicles, promoting more cautious behavior. This setting can be more extreme than others." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TraficSpawnSlider)), "Default is 100%. Increasing this value reduces the frequency of vehicle spawns, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeCrossingSlider)), "Default is 100%. Increasing this value reduces the frequency of unsafe crossings by pedestrians, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CrossingSlider)), "Default is 100%. Increasing this value reduces the frequency of crosswalk usage by pedestrians, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SpawnSlider)), "Default is 100%. Increasing this value reduces the frequency of pedestrian spawns, promoting more cautious behavior. Increase values slowly to observe changes." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.WalkingSlider)), "Default is 100%. Increasing this value reduces the frequency of walking by pedestrians, promoting more cautious behavior. Increase values slowly to observe changes." },
                
                // Version and support
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Version)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Author)), "Author" },
               
                // Advanced Settings
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ComingSoon)), "Advanced Settings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ComingSoon)), "COMING SOON: Advanced settings documentation and options are being developed. Stay tuned for updates." }
            };
        }

        public void Unload()
        {
        }
    }
}
