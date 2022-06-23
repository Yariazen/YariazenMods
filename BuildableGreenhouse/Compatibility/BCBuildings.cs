
using Microsoft.Xna.Framework;

namespace BuildableGreenhouse.Compatibility
{
    partial class ModCompatibility
    {
        public static void applyBCBuildingsCompatibility()
        {
            if (Helper.ModRegistry.IsLoaded("leclair.bcbuildings"))
            {
                Monitor.Log($"{Manifest.UniqueID} applying BCBuildings compatibility");
                bcbuildingsCompatibility();
            }
        }

        private static void bcbuildingsCompatibility()
        {
            IBCBuildingsApi bCBuildingsApi = Helper.ModRegistry.GetApi<IBCBuildingsApi>("leclair.bcbuildings");

            bCBuildingsApi.AddBlueprint("BuildableGreenhouse", null, null);
            bCBuildingsApi.SetTextureSourceRect("BuildableGreenhouse", new Rectangle(0, 160, 112, 160));
        }
    }
    public interface IBCBuildingsApi
    {
        void AddBlueprint(string name, string? displayCondition, string? buildCondition);
        void SetTextureSourceRect(string name, Rectangle? rect);
    }
}