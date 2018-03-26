using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Cursor {
	public class Cursor : BaseControl {
		private Texture2D Texture { get; set; }
		private readonly GameManager _gameManager;

		public Cursor(GameManager gameManager) : base(gameManager) {
			Texture = gameManager.TextureManager.Get("image:cursor");
			_gameManager = gameManager;
		}

		public override void Drow(GameTime gameTime, DrowOptions options) {
			GameManager.SpriteBatch.Draw(Texture, Position, Color.White);
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			Position = _gameManager.MouseState.Position.ToVector2();
		}
	}
}
