using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core;
using Microsoft.Xna.Framework;

namespace Graph.Control
{

	public class BaseControl: IControl
	{
		public GameManager GameManager { get; set; }
		public virtual void Drow(GameTime gameTime) { }
		public virtual void Update(GameTime gameTime) { }
		public Color Color { get; set; }
		public Vector2 Position { get; set; }
		public Vector2 Size { get; set; }

		public BaseControl(GameManager gameManager) {
			GameManager = gameManager;
			Color = Color.White;
			Position = Vector2.Zero;
			Size = Vector2.Zero;
		}
	}
}
