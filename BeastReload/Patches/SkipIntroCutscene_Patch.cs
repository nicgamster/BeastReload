using HarmonyLib;
using Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeastReload.Patches
{
    [HarmonyPatch(typeof(ProgressManager), "ShouldDisplayGameIntroOnStart")]
    public static class SkipIntroCutscene
    {
        private static void Postfix(ref bool __result)
        {
            if (BeastManager.configManager.SkipIntroCutscene.Value)
            {
                __result = false;
            }
        }
    }
}
