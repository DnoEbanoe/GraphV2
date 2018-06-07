using System;
using Graph.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Line {
	public class Line : BaseControl {
		public Vector2 Start { get; set; }
		public Vector2? End { get; set; }
		public int Width { get; set; }
		public virtual Color Color { get; set; }
		private Texture2D Texture { get; set; }

		public Line(GameManager gameManager) : base(gameManager) {
			Texture = new Texture2D(gameManager.GraphicsDeviceManager.GraphicsDevice, 1, 1);
			Texture.SetData(new[] {Color.White});
		}

		public override void Draw(GameTime gameTime, DrowOptions options) {
			base.Draw(gameTime, options);
			Vector2 endPosition;
			if (End == null) {
				endPosition = GameManager.MousePosition.Location.ToVector2();
			} else {
				endPosition = new Vector2(End.Value.X, End.Value.Y);
			}
			var startPosition = new Vector2(Start.X, Start.Y);
			DrawLine(startPosition, endPosition);
		}

		void DrawLine(Vector2 start, Vector2 end) {
			Vector2 edge = end - start;
			float angle = (float) Math.Atan2(edge.Y, edge.X);
			GameManager.SpriteBatch.Draw(Texture,
				new Rectangle((int) start.X, (int) start.Y, (int) edge.Length(), Width),
				null, this.Color, angle, new Vector2(0, 0), SpriteEffects.None, 0);
		}
	}
}
