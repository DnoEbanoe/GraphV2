using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Texture {
	public class ColorTexture : BaseTexture {
		public GameManager GameManager { get; }
		public Color Color { get; set; }
		public ColorTexture(GameManager gameManager, Color color) {
			GameManager = gameManager;
			Color = color;
		}
		public override Texture2D GetTexture(Rectangle rectangle) {
			return GraphicsHelper.CreateColorTexture(GameManager.GraphicsDeviceManager.GraphicsDevice,
				rectangle.Width + rectangle.Y, rectangle.Height + rectangle.X, Color);
		}
	}
}
