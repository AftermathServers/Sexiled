using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;

namespace Sexiled
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Sexiled";
        public override string Prefix => "Sex";
        public override string Author => "6hundred9";
        public override PluginPriority Priority => PluginPriority.Lowest;
        public override Version Version => new(1, 0, 0);
        public override Version RequiredExiledVersion => new(8, 11, 0);
        public override bool IgnoreRequiredVersionCheck => false;

        private Harmony _harmony = new Harmony("6hundred9.Sexiled");
        
        public override void OnEnabled()
        {
            base.OnEnabled();
            _harmony.PatchAll();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            _harmony.UnpatchAll();
        }
    }
}