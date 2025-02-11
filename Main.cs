using Il2Cpp;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(AutoSurvey.Main), "Auto Map Survey", "1.0.0", "SuperKlever", null)]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace AutoSurvey
{
    public class Main : MelonMod
    {
		public static float lastDrawTime = 0f;

		public override void OnInitializeMelon()
        {
			Settings.OnLoad();
		}

		public override void OnUpdate()
		{
			if (!GameManager.IsMainMenuActive() &&
				Settings.Instance.autodrawEnabled &&
				!InterfaceManager.IsPanelEnabled<Panel_Map>())
			{
				Main.lastDrawTime += Time.deltaTime;
				if (Main.lastDrawTime >= Settings.Instance.autodrawDelay)
				{
					InterfaceManager.GetPanel<Panel_Map>().DoDetailSurvey();
					InterfaceManager.GetPanel<Panel_Map>().CloseSelf();
					Main.lastDrawTime = 0f;
				}
			}
		}
	}
}