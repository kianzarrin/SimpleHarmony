using ICities;
using JetBrains.Annotations;
using SimpleHarmony.Utils;
using SimpleHarmony.Patch;
using System;

namespace SimpleHarmony
{
    public class SimpleHarmonyMod : IUserMod
    {
        public string Name => "Patch same method" + VersionString + " " + BRANCH;
        public string Description => "Patches same method as TMPE.";

#if DEBUG
        public const string BRANCH = "DEBUG";
#else
        public const string BRANCH = "";
#endif

        public static Version ModVersion => typeof(SimpleHarmonyMod).Assembly.GetName().Version;

        // used for in-game display
        public static string VersionString => ModVersion.ToString(2);

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