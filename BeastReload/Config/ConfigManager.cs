using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ConfigManager(ConfigFile config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            const string section = "Settings";

            SkipStartIntro = _config.Bind(section, nameof(SkipStartIntro), true, "Skip the initial intro animation");
            SkipIntroCutscene = _config.Bind(section, nameof(SkipIntroCutscene), true, "Skip the initial intro animation (alternate)");
            AutoStartGame = _config.Bind(section, nameof(AutoStartGame), true, "Automatically start game after skipping intro");
            InfiniteAmmo = _config.Bind(section, nameof(InfiniteAmmo), true, "Infinite ammo (bullet rain)");
            TigerMode = _config.Bind(section, nameof(TigerMode), true, "One-shot fists (Tiger Mode)");
        }
    }
}
