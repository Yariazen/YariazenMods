using System;
using System.Collections.Generic;
using Object = StardewValley.Object;

namespace BuildableGreenhouse
{
    public class ModConfig
    {
        public string _StartWithGreenhouse { get; set; } = "True to start with the buildable greenhouse; False to unlock the buildable greenhouse when you unlock the greenhouse";
        public bool StartWithGreenhouse { set; get; } = false;

        public string _BuildPriceDescription { get; set; } = "This is the price to build a greenhouse";
        public int BuildPrice { get; set; } = 100000;
        
        public string _BuildMaterialsDescription { get; set; } = "These are the materials and amounts needed to build a greenhouse";
        public Dictionary<int, int> BuildMaterals { get; set; } = new()
        {
            [Object.stone] = 500,
            [709 /* Hardwood */] = 100,
            [Object.iridiumBar] = 5
        };
    }
}