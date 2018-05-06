using System.Linq;
using Graph.Control;
using Graph.Control.Button;
using Graph.Control.Container;
using Graph.Control.Helpers;
using Graph.Control.Line;
using Graph.Control.Texture;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Graph.UI {
	internal class GraphPanel : Container {
		private bool _isClick;
		public Vector2 PointSize { get; set; } = new Vector2(20, 20);
		private GraphLine CurrentLine { get; set; }
		private IControl StartPointingPath { get; set; }
		private IControl EndPointingPath { get; set; }

		public GraphPanel(GameManager gameManager) : base(gameManager) {
			GameManager = gameManager;
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			var mouseState = GameManager.MouseState;
			if (!_isClick && GameManager.MousePosition.Collide(this.GetRectangle())) {
				var newPosition = GameManager.MousePosition.Location.ToVector2() - new Vector2(PointSize.X / 2, PointSize.Y / 2) - this.Position;
				if (GameManager.MouseState.LeftButton == ButtonState.Pressed) {
					if (SysSettings.IsAddPoint) {
						AddPoint(newPosition);
					}
					else if (SysSettings.IsAddLine) {
						AddLine(newPosition);
					}
					else if (SysSettings.IsPointingPath) {
						SetPointingPath(newPosition, PointingPathType.Start);
					}
					_isClick = true;
				}
				if (mouseState.RightButton == ButtonState.Pressed) {
					if (CurrentLine != null) {
						this.Remove(CurrentLine);
					}
					else if (SysSettings.IsPointingPath) {
						SetPointingPath(newPosition, PointingPathType.End);
					}
					_isClick = true;
				}
			}

			if (mouseState.LeftButton == ButtonState.Released && mouseState.RightButton == ButtonState.Released) {
				_isClick = false;
			}

			base.Update(gameTime, options);
		}

		private void AddPoint(Vector2 position) {
			var newRectangle = new Rectangle((position + this.Position).ToPoint(), PointSize.ToPoint());
			if (Items.GetElements(newRectangle, "collade-item").Any()) {
				return;
			}

			var itemNumber = Items.GetElements("point").Count + 1;
			var point = new GraphPoint(GameManager) {
				BackgroundTexture = new ImageTexture(GameManager, "point1"),
				Position = position,
				Size = PointSize,
				Number = itemNumber
			};
			point.Tags.Add("point");
			point.Tags.Add("collade-item");
			this.Add(point);
		}

		private void AddLine(Vector2 position) {
			var newRectangle = new Rectangle((position + this.Position).ToPoint(), PointSize.ToPoint());
			var point = Items.GetElements(newRectangle, "point").FirstOrDefault();
			if (point != null) {
				if (CurrentLine == null) {
					CurrentLine = new GraphLine(GameManager);
					CurrentLine.StartPoint = point;
					CurrentLine.Tags.Add("line");
					this.Add(CurrentLine);
				}
				else {
					CurrentLine.EndPoint = point;
					CurrentLine = null;
				}
			}
		}

		private void SetPointingPath(Vector2 position, PointingPathType pathType) {
			var newRectangle = new Rectangle((position + this.Position).ToPoint(), PointSize.ToPoint());
			var point = Items.GetElements(newRectangle, "point").FirstOrDefault();
			if (point != null) {
				var oldPoint = pathType == PointingPathType.Start ? StartPointingPath : EndPointingPath;
				if (oldPoint != null) {
					((Button) oldPoint).Border = new Border();
				}
				((Button)point).Border = new Border() { Color = pathType == PointingPathType.Start ? Color.Blue : Color.Red, Width = 2 };
				if (pathType == PointingPathType.Start) {
					StartPointingPath = point;
				}
				else {
					EndPointingPath = point;
				}
			}
		}
	}

	enum PointingPathType {
		Start,
		End
	}
}
