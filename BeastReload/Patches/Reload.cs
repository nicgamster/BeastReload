using BeastReload.Config;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BeastReload.Patches
{
    [HarmonyPatch(typeof(PlayerArmManager), "Update")]

    static class Reload
    {
        //TO-DO Make only one Reload
        //TO-DO Not Making no ammo animation
        private static int ReloadAmount = ConfigManager.ReloadAmount.Value;

        static readonly HashSet<Type> NotAllowedTypes = new HashSet<Type>
        {
            typeof(WeaponPickup),
        };

        static void Prefix(PlayerArmManager __instance)
        {
            if (Input.GetKeyDown(ConfigManager.ReloadKey))
            {
                WeaponPickup pickup = __instance.GetEquippedWeapon();

                if (pickup != null)
                {
                    Traverse.Create(pickup).Field("usesRemaining").SetValue(pickup.GetWeaponDetails().GetTotalUses());
                    __instance.EquipWeapon(pickup);
                    ReloadAmount--;
                }
            }
        }
    }
}
