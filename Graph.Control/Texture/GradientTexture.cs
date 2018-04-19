using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Texture {
	public class GradientTexture : BaseTexture {
		public GameManager GameManager { get; }
		public Color ColorA { get; set; }
		public Color ColorB { get; set; }

		public GradientTexture(GameManager gameManager, Color colorA, Color colorB) {
			GameManager = gameManager;
			ColorA = colorA;
			ColorB = colorB;
		}

		public override Texture2D GetTexture(Rectangle rectangle) {
			return GraphicsHelper.CreateGradiantTexture(GameManager.GraphicsDeviceManager.GraphicsDevice,
				ColorA, ColorB, rectangle.Width + rectangle.Y, rectangle.Height + rectangle.X);
		}
	}
}
