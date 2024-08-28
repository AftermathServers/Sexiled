using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Toys;
using Exiled.API.Structs;
using HarmonyLib;
using MEC;

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

        public static Plugin Instance;

        private Harmony _harmony = new Harmony("6hundred9.Sexiled");
        
        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandlers.WaitingForPlayers;
            _harmony.PatchAll();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandlers.WaitingForPlayers;
            _harmony.UnpatchAll();
            foreach (CoroutineHandle handle in EventHandlers.Coroutines)
            {
                Timing.KillCoroutines(handle);
            }
        }
    }
}