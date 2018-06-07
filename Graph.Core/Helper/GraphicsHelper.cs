using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Core.Helper {

	public static class GraphicsHelper {
		public static Texture2D CreateGradiantTexture(GraphicsDevice device, Color start, Color end, int width = 128, int height = 128) {
			Texture2D texture = new Texture2D(device, width, height);
			Color[] colors = new Color[width * height];
			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					colors[x + y * width] = Color.Lerp(start, end, (float) y / (float) height);
				}
			}
			texture.SetData<Color>(colors);
			return texture;
		}

		public static Texture2D CreateCheckboardTexture(GraphicsDevice device, Color firstTile, Color secondTile, int width = 128, int height = 128) {
			Texture2D texture = new Texture2D(device, width, height);
			Color[] colors = new Color[width * height];
			int segX = width >> 1;
			int segY = height >> 1;
			for (int y = 0; y < height; y++) {
				for (int x = 0; x < width; x++) {
					if ((x < segX && y < segY) || (x >= segX && y >= segY))
						colors[x + y * width] = firstTile;
					else
						colors[x + y * width] = secondTile;
				}
			}
			texture.SetData<Color>(colors);
			return texture;
		}

		public static Texture2D CreateColorTexture(GraphicsDevice device, int width, int height, Color color) {
			Texture2D texture = new Texture2D(device, width, height);
			Color[] data = new Color[width * height];
			for (int pixel = 0; pixel < data.Length; pixel++) {
				data[pixel] = color;
			}
			texture.SetData(data);
			return texture;
		}

		public static Texture2D CreateCircleTexture(GraphicsDevice device, Color circleColor, Color exteriorColor, int radius) {
			Texture2D texture = new Texture2D(device, radius, radius);
			Color[] colors = new Color[radius * radius];
			float diam = radius / 2f;
			float diamsq = diam * diam;
			Vector2 pos = Vector2.Zero;
			for (int x = 0; x < radius; x++) {
				for (int y = 0; y < radius; y++) {
					var index = x * radius + y;
					pos.X = x - diam;
					pos.Y = y - diam;
					if (pos.LengthSquared() <= diamsq)
						colors[index] = circleColor;
					else
						colors[index] = exteriorColor;
				}
			}
			texture.SetData(colors);
			return texture;
		}
	}
}
