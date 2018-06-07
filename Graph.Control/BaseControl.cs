using System.Collections.Generic;
using Graph.Core;
using Microsoft.Xna.Framework;

namespace Graph.Control {

	public abstract class BaseControl : IControl {
		private Vector2 _position = Vector2.Zero;
		private Vector2 _size = Vector2.Zero;
		public GameManager GameManager { get; set; }
		public List<string> Tags { get; set; } = new List<string>();
		protected UpdateOptions UpdateOptions { get; set; }
		protected DrowOptions DrowOptions { get; set; }

		public virtual void Draw(GameTime gameTime, DrowOptions options) {
			DrowOptions = options;
		}

		public virtual void Update(GameTime gameTime, UpdateOptions options) {
			UpdateOptions = options;
		}

		public virtual Vector2 Position {
			get { return _position + UpdateOptions.Position; }
			set { _position = value; }
		}

		public virtual Vector2 Size {
			get { return _size + UpdateOptions.Size; }
			set { _size = value; }
		}

		public BaseControl(GameManager gameManager) {
			GameManager = gameManager;
		}
	}
}
