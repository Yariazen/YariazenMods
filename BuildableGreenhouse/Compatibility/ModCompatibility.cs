using StardewModdingAPI;
using StardewValley.Buildings;
using System.Collections.Generic;
using StardewModdingAPI.Events;

namespace BuildableGreenhouse.Compatibility
{
    partial class ModCompatibility
    {
        private static IMonitor Monitor;
        private static IModHelper Helper;
        private static IManifest Manifest;
        private static ModConfig Config;

        public static Dictionary<string, Building> Greenhouses;

        public static void Initialize(IModHelper helper, IMonitor monitor, IManifest manifest)
        {
            Monitor = monitor;
            Helper = helper;
            Manifest = manifest;

            Config = helper.ReadConfig<ModConfig>();
            Greenhouses = new Dictionary<string, Building>();

            Helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            Helper.Events.GameLoop.DayStarted += OnDayStarted;
        }

        private static void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            applyGMCMCompatibility();
            applyBCBuildingsCompatibility();
        }

        private static void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            applyGreenhouseUpgradesCompatibility();
        }
    }
}