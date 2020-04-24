namespace TestHarmonyInheritance.Patch{
    using Harmony;
    using JetBrains.Annotations;
    using Utils;

    //[HarmonyPatch(typeof(CitizenManager), "ReleaseCitizen")]
    //[UsedImplicitly]
    public static class ReleaseCitizenPatch {
        /// <summary>
        /// Notifies the extended citizen manager about a released citizen.
        /// </summary>
        [HarmonyPostfix]
        [UsedImplicitly]
        public static void Postfix(uint citizen) {
            Log.Info("ReleaseCitizenPatch.Postfix() called for citizen " + citizen);
        }
    }
}