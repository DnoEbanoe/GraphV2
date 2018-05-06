using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Control;
using Graph.Control.Helpers;
using Graph.Control.Line;
using Graph.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.UI
{
	public class GraphLine: BaseControl
	{
		private IControl _startPoint;
		private IControl _endPoint;

		public IControl StartPoint {
			get => _startPoint;
			set {
				_startPoint = value;
				Line.Start = value.GetCenter();
			}
		}
		public IControl EndPoint {
			get => _endPoint;
			set {
				_endPoint = value;
				Line.End = value.GetCenter();
			}
		}
		public int Width {
			get => Line.Width;
			set => Line.Width = value;
		}
		public virtual Color Color {
			get => Line.Color;
			set => Line.Color = value;
		}
		public SpriteFont Font { get; set; }
		public double Distance { get; set; }
		private Line Line { get; set; }
		public GraphLine(GameManager gameManager) : base(gameManager) {
			Font = GameManager.FonsManager.Get("font:standart");
			Line = new Line(gameManager);
			Color = Color.Red;
			Width = 5;
		}

		

		public override void Drow(GameTime gameTime, DrowOptions options) {
			Line.Drow(gameTime, options);
			GameManager.SpriteBatch.DrawString(Font, Distance.ToString("F1"), TextPosition, Color.White);
			base.Drow(gameTime, options);
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			var endPosition = Line.End ?? GameManager.MousePosition.Location.ToVector2();
			TextPosition = new Vector2((int)((Line.Start.X + endPosition.X) / 2), (int)((Line.Start.Y + endPosition.Y) / 2));
			Distance = Vector2.Distance(Line.Start, endPosition);
			Line.Update(gameTime, options);
			base.Update(gameTime, options);
		}

		public Vector2 TextPosition { get; set; }
	}
}
