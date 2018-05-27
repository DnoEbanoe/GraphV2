using Graph.Control;
using Graph.Control.Helpers;
using Graph.Control.Line;
using Graph.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.UI
{
	public class GraphLine: Line
	{
		private IControl _startPoint;
		private IControl _endPoint;

		public IControl StartPoint {
			get => _startPoint;
			set {
				_startPoint = value;
				base.Start = value.GetCenter();
			}
		}
		public IControl EndPoint {
			get => _endPoint;
			set {
				_endPoint = value;
				base.End = value.GetCenter();
			}
		}
		public SpriteFont Font { get; set; }
		public double Distance { get; set; }
		public GraphLine(GameManager gameManager) : base(gameManager) {
			Font = GameManager.FonsManager.Get("font:standart");
			ResetColor();
			Width = 5;
		}

		

		public override void Drow(GameTime gameTime, DrowOptions options) {
			GameManager.SpriteBatch.DrawString(Font, Distance.ToString("F1"), TextPosition, Color.White);
			base.Drow(gameTime, options);
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			var endPosition = base.End ?? GameManager.MousePosition.Location.ToVector2();
			TextPosition = new Vector2((int)((base.Start.X + endPosition.X) / 2), (int)((base.Start.Y + endPosition.Y) / 2));
			Distance = Vector2.Distance(base.Start, endPosition);
			base.Update(gameTime, options);
		}

		public void ResetColor() {
			Color = new Color(Color.Red, 0.25f);
		}

		public Vector2 TextPosition { get; set; }
	}
}
