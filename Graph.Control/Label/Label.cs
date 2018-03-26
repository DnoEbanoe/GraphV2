using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Label {

	public class Label : BaseControl {
		public string Text { get; set; }
		public SpriteFont Font { get; set; }
		public virtual Color Color { get; set; }

		public override Vector2 Size {
			get { return Font.MeasureString(Text ?? string.Empty); }
		}

		public Label(GameManager gameManager) : base(gameManager) {
			Font = GameManager.FonsManager.Get("font:standart");
		}

		public override void Drow(GameTime gameTime, DrowOptions options) {
			GameManager.SpriteBatch.DrawString(Font, Text, Position, Color);
			base.Drow(gameTime, options);
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			base.Update(gameTime, options);
		}
	}
}