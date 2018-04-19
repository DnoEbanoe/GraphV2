using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Texture {
	public abstract class BaseTexture {
		public abstract Texture2D GetTexture(Rectangle rectangle);
	}
}
