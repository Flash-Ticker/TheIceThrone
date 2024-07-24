using System;
using Oxide.Core;
using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("TheIceThrone", "RustFlash", "2.0.0")]
    [Description("Grants the player 100% for food, water, and health when sitting on the Ice Throne if they have the .use permission")]
    public class TheIceThrone : RustPlugin
    {
        private const string UsePermission = "theicethrone.use";

        private void Init()
        {
            permission.RegisterPermission(UsePermission, this);
        }

        private void OnEntityMounted(BaseMountable mountable, BasePlayer player)
        {
            if (mountable == null || player == null) return;
            if (mountable.ShortPrefabName == "chair.icethrone")
            {
                if (permission.UserHasPermission(player.UserIDString, UsePermission))
                {
                    FillAttributes(player);
                }
                else
                {
                    SendReply(player, "You don't have permission to use the Ice Throne's power.");
                }
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