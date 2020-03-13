
namespace SimpleHarmony2.Patch
{
    using Harmony;
    using SimpleHarmony2.Utils;
    using System.Collections.Generic;
    using System.Reflection;

    public class HarmonyExtension
    {
        HarmonyInstance harmony;
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
                harmony = HarmonyInstance.Create(HARMONY_ID);
                harmony.PatchAll();
                Log.Info("Patched. Actual harmony version is " + harmony.GetType().Assembly);
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