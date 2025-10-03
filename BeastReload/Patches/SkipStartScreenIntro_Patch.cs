using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeastReload.Patches
{
    [HarmonyPatch(typeof(LevelController), "Initialize")]
    public static class SkipStartScreenIntro
    {
        private static void Prefix(ref bool newLevelAttempt)
        {
            if (BeastManager.configManager.SkipIntroCutscene.Value)
            {
                newLevelAttempt = false;
            }
        }
    }
}
