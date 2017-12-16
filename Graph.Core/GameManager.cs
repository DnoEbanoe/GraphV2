using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Core {

	public class GameManager {
		public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
		public SpriteBatch spriteBatch { get; set; }
		public ContentManager ContentManager { get; set; }
		public IContentManager<SpriteFont> FonsManager { get; set; }
	}

}
