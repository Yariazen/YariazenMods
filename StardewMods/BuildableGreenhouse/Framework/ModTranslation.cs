using StardewModdingAPI;

namespace BuildableGreenhouse.Framework
{
    public class ModTranslation
    {
        public static string StartWithGreenhouse_Name;
        public static string StartWithGreenhouse_Tooltip;
        public static string BuildCost_Name;
        public static string BuildCost_Tooltip;
        public static string BuildDays_Name;
        public static string BuildDays_Tooltip;
        public static string BuildingDifficulty_Name;
        public static string BuildingDifficulty_Tooltip;

        public static void InitializeTranslations(IModHelper helper)
        {
            StartWithGreenhouse_Name = helper.Translation.Get("BuildableGreenhouse.StartWithGreenhouse.Name");
            StartWithGreenhouse_Tooltip = helper.Translation.Get("BuildableGreenhouse.StartWithGreenhouse.Tooltip");
            BuildCost_Name = helper.Translation.Get("BuildableGreenhouse.BuildCost.Name");
            BuildCost_Tooltip = helper.Translation.Get("BuildableGreenhouse.BuildCost.Tooltip");
            BuildDays_Name = helper.Translation.Get("BuildableGreenhouse.BuildDays.Name");
            BuildDays_Tooltip = helper.Translation.Get("BuildableGreenhouse.BuildDays.Tooltip");
            BuildingDifficulty_Name = helper.Translation.Get("BuildableGreenhouse.BuildingDifficulty.Name");
            BuildingDifficulty_Tooltip = helper.Translation.Get("BuildableGreenhouse.BuildingDifficulty.Tooltip");
        }
    }
}
