using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace BeastReload.Patches
{
    [HarmonyPatch(typeof(PlayerInteractable), "CanInteract")]

    static class CanInteract
    {
        static readonly HashSet<Type> NotAllowedTypes = new HashSet<Type>
        {
            typeof(WeaponPickup),
        };

        static bool Prefix(object __instance, ref bool __result)
        {
            if (BeastManager.configManager.TigerMode.Value)
            {
                var instType = __instance.GetType();

                if (NotAllowedTypes.Contains(instType))
                {
                    return false;
                }
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(Enemy.Enemy), "Damage")]
    static class EnemyInstaKill
    {
        private static void Prefix(ref float damageAmount)
        {
            if (BeastManager.configManager.TigerMode.Value)
            {
                damageAmount = 100;
            }
        }
    }
}
