namespace BuildableGreenhouse
{
    public class ModConfig
    {
        public string _StartWithGreenhouse { get; set; } = I18n.BuildableGreenhouse_StartWithGreenhouse_Tooltip();
        public bool StartWithGreenhouse { set; get; } = false;

        public string _BuildCostDescription { get; set; } = I18n.BuildableGreenhouse_BuildCost_Tooltip();
        public int BuildCost { get; set; } = 100000;

        public string _BuildDaysDescription { get; set; } = I18n.BuildableGreenhouse_BuildDays_Tooltip();
        public int BuildDays { get; set; } = 3;

        public string _BuildingDifficulty { get; set; } = I18n.BuildableGreenhouse_BuildingDifficulty_Tooltip();
        public int BuildingDifficulty { get; set; } = 2;
    }
}