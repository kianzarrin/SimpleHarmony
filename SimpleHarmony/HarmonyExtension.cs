
namespace SimpleHarmony3.Patch
{
    using HarmonyLib;
    using SimpleHarmony3.Utils;
    using System.Collections.Generic;
    using System.Reflection;

    public class HarmonyExtension
    {
        Harmony harmony;
        public const string HARMONY_ID = "CS.Kian.harmony_self_patching";
        struct PatchPair
        {
            public MethodBase Original;
            public MethodInfo Patch;
        }

        public void InstallHarmony()
        {

            if (harmony == null)
            {
                Log.Info("Patching...");
                harmony = new Harmony(HARMONY_ID);
                harmony.PatchAll();
                Log.Info("Patched. acutal harmony is: " + harmony.GetType());
                
            }
        }

        public void UninstallHarmony()
        {
            if (harmony != null)
            {
                Log.Info("UnPatching...");
                harmony.UnpatchAll(HARMONY_ID);
                harmony = null;
                Log.Info("UnPatched.");
            }
        }
    }
}