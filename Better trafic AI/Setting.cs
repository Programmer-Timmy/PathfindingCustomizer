using System;
using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System.Collections.Generic;

namespace Better_trafic_AI
{
    [FileLocation(nameof(Better_trafic_AI))]
    [SettingsUIGroupOrder(kVehicleSettings, kPedestrianSettings)]
    [SettingsUIShowGroupName(kVehicleSettings, kPedestrianSettings)]
    public class Setting : ModSetting
    {
        public const string kSection = "Main";

        public const string kVehicleSettings = "Vehicle settings";
        public const string kPedestrianSettings = "Pedestrian settings";    
        
        public Setting(IMod mod) : base(mod)
        {
            if (UnsafeTurningSlider == 0) SetDefaults();
        }
        
        // Vehicle settings
        [SettingsUISection(kSection, kVehicleSettings)]
        
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
        
        // Pedestrian settings
        [SettingsUISection(kSection, kPedestrianSettings)]
        
        // Unsafe crossing
        [SettingsUISlider(min = 0, max = 500, step = 1, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(kSection, kPedestrianSettings)]
        public int UnsafeCrossingSlider { get; set; } 
        
        // add a text 
        [SettingsUISection(kSection, kPedestrianSettings)]
        public string Note => "NOTE: The game needs a restart to apply the changes.";
        
        public override void SetDefaults()
        {
            // Vehicle settings
            UnsafeTurningSlider = 100;
            UnsafeUTurnSlider = 100;
            ForbiddenSlider = 100;
            
            // Pedestrian settings
            UnsafeCrossingSlider = 100;
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
                { m_Setting.GetSettingsLocaleID(), "Better Traffic AI" },
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
                
                // Unsafe crossing
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.UnsafeCrossingSlider)),
                    "Unsafe crossing (Jaywalking) cost"
                },
                // Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.Note)),
                    "Note"
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
                
                // Unsafe crossing
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.UnsafeCrossingSlider)),
                    "Default is 100%. Increasing this value will make pedestrians avoid unsafe crossings more frequently. Higher values will lead to more cautious behavior, reducing the likelihood of unsafe crossings."
                },
                
                // Notes
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.Note)),
                    "NOTE: The game needs a restart to apply the changes."
                }
                
            };
        }

        public void Unload()
        {
        }
        
        
    }
}
