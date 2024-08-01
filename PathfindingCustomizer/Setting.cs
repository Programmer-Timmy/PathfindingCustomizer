using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System.Collections.Generic;

namespace PathfindingCustomizer
{
    [FileLocation(nameof(PathfindingCustomizer))]
    [SettingsUIGroupOrder(kVehicleSettings, kPedestrianSettings, kDetailsAndSupport)]
    [SettingsUIShowGroupName(kVehicleSettings, kPedestrianSettings, kDetailsAndSupport)]
    public class Setting : ModSetting
    {
        public const string kSection = "Main";

        // Section names
        public const string kVehicleSettings = "Vehicle Settings";
        public const string kPedestrianSettings = "Pedestrian Settings";    
        public const string kDetailsAndSupport = "Version Details & Support";

        public Setting(IMod mod) : base(mod)
        {
            UnsafeTurningSlider = UnsafeTurningSlider == 0 ? 100 : UnsafeTurningSlider;
            UnsafeUTurnSlider = UnsafeUTurnSlider == 0 ? 100 : UnsafeUTurnSlider;
            ForbiddenSlider = ForbiddenSlider == 0 ? 100 : ForbiddenSlider;
            UnsafeCrossingSlider = UnsafeCrossingSlider == 0 ? 150 : UnsafeCrossingSlider;
            CrossingSlider = CrossingSlider == 0 ? 100 : CrossingSlider;
            SpawnSlider = SpawnSlider == 0 ? 100 : SpawnSlider;
            WalkingSlider = WalkingSlider == 0 ? 100 : WalkingSlider;
            DrivingSlider = DrivingSlider == 0 ? 100 : DrivingSlider;
            ParkingSlider = ParkingSlider == 0 ? 100 : ParkingSlider;
            TurningSlider = TurningSlider == 0 ? 100 : TurningSlider;
            LaneCrossingSlider = LaneCrossingSlider == 0 ? 100 : LaneCrossingSlider;
            TraficSpawnSlider = TraficSpawnSlider == 0 ? 100 : TraficSpawnSlider;
        }

        // Vehicle settings
        [SettingsUISection(kSection, kVehicleSettings)]
        
        // Important note for vehicle settings
        [SettingsUIMultilineText]
        public string ImportantNote => string.Empty;
        
        [SettingsUISection(kSection, kVehicleSettings)]
        [SettingsUIMultilineText]
        public string Note => string.Empty;

        // Unsafe turning
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int UnsafeTurningSlider { get; set; }
        
        // Unsafe U-turn
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int UnsafeUTurnSlider { get; set; }
        
        // Forbidden
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int ForbiddenSlider { get; set; }
        
        // Driving cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int DrivingSlider { get; set; }
        
        // Parking cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int ParkingSlider { get; set; }
        
        // Turning cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int TurningSlider { get; set; }
        
        // Lane changing cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int LaneCrossingSlider { get; set; }
        
        // Traffic spawn cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int TraficSpawnSlider { get; set; }
        
        // Pedestrian settings
        [SettingsUISection(kSection, kPedestrianSettings)]
        
        // Unsafe crossing
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int UnsafeCrossingSlider { get; set; } 
        
        // Crosswalk cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int CrossingSlider { get; set; }
        
        // Pedestrian spawn cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int SpawnSlider { get; set; }
        
        // Walking cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int WalkingSlider { get; set; }
        
        // Version and support
        [SettingsUISection(kSection, kDetailsAndSupport)]
        public string Version => "v1.0.4";
        
        // Author
        [SettingsUISection(kSection, kDetailsAndSupport)]
        public string Author => "Programmer Timmy";
        
        // Support information
        [SettingsUISection(kSection, kDetailsAndSupport)]
        [SettingsUIMultilineText]
        public string Support => string.Empty;
        
        public override void SetDefaults()
        {
            // Vehicle settings
            UnsafeTurningSlider = 100;
            UnsafeUTurnSlider = 100;
            ForbiddenSlider = 100;
            DrivingSlider = 100;
            ParkingSlider = 100;
            TurningSlider = 100;
            LaneCrossingSlider = 100;
            TraficSpawnSlider = 100;
            
            // Pedestrian settings
            UnsafeCrossingSlider = 150;
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
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Main" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kVehicleSettings), "Vehicle Settings" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPedestrianSettings), "Pedestrian Settings" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kDetailsAndSupport), "Version Details & Support" },

                // Labels
                
                // Unsafe turning
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeTurningSlider)), "Unsafe Turning Cost" },
                
                // Unsafe U-turn
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeUTurnSlider)), "Unsafe U-turn Cost" },
                
                // Forbidden
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ForbiddenSlider)), "Forbidden Cost" },
                
                // Driving cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.DrivingSlider)), "Driving Cost" },
                
                // Parking cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkingSlider)), "Parking Cost" },
                
                // Turning cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TurningSlider)), "Turning Cost" },
                
                // Lane changing cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.LaneCrossingSlider)), "Lane Changing Cost" },
                
                // Spawn cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TraficSpawnSlider)), "Spawn Cost" },
                
                // Unsafe crossing
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeCrossingSlider)), "Unsafe Crossing Cost" },
                
                // Crosswalk cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.CrossingSlider)), "Crosswalk Cost" },
                
                // Pedestrian spawn cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SpawnSlider)), "Pedestrian Spawn Cost" },
                
                // Walking cost
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.WalkingSlider)), "Walking Cost" },
                
                // Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Note)), "NOTE: The game needs a restart to apply the changes." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ImportantNote)), "NOTE: These settings multiply the default values of all vehicles. The default value is 100%. Extreme values can cause unexpected behavior and no population growth. Larger cities are less affected. Use at your own risk." },

                // Version and support
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Version)), "Version" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Author)), "Author" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.Support)), "If you have any questions or need help, visit the mod page on the workshop to leave a comment or report issues on our GitHub page. Log files are helpful for troubleshooting and can be found at `%appdata%/../LocalLow/Colossal Order/Cities Skylines/Logs`." },

                // Descriptions 
                
                // Unsafe turning
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeTurningSlider)), "Default is 100%. Increasing this value reduces the frequency of unsafe turns by vehicles, promoting more cautious driving." },
                
                // Unsafe U-turn
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeUTurnSlider)), "Default is 100%. Increasing this value reduces the frequency of unsafe U-turns by vehicles, promoting more cautious behavior." },
                
                // Forbidden
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ForbiddenSlider)), "Default is 100%. Increasing this value reduces the frequency of forbidden turns by vehicles, promoting more cautious behavior." },
                
                // Driving cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.DrivingSlider)), "Default is 100%. Increasing this value reduces the frequency of driving by vehicles, promoting more cautious behavior." },
                
                // Parking cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkingSlider)), "Default is 100%. Increasing this value reduces the frequency of parking by vehicles, promoting more cautious behavior." },
                
                // Turning cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TurningSlider)), "Default is 100%. Increasing this value reduces the frequency of turns by vehicles, promoting more cautious behavior." },
                
                // Lane changing cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.LaneCrossingSlider)), "Default is 100%. Increasing this value reduces the frequency of lane changes by vehicles, promoting more cautious behavior." },
                
                // Spawn cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TraficSpawnSlider)), "Default is 100%. Increasing this value reduces the frequency of vehicle spawns, promoting more cautious behavior." },
                
                // Unsafe crossing
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeCrossingSlider)), "Default is 100%. Increasing this value reduces the frequency of unsafe crossings by pedestrians, promoting more cautious behavior." },
                
                // Crosswalk cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.CrossingSlider)), "Default is 100%. Increasing this value reduces the frequency of crosswalk usage by pedestrians, promoting more cautious behavior." },
                
                // Pedestrian spawn cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SpawnSlider)), "Default is 100%. Increasing this value reduces the frequency of pedestrian spawns, promoting more cautious behavior." },
                
                // Walking cost
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.WalkingSlider)), "Default is 100%. Increasing this value reduces the frequency of walking by pedestrians, promoting more cautious behavior." },
                
                // Version and support
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Version)), "The current version of the mod." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.Author)), "The author of the mod." },
            };
        }

        public void Unload()
        {
        }
    }
}
