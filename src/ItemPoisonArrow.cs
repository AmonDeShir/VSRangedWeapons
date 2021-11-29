using System;
using System.Text;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;

namespace RangedWeapons
{
    public class ItemPoisonArrow : Item
    {
        public override void GetHeldItemInfo(ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
        {
            base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);

            if (inSlot.Itemstack.Collectible.Attributes == null) return;

            float dmg = inSlot.Itemstack.Collectible.Attributes["damage"].AsFloat(0);
            if (dmg != 0) dsc.AppendLine((dmg > 0 ? "+" : "") + dmg + Lang.Get("piercing-damage"));
            float poison = inSlot.Itemstack.Collectible.Attributes["poisonDamage"].AsFloat(0);
            if (poison != 0) dsc.AppendLine(poison + Lang.Get("rangedweapons:poison-damage-over-time"));
        }
    }
}
