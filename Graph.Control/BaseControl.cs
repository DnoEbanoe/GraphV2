using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core;
using Microsoft.Xna.Framework;

namespace Graph.Control
{

	public abstract class BaseControl: IControl
	{
		private Vector2 _position;
		private Vector2 _size;
		public GameManager GameManager { get; set; }
		private UpdateOptions UpdateOptions { get; set; }
		private DrowOptions DrowOptions { get; set; }

		public virtual void Drow(GameTime gameTime, DrowOptions options) {
			DrowOptions = options;
		}

		public virtual void Update(GameTime gameTime, UpdateOptions options) {
			UpdateOptions = options;
		}
		public virtual Color Color { get; set; }

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
			Color = Color.White;
			Position = Vector2.Zero;
			Size = Vector2.Zero;
		}
	}
}
