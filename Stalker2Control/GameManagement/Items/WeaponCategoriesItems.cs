namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Provides descriptions for different categories of weapons in the game.
    /// </summary>
    public class WeaponCategoriesItems
    {
        public readonly Dictionary<string, string> GrenadesDescriptions;
        public readonly Dictionary<string, string> SpecialWeaponsDescriptions;
        public readonly Dictionary<string, string> HuntingRiflesDescriptions;
        public readonly Dictionary<string, string> PistolsDescriptions;
        public readonly Dictionary<string, string> SmgsDescriptions;
        public readonly Dictionary<string, string> MachineGunsDescriptions;
        public readonly Dictionary<string, string> SniperRiflesDescriptions;
        public readonly Dictionary<string, string> UniqueWeaponsDescriptions;
        public readonly Dictionary<string, string> AssaultRiflesDescriptions;
        public readonly Dictionary<string, string> DlcWeaponsDescriptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponCategoriesItems"/> class.
        /// </summary>
        public WeaponCategoriesItems()
        {
            GrenadesDescriptions = InitializeGrenadesDescriptions();
            SpecialWeaponsDescriptions = InitializeSpecialWeaponsDescriptions();
            HuntingRiflesDescriptions = InitializeHuntingRiflesDescriptions();
            PistolsDescriptions = InitializePistolsDescriptions();
            SmgsDescriptions = InitializeSmgsDescriptions();
            MachineGunsDescriptions = InitializeMachineGunsDescriptions();
            SniperRiflesDescriptions = InitializeSniperRiflesDescriptions();
            UniqueWeaponsDescriptions = InitializeUniqueWeaponsDescriptions();
            AssaultRiflesDescriptions = InitializeAssaultRiflesDescriptions();
            DlcWeaponsDescriptions = InitializeDlcWeaponsDescriptions();
        }

        private static Dictionary<string, string> InitializeGrenadesDescriptions() =>
            new()
            {
                { "TemplateGrenade", "non-playable item (grenade shell)" },
                { "GrenadeRGD5", "RGD-5" },
                { "GrenadeF1", "F-1" }
            };

        private static Dictionary<string, string> InitializeSpecialWeaponsDescriptions() =>
            new()
            {
                { "GunGauss_SP", "Gauss Gun" },
                { "GunRpg7_GL", "RPG-7u" }
            };

        private static Dictionary<string, string> InitializeHuntingRiflesDescriptions() =>
            new()
            {
                { "GunObrez_SG", "Obrez (Shortened Shotgun)" },
                { "GuardGunObrez_SG", "Guard's Obrez (Shortened Shotgun)" },
                { "GunTOZ_SG", "TOZ-34 (Double-barrel Shotgun)" },
                { "GuardGunTOZ_SG", "Guard's TOZ-34 (Double-barrel Shotgun)" },
                { "GunM860_SG", "M860 Cracker (Pump-action Shotgun)" },
                { "GuardGunM860_SG", "Guard's M860 Cracker (Pump-action Shotgun)" },
                { "GunSPSA_SG", "SPSA-14 (Semi-automatic Shotgun)" },
                { "GuardGunSPSA_SG", "Guard's SPSA-14 (Semi-automatic Shotgun)" },
                { "GunD12_SG", "Saiga D-12 (Semi-automatic Shotgun)" },
                { "GuardGunD12_SG", "Guard's Saiga D-12 (Semi-automatic Shotgun)" },
                { "GunRam2_SG", "RAM-2 (Pump-action Shotgun)" },
                { "GuardGunRam2_SG", "Guard's RAM-2 (Pump-action Shotgun)" }
            };

        private static Dictionary<string, string> InitializePistolsDescriptions() =>
            new()
            {
                { "Gun_ProjectY_HG", "Labyrinth IV (Experimental Pistol)" },
                { "Gun_Deadeye_HG", "False Blindness (Custom Pistol)" },
                { "GunPM_HG", "PTM (Makarov-like Pistol)" },
                { "GuardGunPM_HG", "Guard's PTM (Makarov-like Pistol)" },
                { "GunUDP_HG", "UDP Compact (Compact Pistol)" },
                { "GuardGunUDP_HG", "Guard's UDP Compact (Compact Pistol)" },
                { "GunAPB_HG", "APBS (Modified Handgun)" },
                { "GuardGunAPB_HG", "Guard's APBS (Modified Handgun)" },
                { "GunM10_HG", "M10 Gordon (Handgun)" },
                { "GuardGunM10_HG", "Guard's M10 Gordon (Handgun)" },
                { "GunRhino_HG", "Rhino (Revolver)" },
                { "GuardGunRhino_HG", "Guard's Rhino (Revolver)" }
            };

        private static Dictionary<string, string> InitializeSmgsDescriptions() =>
            new()
            {
                { "GunViper_PP", "Viper-5 (Submachine Gun)" },
                { "GuardGunViper_PP", "Guard's Viper-5 (Submachine Gun)" },
                { "GunAKU_PP", "AKM-74U (Compact Assault Rifle)" },
                { "GuardGunAKU_PP", "Guard's AKM-74U (Compact Assault Rifle)" },
                { "GunBucket_PP", "Buket S-2 (Submachine Gun)" },
                { "GuardGunBucket_PP", "Guard's Buket S-2 (Submachine Gun)" },
                { "GunIntegral_PP", "Integral-A (Integrated Submachine Gun)" },
                { "GuardGunIntegral_PP", "Guard's Integral-A (Integrated Submachine Gun)" },
                { "GunZubr_PP", "Zubr-19 (Submachine Gun)" },
                { "GuardGunZubr_PP", "Guard's Zubr-19 (Submachine Gun)" }
            };

        private static Dictionary<string, string> InitializeMachineGunsDescriptions() =>
            new()
            {
                { "GunPKP_MG", "RPM-74 (Heavy Machine Gun)" },
                { "GuardGunPKP_MG", "Guard's RPM-74 (Heavy Machine Gun)" },
                { "GunPKP_Korshunov_MG", "Beast (Korshunov's Machine Gun)" },
                { "Gun_Tank_MG", "Obzhora (Tank-mounted Machine Gun)" }
            };

        private static Dictionary<string, string> InitializeSniperRiflesDescriptions() =>
            new()
            {
                { "GunSVDM_SP", "SVDM-2 (Sniper Rifle)" },
                { "GuardGunSVDM_SP", "Guard's SVDM-2 (Sniper Rifle)" },
                { "GunMark_SP", "Mark I EMR (Sniper Rifle)" },
                { "GuardGunMark_SP", "Guard's Mark I EMR (Sniper Rifle)" },
                { "GunM701_SP", "M701 Super (Sniper Rifle)" },
                { "GuardGunM701_SP", "Guard's M701 Super (Sniper Rifle)" },
                { "GunSVU_SP", "SVU-MK C-3 (Sniper Rifle)" },
                { "GuardGunSVU_SP", "Guard's SVU-MK C-3 (Sniper Rifle)" },
                { "GunGvintar_ST", "SV 'Vintar' (Sniper Rifle)" },
                { "GuardGunGvintar_ST", "Guard's SV 'Vintar' (Sniper Rifle)" },
                { "GunSVU_Sniper_Duga_SP", "SVU-MK C-3 (Sniper Rifle)" }
            };

        private static Dictionary<string, string> InitializeUniqueWeaponsDescriptions() =>
            new()
            {
                { "Gun_Sharpshooter_AR", "Popados (Sharp Shooter)" },
                { "Gun_SkifGun_HG", "Skif's Pistol" },
                { "Gun_Lummox_AR", "AKM-74S Grisha Valenka (Grisha Valenka's AKM-74S)" },
                { "Gun_Decider_AR", "Reshala (Decider)" },
                { "Gun_Kaimanov_HG", "Game Exit (Kaimanov's Pistol)" },
                { "Gun_GStreet_HG", "Gangster (Street Gun)" },
                { "Gun_Encourage_HG", "Mentor (Encourage)" },
                { "Gun_Shakh_SMG", "Checkmate (Shah and Mat)" },
                { "Gun_RatKiller_SMG", "Ratkiller (Ratkiller SMG)" },
                { "Gun_Spitfire_SMG", "Rapid Fire (Spitfire SMG)" },
                { "Gun_Krivenko_HG", "Gambit (Krivenko's Pistol)" },
                { "Gun_Lynx_SR", "Lynx (Sniper Rifle)" },
                { "Gun_Whip_SR", "Whip (Whip Sniper Rifle)" },
                { "Gun_Predator_SG", "Predator (Shotgun)" },
                { "Gun_Sledgehammer_SG", "Sledgehammer (Hammer Shotgun)" },
                { "Gun_Texas_SG", "Texan (Texas Shotgun)" },
                { "Gun_Merc_AR", "Mercenary (Merc's Assault Rifle)" },
                { "Gun_Spitter_SMG", "Spitter (Spitting Submachine Gun)" },
                { "Gun_Silence_SMG", "Special Forces (Silenced SMG)" },
                { "Gun_Combatant_AR", "Combatant (Combat Assault Rifle)" },
                { "Gun_Drowned_AR", "Drowned (Drowned Assault Rifle)" },
                { "Gun_Sotnyk_AR", "Sotnik (Sotnik Assault Rifle)" },
                { "Gun_Trophy_AR", "Trophy (Trophy Assault Rifle)" },
                { "Gun_Partner_SR", "Partner (Partner Sniper Rifle)" },
                { "Gun_Veteran_AR", "Veteran (Veteran Assault Rifle)" }
            };

        private static Dictionary<string, string> InitializeAssaultRiflesDescriptions() =>
            new()
            {
                { "GunAK74_ST", "AKM-74S" },
                { "GuardGunAK74_ST", "AKM-74S" },
                { "GunM16_ST", "AR416" },
                { "GuardGunM16_ST", "AR416" },
                { "GunG37_ST", "GP 37" },
                { "GuardGunG37_ST", "GP 37" },
                { "GunFora_ST", "Fora-221" },
                { "GuardGunFora_ST", "Fora-221" },
                { "GunGrim_ST", "Grom S-14" },
                { "GuardGunGrim_ST", "Grom S-14" },
                { "GunKharod_ST", "Kharod" },
                { "GuardGunKharod_ST", "Kharod" },
                { "GunLavina_ST", "SA Lavina" },
                { "GuardGunLavina_ST", "SA Lavina" },
                { "GunDnipro_ST", "Dnipro" },
                { "GuardGunDnipro_ST", "Dnipro" },
                { "Gun_S15_AR", "Grom S-15" }
            };

        private static Dictionary<string, string> InitializeDlcWeaponsDescriptions() =>
            new()
            {
                { "Gun_ShotgunMonolith_SG 0 1 1", "" },
                { "Gun_RifleMonolith_AR 0 1 1", "" },
                { "Gun_PistolMonolith_HG 0 1 1", "" },
                { "Gun_Logarithm_SMG 0 1 1", "" },
                { "Gun_Zvirolov_SR 0 1 1", "" },
                { "Gun_Gabion_AR 0 1 1", "" },
                { "Gun_Veteran_AR 0 1 1", "" },
                { "Gun_ModelSpecial_HG 0 1 1", "" },
                { "Gun_SMGMonolith_SMG 0 1 1", "" },
                { "Gun_Novator_AR 0 1 1", "" },
                { "Gun_Margach_SG 0 1 1", "" }
            };
    }
}