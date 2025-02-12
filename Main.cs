using Il2Cpp;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(AutoSurvey.Main), "Auto Map Survey", "1.1.0", "SuperKlever", null)]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace AutoSurvey
{
    public class Main : MelonMod
    {
		public static float lastDrawTime = 0f;

		public override void OnInitializeMelon()
        {
			Settings.OnLoad();
			//MelonLogger.Msg("Auto Map Survey is alive");
		}

		public override void OnUpdate()
		{
			bool inGameFlag = !GameManager.IsMainMenuActive() &&
				Settings.Instance.autodrawEnabled &&
				!InterfaceManager.IsPanelEnabled<Panel_Map>() &&
				InterfaceManager.IsPanelLoaded<Panel_Map>();
			if (inGameFlag)
			{
				bool canSurveyFlag = Settings.Instance.UnlockSurvey || CharcoalItem.HasSurveyVisibility(0);
				if (canSurveyFlag)
				{
					Main.lastDrawTime += Time.deltaTime;
					if (Main.lastDrawTime >= Settings.Instance.autodrawDelay)
					{
						//MelonLogger.Msg($"Try reveal");
						float radius = Settings.Instance.drawingRange * 150;
						InterfaceManager.GetPanel<Panel_Map>().DoNearbyDetailsCheck(radius, true, false, GameManager.GetPlayerTransform().position, true);
						Main.lastDrawTime = 0f;
					}
				}
			}
		}
	}
}