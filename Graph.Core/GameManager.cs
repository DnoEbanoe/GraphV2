using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graph.Core {

	public class GameManager {
		public GraphicsDeviceManager GraphicsDeviceManager { get; set; }
		public SpriteBatch SpriteBatch { get; set; }
		public ContentManager ContentManager { get; set; }
		public IContentManager<SpriteFont> FonsManager { get; set; }
		public KeyboardState KeyboardState
		{
			get { return Keyboard.GetState(); }
		}
		public MouseState MouseState
		{
			get { return Mouse.GetState(); }
		}

		public Rectangle MousePosition {
			get {
				var mouseState = MouseState;
				var mouseSize = Vector2.One;
				return new Rectangle(mouseState.X, mouseState.Y, (int) mouseSize.X, (int) mouseSize.Y);
			}
		}
	}

}
