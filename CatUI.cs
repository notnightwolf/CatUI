using System;
using System.Threading.Tasks;
using ABI_RC.Core.InteractionSystem;
using Harmony;
using MelonLoader;

namespace CatUI
{
    public class CatUI : MelonMod
    {
        private static Harmony.HarmonyInstance _instance = new Harmony.HarmonyInstance(Guid.NewGuid().ToString());

        private static void CatUIPatch(bool __0)
        {
            CatUIMain.CatUIPanel.gameObject.SetActive(__0);
        }

        public override void OnApplicationStart()
        {
            _instance.Patch(typeof(CVR_MenuManager).GetMethod(nameof(CVR_MenuManager.ToggleQuickMenu)), typeof(CatUI).GetMethod("CatUIPatch", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).ToNewHarmonyMethod());

            MelonCoroutines.Start(CatUIMain.InitializeCatUI());  
        }

        //Examples are in CatUIMain.cs just scroll down
    }
}
