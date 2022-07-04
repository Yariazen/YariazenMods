using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;
using System.Collections.Generic;
using System.Linq;

namespace BuildableGreenhouse.ModExtension
{
	public partial class ModExtension
	{
		private static List<Building> GreenhouseList;
		private static partial void GreenhouseCompatibility()
		{
			Helper.Events.GameLoop.DayStarted += GreenhouseOnDayStarted;

			Helper.ConsoleCommands.Add("player_buildinglist", "PopulateBuildingList", GreenhouseCompatibilityConsoleCommands);
		}

		private static void GreenhouseOnDayStarted(object sender, DayStartedEventArgs e)
        {
			populateGreenhouseList();
        }

		private static void populateGreenhouseList(bool console = false)
        {
			LogLevel loglevel = console ? LogLevel.Info : LogLevel.Trace;
			List<Building> buildinglist = Game1.getFarm().buildings.ToList();
			foreach (Building building in buildinglist)
			{
				if (building.buildingType.Value == "BuildableGreenhouse.Greenhouse")
				{
					GreenhouseList.Add(building);
					Monitor.Log(building.GetHashCode().ToString(), loglevel);
				}
			}
			Monitor.Log(GreenhouseList.Count.ToString(), loglevel);
		}
		private static void GreenhouseCompatibilityConsoleCommands(string command, string[] args)
        {
			if (command == "player_buildinglist")
            {
				populateGreenhouseList(true);
			}
        }
	}
}

