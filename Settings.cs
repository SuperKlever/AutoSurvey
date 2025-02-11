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
		public bool autodrawEnabled;

		[Name("Automatically reveal map delay (s)")]
		[ModSettings.Description("")]
		[Slider(5f, 100f, NumberFormat = "{0:F1}")]
		public float autodrawDelay = 10f;

		[Name("Automatically reveal map range multiplier")]
		[ModSettings.Description("")]
		[Slider(0f, 25f, NumberFormat = "{0:F1}")]
		public float drawingRange = 1f;
	}
}