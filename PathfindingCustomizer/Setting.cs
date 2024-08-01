using System;
using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System.Collections.Generic;
using UnityEngine;

namespace PathfindingCustomizer
{
    [FileLocation(nameof(PathfindingCustomizer))]
    [SettingsUIGroupOrder(kVehicleSettings, kPedestrianSettings)]
    [SettingsUIShowGroupName(kVehicleSettings, kPedestrianSettings)]
    public class Setting : ModSetting
    {
        public const string kSection = "Main";

        public const string kVehicleSettings = "Vehicle settings";
        public const string kPedestrianSettings = "Pedestrian settings";    
        
        public Setting(IMod mod) : base(mod)
        {
            if (UnsafeTurningSlider == 0) UnsafeTurningSlider = 100;
            if (UnsafeUTurnSlider == 0) UnsafeUTurnSlider = 100;
            if (ForbiddenSlider == 0) ForbiddenSlider = 100;
            if (UnsafeCrossingSlider == 0) UnsafeCrossingSlider = 150;
            if (CrossingSlider == 0) CrossingSlider = 100;
            if (SpawnSlider == 0) SpawnSlider = 100;
            if (WalkingSlider == 0) WalkingSlider = 100;
            if (DrivingSlider == 0) DrivingSlider = 100;
            if (ParkingSlider == 0) ParkingSlider = 100;
            if (TurningSlider == 0) TurningSlider = 100;
            if (LaneCrossingSlider == 0) LaneCrossingSlider = 100;
            if (TraficSpawnSlider == 0) TraficSpawnSlider = 100;
        }
        
        // Vehicle settings
        [SettingsUISection(kSection, kVehicleSettings)]
        
        //imporant note for vehicle settings
        public string ImportantNote => "NOTE: These settings multiply the default values of all vehicles. The default value is 100%.";
        
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
        
        // driving cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int DrivingSlider { get; set; }
        
        // parking cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int ParkingSlider { get; set; }
        
        // turning cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int TurningSlider { get; set; }
        
        // lane changing cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int LaneCrossingSlider { get; set; }
        
        // spawn cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kVehicleSettings)]
        public int TraficSpawnSlider { get; set; }
        
        // Pedestrian settings
        [SettingsUISection(kSection, kPedestrianSettings)]
        
        // Unsafe crossing
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int UnsafeCrossingSlider { get; set; } 
        
        // crosswalk cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int CrossingSlider { get; set; }
        
        // spawn cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int SpawnSlider { get; set; }
        
        // walking cost
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int WalkingSlider { get; set; }
        
        // add a text 
        [SettingsUISection(kSection, kPedestrianSettings)]
        public string Note => "NOTE: The game needs a restart to apply the changes.";
        
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

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Main
                { m_Setting.GetSettingsLocaleID(), "Pathfinding Customizer" },
                { m_Setting.GetOptionTabLocaleID(Setting.kSection), "Main" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.kVehicleSettings), "Vehicle settings" },
                { m_Setting.GetOptionGroupLocaleID(Setting.kPedestrianSettings), "Pedestrian settings" },

                // Labels
                
               
                
                // Unsafe turning
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeTurningSlider)),
                    "Unsafe turning cost"
                },
                
                // Unsafe U-turn
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeUTurnSlider)),
                    "Unsafe U-turn cost"
                },
                
                // Forbidden
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ForbiddenSlider)),
                    "Forbidden cost"
                },
                
                // driving cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.DrivingSlider)),
                    "Driving cost"
                },
                
                // parking cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkingSlider)),
                    "Parking cost"
                },
                
                // turning cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.TurningSlider)),
                    "Turning cost"
                },
                
                // lane changing cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.LaneCrossingSlider)),
                    "Lane changing cost"
                },
                
                // spawn cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.TraficSpawnSlider)),
                    "Spawn cost"
                },
                
                // Unsafe crossing
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeCrossingSlider)),
                    "Unsafe crossing (Jaywalking) cost"
                },
                // crosswalk cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.CrossingSlider)),
                    "Crosswalk cost"
                },
                // spawn cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.SpawnSlider)),
                    "Spawn cost"
                },
                // walking cost
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.WalkingSlider)),
                    "Walking cost"
                },
                
                // Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Note)),
                    "Note:"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.ImportantNote)),
                    "Important Note:"
                },
                
                // Descriptions 
                // Unsafe turning
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeTurningSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid unsafe turns more frequently. Higher values will lead to more cautious driving behavior, reducing the likelihood of unsafe turns."
                },
                
                // Unsafe U-turn
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeUTurnSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid unsafe U-turns more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of unsafe U-turns."
                },
                
                // Forbidden
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ForbiddenSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid forbidden turns more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of forbidden turns."
                },
                
                // driving cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.DrivingSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid driving more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of driving."
                },
                // parking cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkingSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid parking more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of parking."
                },
                
                // turning cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TurningSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid turning more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of turning."
                },
                // lane changing cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.LaneCrossingSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid lane changing more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of lane changing."
                },
                
                // spawn cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.TraficSpawnSlider)),
                    "Default is 100%. Increasing this value will make vehicles avoid spawning more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of spawning."
                },
                
                // Unsafe crossing
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeCrossingSlider)),
                    "Default is 100%. Increasing this value will make pedestrians avoid unsafe crossings more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of unsafe crossings."
                },
                // crosswalk cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.CrossingSlider)),
                    "Default is 100%. Increasing this value will make pedestrians avoid crosswalks more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of using crosswalks."
                },
                // spawn cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.SpawnSlider)),
                    "Default is 100%. Increasing this value will make pedestrians avoid spawning more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of spawning."
                },
                // walking cost
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.WalkingSlider)),
                    "Default is 100%. Increasing this value will make pedestrians avoid walking more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of walking."
                },
                
                // Notes
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Note)),
                    "The game needs a restart to apply the changes."
                },

                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.ImportantNote)),
                    "These settings multiply the default values of all vehicles. The default value is 100%."
                }
                
            };
        }

        public void Unload()
        {
        }
        
        
    }
}
