using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;
using System;

namespace BuildableGreenhouse.Compatibility
{
    partial class ModCompatibility
    {
        public static void applyGMCMCompatibility()
        {
            if (Helper.ModRegistry.IsLoaded("spacechase0.GenericModConfigMenu"))
            {
                Monitor.Log($"{Manifest.UniqueID} applying GMCM compatibility");
                gmcmCompatibility();
            }
        }

        private static void gmcmCompatibility()
        {
            IGenericModConfigMenuApi configMenu = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

            if (configMenu is null)
                return;

            Texture2D springObjects = Game1.objectSpriteSheet;

            configMenu.Register(
                mod: Manifest,
                reset: () => Config = new ModConfig(),
                save: () => Helper.WriteConfig(Config),
                titleScreenOnly: true
            );

            configMenu.AddBoolOption(
                mod: Manifest,
                getValue: () => Config.StartWithGreenhouse,
                setValue: value => Config.StartWithGreenhouse = value,
                name: () => "Start With Greenhouse",
                tooltip: () => "True to start with the buildable greenhouse; False to unlock the buildable greenhouse when you unlock the greenhouse"
            );

            configMenu.AddNumberOption(
                mod: Manifest,
                getValue: () => Config.BuildPrice,
                setValue: value => Config.BuildPrice = value,
                name: () => "Build Price",
                tooltip: () => "This is the price to build a greenhouse"
            );

            configMenu.AddSectionTitle(
                mod: Manifest,
                text: () => "Building Materials"
            );

            configMenu.AddParagraph(
                mod: Manifest,
                text: () => "Building materials can only be modified through config.json found in this mod's folder."
            );
        }
    }

    public interface IGenericModConfigMenuApi
    {
        void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);
        void AddSectionTitle(IManifest mod, Func<string> text, Func<string> tooltip = null);
        void AddParagraph(IManifest mod, Func<string> text);
        void AddBoolOption(IManifest mod, Func<bool> getValue, Action<bool> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);
        void AddNumberOption(IManifest mod, Func<int> getValue, Action<int> setValue, Func<string> name, Func<string> tooltip = null, int? min = null, int? max = null, int? interval = null, Func<int, string> formatValue = null, string fieldId = null);
    }
}
