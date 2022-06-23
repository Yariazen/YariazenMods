using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace ThisTooShallPass
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.Content.AssetRequested += OnAssetRequested;
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {

            var api = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
        }

        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.Name.IsDirectlyUnderPath("Mods/ThisTooShallPass"))
            {
                
            }
        }
    }

    public interface IContentPatcherAPI
    {
        bool IsConditionsApiReady { get; }
        void RegisterToken(IManifest mod, string name, Func<IEnumerable<string>?> getValue);
        void RegisterToken(IManifest mod, string name, object token);
    }
}