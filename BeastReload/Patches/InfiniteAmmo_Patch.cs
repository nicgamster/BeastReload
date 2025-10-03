using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeastReload.Patches
{
    [HarmonyPatch(typeof(DebugManager), "GetInfiniteAmmo")]
    public static class InfiniteAmmo
    {
        private static void Postfix(ref bool __result)
        {
            if (BeastManager.configManager.InfiniteAmmo.Value)
            {
                __result = true;
            }
        }
    }
}
