using ICities;
using JetBrains.Annotations;
using SimpleHarmony2.Utils;
using SimpleHarmony2.Patch;
using System;

namespace SimpleHarmony2
{
    public class SimpleHarmonyMod : IUserMod
    {
        public static Version ModVersion => typeof(SimpleHarmonyMod).Assembly.GetName().Version;
        public static string VersionString => ModVersion.ToString(2);
        public string Name => "simple Harmony " + VersionString;
        public string Description => "Simply Patches ReleaseCitizen().";

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