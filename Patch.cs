using HarmonyLib;
using Il2Cpp;
using Il2CppAudio.SimpleAudio;
using UnityEngine;

namespace AutoSurvey
{
	[HarmonyPatch(typeof(Panel_Map), "DoNearbyDetailsCheck", new Type[]
	{
		typeof(float),
		typeof(bool),
		typeof(bool),
		typeof(Vector3),
		typeof(bool)
	})]
	internal class Panel_Map_DoNearbyDetailsCheck
	{
		private static void Prefix(Panel_Map __instance, ref float radius, ref bool forceAddSurveyPosition, ref bool useOverridePosition, ref Vector3 overridePostion, ref bool shouldAllowVistaReveals)
		{
			if (!__instance.SceneCanBeMapped(__instance.GetMapNameOfCurrentScene()) || InterfaceManager.GetPanel<Panel_Loading>().IsEnabled())
			{
				return;
			}
			radius *= Settings.Instance.drawingRange;
		}
	}

	[HarmonyLib.HarmonyPatch(typeof(GameAudioManager), "PlaySound", new Type[] { typeof(Il2CppAK.Wwise.Event), typeof(GameObject) })]
	public class PlaySoundPatchEvent
	{
		public static bool Prefix(ref GameAudioManager __instance, ref Il2CppAK.Wwise.Event soundEvent, ref GameObject go)
		{
			//MelonLogger.Msg("Play event " + soundEvent.Name + " on " + go.name);

			if (go == null || soundEvent == null)
			{
				return true;
			}

			if (Settings.Instance.autodrawEnabled &&
				Main.lastDrawTime >= Settings.Instance.autodrawDelay &&
				soundEvent.Name.Contains("Play_MapOpen"))
			{
				return false;
			}

			return true;
		}
	}

	[HarmonyLib.HarmonyPatch(typeof(PlayAudioSimple), "Start")]
	public class PlayAudioSimplePatch
	{
		public static bool Prefix(ref PlayAudioSimple __instance)
		{
			//MelonLogger.Msg("Play simple started " + __instance.m_Event.Name + " on " + __instance.gameObject.name);

			if (__instance.m_Event == null || __instance.gameObject == null)
			{
				return true;
			}


			if (Settings.Instance.autodrawEnabled && 
				Main.lastDrawTime >= Settings.Instance.autodrawDelay && 
				__instance.m_Event.Name.Contains("Play_MapOpen"))
			{

				return false;
			}

			return true;
		}
	}
}
