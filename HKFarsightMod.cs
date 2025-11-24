using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

[BepInPlugin("com.archives.hkfarsightmod", "HK Silksong Farsight Mod", "1.0.0")]
public class HKFarsightMod : BaseUnityPlugin
{
    internal static ManualLogSource LogSource;

    private void Awake()
    {
        LogSource = Logger;
        LogSource.LogInfo($"{nameof(HKFarsightMod)} plugin loaded and initialized.");

        Harmony harmony = new Harmony("com.archives.hkfarsightmod");
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(SaveStats), nameof(SaveStats.UnlockedCompletionRate), MethodType.Getter)]
public static class PatchCompletionRateUnlock
{
    [HarmonyPostfix]
    public static void UnlockedCompletionRatePostfix(ref bool __result)
    {
        __result = true;
        HKFarsightMod.LogSource.LogInfo("UnlockedCompletionRate Getter forced to TRUE.");
    }
}


