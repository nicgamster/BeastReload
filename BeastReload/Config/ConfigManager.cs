using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeastReload.Config
{
    public sealed class ConfigManager
    {
        private readonly ConfigFile _config;

        public ConfigEntry<bool> SkipStartIntro { get; }
        public ConfigEntry<bool> SkipIntroCutscene { get; }
        public ConfigEntry<bool> AutoStartGame { get; }
        public ConfigEntry<bool> InfiniteAmmo { get; }
        public ConfigEntry<bool> TigerMode { get; }
        public ConfigEntry<bool> Reload { get; }

        public static ConfigEntry<int> ReloadAmount { get; private set; }

        public static ConfigEntry<string> ReloadKeyString { get; private set; }


        public static KeyCode ReloadKey
        {
            get
            {
                if (ReloadKeyString == null) return KeyCode.R;
                try
                {
                    return Enum.TryParse(ReloadKeyString.Value, true, out KeyCode kc) ? kc : KeyCode.R;
                }
                catch
                {
                    return KeyCode.R;
                }
            }
        }


        public ConfigManager(ConfigFile config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            const string section = "Settings";

            SkipStartIntro = _config.Bind(section, nameof(SkipStartIntro), true, "Skip the initial intro animation");
            SkipIntroCutscene = _config.Bind(section, nameof(SkipIntroCutscene), true, "Skip the initial intro animation (alternate)");
            AutoStartGame = _config.Bind(section, nameof(AutoStartGame), true, "Automatically start game after skipping intro");
            InfiniteAmmo = _config.Bind(section, nameof(InfiniteAmmo), true, "Infinite ammo (bullet rain)");
            TigerMode = _config.Bind(section, nameof(TigerMode), false, "One-shot fists (Tiger Mode)");
            ReloadKeyString = _config.Bind(section, nameof(ReloadKeyString), KeyCode.R.ToString(), "Key used to trigger reload");
            ReloadAmount = _config.Bind(section, nameof(ReloadAmount), 1, "Amounts of reload");

        }
    }
}
