using ICities;
using JetBrains.Annotations;
using SimpleHarmony3.Utils;
using SimpleHarmony3.Patch;
using System;

namespace SimpleHarmony3
{
    public class SimpleHarmonyMod : IUserMod
    {
        public static Version ModVersion => typeof(SimpleHarmonyMod).Assembly.GetName().Version;
        public static string VersionString => ModVersion.ToString(2);
        public string Name => VersionString + " simple Harmony";
        public string Description => "Simply Patches ReleaseCitizen() using " + HarmonyExtension.BuildTimeHarmony.GetName().FullName;

        HarmonyExtension harmonyExt;
        [UsedImplicitly]
        public void OnEnabled()
        {
            harmonyExt = new HarmonyExtension();
            harmonyExt.InstallHarmony();
        }

        [UsedImplicitly]
        public void OnDisabled()
        {
            harmonyExt?.UninstallHarmony();
            harmonyExt = null;
        }
    }
}