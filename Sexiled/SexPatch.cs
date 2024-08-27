using System.Collections.Generic;
using System.Reflection.Emit;
using Exiled.Loader.Features;
using HarmonyLib;
using NorthwoodLib.Pools;
using static HarmonyLib.AccessTools;

namespace Sexiled
{
    [HarmonyPatch(typeof(LoaderMessages), nameof(LoaderMessages.GetMessage))]
    public static class SexPatch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);
            
            newInstructions.InsertRange(0,
                new CodeInstruction[]
                {
                    new(OpCodes.Call, PropertyGetter(typeof(LoaderMessages), nameof(LoaderMessages.EasterEgg))),
                    new(OpCodes.Ret),
                });

            foreach (var instruction in newInstructions)
                yield return instruction;

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
}