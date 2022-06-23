using StardewModdingAPI;

namespace BuildableGreenhouse
{
    public class ModPatch
    {
        private static IMonitor Monitor;
        private static IModHelper Helper;

        public static void Initialize(IModHelper helper, IMonitor monitor)
        {
            Monitor = monitor;
            Helper = helper;
        }
    }
}
