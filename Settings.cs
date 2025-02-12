using ModSettings;

namespace AutoSurvey
{
	internal class Settings : JsonModSettings
	{
		internal static Settings Instance { get; } = new Settings();

		internal static void OnLoad()
		{
			Settings.Instance.AddToModSettings("Auto Map Survey");
			Settings.Instance.RefreshGUI();
		}

		[Section("Main")]
		[Name("Automatically survey map (without coal)")]
		[ModSettings.Description("")]
		public bool autodrawEnabled = false;

		[Name("Automatically reveal map delay (s)")]
		[ModSettings.Description("")]
		[Slider(1f, 120f, NumberFormat = "{0:F1}")]
		public float autodrawDelay = 10f;

		[Name("Automatically reveal map range multiplier")]
		[ModSettings.Description("")]
		[Slider(0f, 10f, NumberFormat = "{0:F1}")]
		public float drawingRange = 1f;

		[Name("Unlock Survey")]
		[Description("Allow auto surveying at any weather.")]
		public bool UnlockSurvey = false;
	}
}