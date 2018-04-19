using Graph.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Texture {
	public class ImageTexture : BaseTexture {
		public GameManager GameManager { get; }
		public string Name { get; set; }
		protected string ManagerName { get; set; } = "image";

		public ImageTexture(GameManager gameManager, string name) {
			GameManager = gameManager;
			Name = name;
		}

		public override Texture2D GetTexture(Rectangle rectangle) {
			return GameManager.TextureManager.Get(ManagerName + ":" + Name);
		}
	}
}