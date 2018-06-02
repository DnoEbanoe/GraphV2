using Microsoft.Xna.Framework;

namespace Graph.Control.Container {
	public class Border {
		public Color Color { get; set; }
		public int Width { get; set; }

		public static bool IsEmpty(Border border) {
			return border == null || border.Width == 0;
		}
	}
}
