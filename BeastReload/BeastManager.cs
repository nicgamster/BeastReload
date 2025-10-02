using BeastReload.Config;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Progress;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;

namespace BeastReload
{
    [BepInPlugin("BeastReload", "BeastReload", "1.0.0")]
    public class BeastManager : BaseUnityPlugin
    {
        public static ConfigEntry<bool> SkipStartIntro;
        public static ConfigEntry<bool> SkipIntroCutscene;
        public static ConfigEntry<bool> AutoStartGame;
        public static ConfigEntry<bool> InfiniteAmmo;

        ConfigManager configManager;


        private void Awake()
        {
            configManager = new ConfigManager(Config);

            var harmony = new Harmony("BeastReload");
            harmony.PatchAll();
            Logger.LogInfo("BeastReload mod loaded!");
        }
    }

    [HarmonyPatch(typeof(ProgressManager), "ShouldDisplayGameIntroOnStart")]
    public static class BypassIntroCheck_Patch
    {
        private static void Postfix(ref bool __result)
        {
            if (BeastManager.SkipIntroCutscene.Value)
            {
                __result = false; // Говорим что интро уже показывалось
            }
        }
    }

    [HarmonyPatch(typeof(LevelController), "Initialize")]
    public static class SkipStartScreenIntro_Patch
    {
        private static void Prefix(Camera startingCamera, ref bool newLevelAttempt)
        {
            if (BeastManager.SkipIntroCutscene.Value)
            {
                newLevelAttempt = false;
            }
        }
    }

    [HarmonyPatch(typeof(DebugManager), "GetInfiniteAmmo")]
    public static class InfiniteAmmo_Patch
    {
        private static void Postfix(ref bool __result)
        {
            if (BeastManager.InfiniteAmmo.Value)
            {
                __result = true;
            }
        }
    }
}