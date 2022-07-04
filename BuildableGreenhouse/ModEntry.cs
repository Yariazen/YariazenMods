using StardewModdingAPI;
using StardewModdingAPI.Events;
using System.Collections.Generic;
using xTile;
using static BuildableGreenhouse.ModExtension.ModExtension;

namespace BuildableGreenhouse
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            I18n.Init(helper.Translation);

            Initialize(helper, Monitor, ModManifest);

            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Maps\\Greenhouse"))
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
