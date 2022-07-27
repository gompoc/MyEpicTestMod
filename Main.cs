using MelonLoader;
using Oculus.Platform;
using Main = MyEpicTestMod.Main;

[assembly: MelonInfo(typeof(Main), "MyEpicTestMod", "1.0.0", "gompo <3", "")]
[assembly: MelonGame( null, null)]
namespace MyEpicTestMod
{
    public class Main : MelonMod
    {
        private static HarmonyLib.Harmony Harmony;
        public override void OnApplicationStart()
        {
            Harmony = HarmonyInstance;
            
        }

        [HarmonyLib.HarmonyPatch(typeof(Message), "get_IsError")]
        class Patch
        {
            private static int first = 0;
            private static int second = 0;
            public static void Postfix(ref bool __result)
            {
                if (first < 5)
                {
                    first++;
                    return;
                }

                if (second < 2)
                {
                    __result = false;
                    second++;
                    if (second == 2)
                        Harmony.UnpatchAll(Harmony.Id);
                }
            }
        }
    }
}