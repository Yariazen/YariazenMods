
using StardewModdingAPI;
using StardewModdingAPI.Events;
using System.Collections.Generic;

namespace SeasonalSeeds
{
    public class ModEntry : Mod
    {
        IModHelper Helper;
        public override void Entry(IModHelper helper)
        {
            Helper = helper;

        }
    }
}