using BuildableGreenhouse.Compatibility;
using Microsoft.Xna.Framework.Graphics;
using SpaceShared.APIs;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using xTile;

namespace BuildableGreenhouse
{
    public class ModEntry : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            this.Config = helper.ReadConfig<ModConfig>();

            ModPatch.Initialize(helper, this.Monitor);
            ModCompatibility.Initialize(helper, this.Monitor, this.ModManifest);

            helper.Events.Content.AssetRequested += this.OnAssetRequested;
            helper.Events.Display.MenuChanged += this.OnMenuChanged;
            helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;
            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
            helper.Events.Player.Warped += this.OnWarped;
        }

        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Data\\Blueprints"))
            {
                e.Edit(asset =>
                {
                    var data = asset.AsDictionary<string, string>().Data;
                    String[] greenhouse = data["Greenhouse"].Split("/");
                    String buildableGreenhouseName = greenhouse[8];
                    String buildableGreenhouseDescription = greenhouse[9];
                    data.Add("BuildableGreenhouse", $"{BuildMaterialsToString()}/7/6/3/5/-1/-1/Greenhouse/{buildableGreenhouseName}/{buildableGreenhouseDescription}/Buildings/none/64/96/20/null/Farm/{this.Config.BuildPrice}/false");
                });
            }

            if (e.NameWithoutLocale.IsEquivalentTo("Buildings\\BuildableGreenhouse"))
            {
                e.LoadFrom(() => this.Helper.GameContent.Load<Texture2D>("Buildings\\Greenhouse"), AssetLoadPriority.High);
            }

            if (e.NameWithoutLocale.IsEquivalentTo("Maps\\BuildableGreenhouse"))
            {
                e.LoadFrom(() => this.Helper.GameContent.Load<Map>("Maps\\Greenhouse"), AssetLoadPriority.High);
            }
        }

        private void OnMenuChanged(object sender, MenuChangedEventArgs e)
        {
            if (e.NewMenu is CarpenterMenu menu)
            {
                if (this.Config.StartWithGreenhouse || Game1.getFarm().greenhouseUnlocked.Value)
                {
                    Monitor.Log("Adding Buildable Greenhouse to Carpenter Menu");
                    var blueprints = this.Helper.Reflection.GetField<List<BluePrint>>(menu, "blueprints").GetValue();
                    blueprints.Add(this.GetBlueprint());
                }
            }
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            var spaceCore = this.Helper.ModRegistry.GetApi<ISpaceCoreApi>("spacechase0.SpaceCore");

            Type[] types =
            {
                typeof(BuildableGreenhouseBuilding),
                typeof(BuildableGreenhouseLocation)
            };

            foreach (Type type in types)
                spaceCore.RegisterSerializerType(type);
        }

        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            foreach (var loc in Game1.locations)
            {
                if (loc is BuildableGameLocation buildable)
                {
                    foreach (var building in buildable.buildings)
                    {
                        if (building.indoors.Value == null)
                            continue;

                        building.indoors.Value.updateWarps();
                        building.updateInteriorWarps();
                    }
                }
            }
        }

        private void OnWarped(object sender, WarpedEventArgs e)
        {
            if (!e.IsLocalPlayer)
                return;

            BuildableGameLocation farm = e.NewLocation as BuildableGameLocation ?? e.OldLocation as BuildableGameLocation;
            if (farm != null)
            {
                for (int i = 0; i < farm.buildings.Count; ++i)
                {
                    var b = farm.buildings[i];
                    if (b.buildingType.Value == "BuildableGreenhouse" && b is not BuildableGreenhouseBuilding)
                    {
                        farm.buildings[i] = new BuildableGreenhouseBuilding();
                        farm.buildings[i].buildingType.Value = b.buildingType.Value;
                        farm.buildings[i].daysOfConstructionLeft.Value = b.daysOfConstructionLeft.Value;
                        farm.buildings[i].tileX.Value = b.tileX.Value;
                        farm.buildings[i].tileY.Value = b.tileY.Value;
                        farm.buildings[i].tilesWide.Value = b.tilesWide.Value;
                        farm.buildings[i].tilesHigh.Value = b.tilesHigh.Value;
                        farm.buildings[i].load();
                    }
                }
            }
        }

        private BluePrint GetBlueprint()
        {
            return new BluePrint("BuildableGreenhouse");
        }

        private string BuildMaterialsToString()
        {
            string result = "";
            foreach (KeyValuePair<int, int> kvp in this.Config.BuildMaterals)
            {
                result += kvp.Key.ToString() + " " + kvp.Value.ToString() + " ";
            }
            return result.TrimEnd(' ');
        }
    }
}