using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Buildings;
using System.Xml.Serialization;

namespace BuildableGreenhouse
{
    [XmlType("Mods_Yariazen_BuildableGreenhouseBuilding")]
    public class BuildableGreenhouseBuilding : GreenhouseBuilding
    {
        private static readonly BluePrint Blueprint = new("BuildableGreenhouse");

        public BuildableGreenhouseBuilding()
            : base(Blueprint, Vector2.Zero) { }

        public BuildableGreenhouseBuilding(BluePrint blueprint, Vector2 tileLocation)
            : base(blueprint, tileLocation) { }

        protected override GameLocation getIndoors(string nameOfIndoorsWithoutUnique)
        {
            return new BuildableGreenhouseLocation();
        }

        public override Rectangle getSourceRect()
        {
            return new Rectangle(0, 160, 112, 160);
        }

        public override void drawBackground(SpriteBatch b)
        {
            base.drawBackground(b);
            if (!base.isMoving)
            {
                this.drawShadow(b);
            }
        }

        public override void draw(SpriteBatch b)
        {
            if (base.isMoving)
            {
                return;
            }
            if ((int)base.daysOfConstructionLeft.Value > 0 || (int)base.newConstructionTimer.Value > 0)
            {
                this.drawInConstruction(b);
                return;
            }
            float draw_layer = (float)(((int)base.tileY.Value + (int)base.tilesHigh.Value) * 64) / 10000f;
            Rectangle source_rect = this.getSourceRect();
            if (!Game1.getFarm().greenhouseUnlocked.Value)
                source_rect.Y -= source_rect.Height;
            b.Draw(base.texture.Value, Game1.GlobalToLocal(Game1.viewport, new Vector2((int)base.tileX.Value * 64, (int)base.tileY.Value * 64 + (int)base.tilesHigh.Value * 64)), source_rect, base.color.Value * base.alpha.Value, 0f, new Vector2(0f, source_rect.Height), 4f, SpriteEffects.None, draw_layer);
        }

        public override void drawShadow(SpriteBatch b, int localX = -1, int localY = -1)
        {
            Rectangle shadow_rectangle = new Rectangle(112, 0, 128, 144);
            b.Draw(base.texture.Value, Game1.GlobalToLocal(Game1.viewport, new Vector2(((int)base.tileX.Value - 1) * 64, (int)base.tileY.Value * 64)), shadow_rectangle, Color.White * ((localX == -1) ? ((float)base.alpha.Value) : 1f), 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
        }
    }

    [XmlType("Mods_Yariazen_BuildableGreenhouseLocation")]
    public class BuildableGreenhouseLocation : GameLocation
    {
        public BuildableGreenhouseLocation()
            : base("Maps\\Greenhouse", "BuildableGreenhouse")
        {
            isGreenhouse.Value = true;
        }
    }
}