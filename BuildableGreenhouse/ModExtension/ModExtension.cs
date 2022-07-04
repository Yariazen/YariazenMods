using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace BuildableGreenhouse.ModExtension
{
    public partial class ModExtension
    {
        private static IMonitor Monitor;
        private static IModHelper Helper;
        private static IManifest Manifest;
        private static ModConfig Config;

        private static partial void SolidFoundationsExtension();
        private static partial void GenericModConfigMenuExtention();

        private static partial void GreenhouseCompatibility();

        public static void Initialize(IModHelper helper, IMonitor monitor, IManifest manifest)
        {
            Monitor = monitor;
            Helper = helper;
            Manifest = manifest;
            Config = helper.ReadConfig<ModConfig>();

            Helper.Events.GameLoop.GameLaunched += initializeAPIs;

            SolidFoundationsExtension();
            GenericModConfigMenuExtention();

            GreenhouseCompatibility();
        }

        private static void initializeAPIs(object sender, GameLaunchedEventArgs e)
        {
            Monitor.Log($"{Manifest.UniqueID} hooking into Apis", LogLevel.Trace);
            if (Helper.ModRegistry.IsLoaded("PeacefulEnd.SolidFoundations"))
            {
                Monitor.Log($"{Manifest.UniqueID} hooking into SolidFoundations Api", LogLevel.Trace);
                SolidFoundationsApi = Helper.ModRegistry.GetApi<ISolidFoundationsApi>("PeacefulEnd.SolidFoundations");
            }
            if (Helper.ModRegistry.IsLoaded("spacechase0.GenericModConfigMenu"))
            {
                Monitor.Log($"{Manifest.UniqueID} hooking into GMCM Api", LogLevel.Trace);
                GenericModConfigMenuApi = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            }
        }
    }
}
