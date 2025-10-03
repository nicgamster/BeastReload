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

        public static ConfigManager configManager;


        private void Awake()
        {
            configManager = new ConfigManager(Config);

            var harmony = new Harmony("BeastReload");
            harmony.PatchAll();
            Logger.LogInfo("BeastReload mod loaded!");
        }
    }
}