using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Buildings;
using System.Collections.Generic;
using System.Linq;

namespace BuildableGreenhouse.ModExtension
{
	public partial class ModExtension
	{
		private static Dictionary<string, Building> GreenhouseDict;
		private static partial void GreenhouseCompatibility()
		{
			Helper.Events.GameLoop.DayStarted += populateGreenhouseList;

			Helper.ConsoleCommands.Add("player_buildinglist", "PopulateBuildingList", GreenhouseCompatibilityConsoleCommands);
		}

		private static void populateGreenhouseList(object sender, DayStartedEventArgs e)
        {
			
        }

		private static void GreenhouseCompatibilityConsoleCommands(string command, string[] args)
        {
			if (command == "player_buildinglist")
            {
				List<Building> buildinglist = Game1.getFarm().buildings.ToList();
				foreach (Building building in buildinglist)
                {
					Monitor.Log(building.buildingType, StardewModdingAPI.LogLevel.Warn);
				}
			}
        }
	}
}

