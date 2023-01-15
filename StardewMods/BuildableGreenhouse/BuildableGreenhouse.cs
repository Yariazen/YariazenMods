using StardewModdingAPI;
using StardewModdingAPI.Events;
using xTile;
using static BuildableGreenhouse.Framework.ModExtension.ModExtension;
using static BuildableGreenhouse.Framework.ModTranslation;

namespace BuildableGreenhouse
{
    public class BuildableGreenhouse : Mod
    {
        public override void Entry(IModHelper helper)
        {
            InitializeTranslations(helper);
            InitializeExtensions(helper, Monitor, ModManifest);

            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }

        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Maps\\GreenhouseMap"))
            {
                e.Edit(asset =>
                {
                    Map greenhouseIndoorMap = asset.AsMap().Data;
                    greenhouseIndoorMap.Properties["IsGreenhouse"] = true;
                });
            }
        }
    }
}
