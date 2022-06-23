using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Buildings;
using System;

namespace BuildableGreenhouse
{
    public class ModPatch
    {
        private static IMonitor Monitor;
        private static IModHelper Helper;

        public static void Initialize(IModHelper helper, IMonitor monitor)
        {
            Monitor = monitor;
            Helper = helper;
        }

        public static bool drawInMenu_Prefix(GreenhouseBuilding __instance)
        {
            try
            {
                __instance.texture = new Lazy<Texture2D>(delegate
                {
                    Texture2D texture2D = Game1.content.Load<Texture2D>("Buildings\\Greenhouse");
                    if (__instance.paintedTexture != null)
                    {
                        __instance.paintedTexture.Dispose();
                        __instance.paintedTexture = null;
                    }
                    __instance.paintedTexture = BuildingPainter.Apply(texture2D, "Buildings\\Greenhouse" + "_PaintMask", __instance.netBuildingPaintColor.Value);
                    if (__instance.paintedTexture != null)
                    {
                        texture2D = __instance.paintedTexture;
                    }
                    return texture2D;
                });
            }
            catch (Exception ex)
            {
                Monitor.Log($"Failed in {nameof(drawInMenu_Prefix)}:\n{ex}", LogLevel.Error);
            }
            return true;
        }
    }
}
