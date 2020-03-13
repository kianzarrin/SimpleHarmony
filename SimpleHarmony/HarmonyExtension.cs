
namespace SimpleHarmony5.Patch
{
    using HarmonyLib;
    using SimpleHarmony5.Utils;
    using System.Collections.Generic;
    using System.Reflection;

    public class HarmonyExtension
    {
        Harmony harmony;
        public static string AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        public static Assembly BuildTimeHarmony = typeof(Harmony).Assembly;
        public Assembly RunTimeHarmony => harmony.GetType().Assembly;
        public static string HARMONY_ID = "CS.Kian." + AssemblyName;
       
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
                Log.Info(
                    "Patched. \n build time harmony = "+ BuildTimeHarmony + "\n"+
                    "run time harmony is: " + RunTimeHarmony);

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