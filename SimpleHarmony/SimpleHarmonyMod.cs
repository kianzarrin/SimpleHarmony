using ICities;
using JetBrains.Annotations;
using System;

namespace TestHarmonyInheritance
{
    public class SimpleHarmonyMod : IUserMod
    {
        public static Version ModVersion => typeof(SimpleHarmonyMod).Assembly.GetName().Version;
        public static string VersionString => ModVersion.ToString(2);
        public string Name => VersionString + " TestHarmonyInheritance";
        public string Description => "Simply Patches ReleaseCitizen() using " + HarmonyExtension.BuildTimeHarmony.GetName().FullName;

        HarmonyExtension harmonyExt;
        [UsedImplicitly]
        public void OnEnabled()
        {
            harmonyExt = new HarmonyExtension();
            harmonyExt.InstallHarmony();
            test_harmony.Test.Run();
        }

        [UsedImplicitly]
        public void OnDisabled()
        {
            harmonyExt?.UninstallHarmony();
            harmonyExt = null;
        }
    }
}



namespace test_harmony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Harmony;
    public static class Test
    {
        public static void Run()
        {
            var x = new X();
            x.Step();
            x.Step();
            x.Step();
            x.Step();
            x.Step();
        }
    }


    public class X
    {
        protected int a;
        protected int b;
        public X()
        {
            a = 1; b = 1;
        }

        public int Step()
        {
            var temp = b;
            b = b + a;
            a = b;
            return b;
        }
    }

    [HarmonyPatch(typeof(X), nameof(X.Step))]
    public class XPatch : X
    {
        static void Prefix()
        {
            Console.WriteLine("Step().Prefix(): this.a=");// + this.a);
        }
    }
}
