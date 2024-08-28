using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Loader.Features;
using HarmonyLib;
using MEC;
using PluginAPI.Events;

namespace Sexiled;

public class EventHandlers
{
    public static List<CoroutineHandle> Coroutines = new();
    
    public static void WaitingForPlayers()
    {
        if (!Plugin.Instance.Config.ShowRandomly) return;

        Coroutines.Add(Timing.RunCoroutine(SexiledText()));
    }

    public static IEnumerator<float> SexiledText()
    {
        for (;;)
        {
            if (UnityEngine.Random.Range(1f, 100f) >= Plugin.Instance.Config.Chance)
            {
                ServerConsole.AddLog($"Welcome to {LoaderMessages.EasterEgg}", ConsoleColor.Green);
            }
            yield return Timing.WaitForSeconds(UnityEngine.Random.Range(Plugin.Instance.Config.MinSeconds,
                Plugin.Instance.Config.MaxSeconds));
        }
    }
}