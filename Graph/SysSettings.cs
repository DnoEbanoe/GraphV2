using Microsoft.Xna.Framework;

namespace Graph {
	public static class SysSettings {
		public static Vector2 PointSize { get; set; } = new Vector2(20, 20);
		public static bool IsAddPoint { get; set; } = true;
		public static bool IsAddLine { get; set; }
		public static bool IsPointingPath { get; set; }
		public static bool IsRemovePoint { get; set; }
		public static string CiltureName { get; set; } = "en-US";
	}
}
