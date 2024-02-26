using System;
using Oxide.Core;
using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("TheIceThrone", "RustFlash", "1.0.0")]
    [Description("Grants the player 100% for food, water, and health when sitting on the Ice Throne")]

    public class TheIceThrone : RustPlugin
    {
        private void OnEntityMounted(BaseMountable mountable, BasePlayer player)
        {
            if (mountable == null || player == null) return;

            if (mountable.ShortPrefabName == "chair.icethrone")
            {
                FillAttributes(player);
            }
        }

        private void FillAttributes(BasePlayer player)
        {
            if (player == null) return;

            player.health = player.MaxHealth();
            player.metabolism.calories.SetValue(player.metabolism.calories.max);
            player.metabolism.hydration.SetValue(player.metabolism.hydration.max);

            SendReply(player, "It's pretty cold up here!");
        }
    }
}