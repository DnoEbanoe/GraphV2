using System;
using System.Linq;
using Graph.Component;
using Graph.Control;
using Graph.Control.Button;
using Graph.Control.Container;
using Graph.Control.Helpers;
using Graph.Control.Texture;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Graph.UI {
	public class GraphPanel : Container {
		private bool _isClick;
		public GraphLine CurrentLine { get; set; }
		public IControl PointingPath { get; set; }
		public Action<object, GameObjectClickEventArgs> Click;

		public GraphPanel(GameManager gameManager) : base(gameManager) {
			GameManager = gameManager;
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			var mouseState = GameManager.MouseState;
			if (!_isClick && GameManager.MousePosition.Collide(this.GetRectangle())) {
				if (mouseState.LeftButton == ButtonState.Pressed) {
					_isClick = true;
					OnClick(new GameObjectClickEventArgs(mouseState));
				}
				if (mouseState.RightButton == ButtonState.Pressed) {
					_isClick = true;
					OnClick(new GameObjectClickEventArgs(mouseState));
				}
			}
			if (mouseState.LeftButton == ButtonState.Released && mouseState.RightButton == ButtonState.Released) {
				_isClick = false;
			}
			base.Update(gameTime, options);
		}

		public void RepovePoint(Vector2 position) {
			var newRectangle = new Rectangle((position + this.Position).ToPoint(), SysSettings.PointSize.ToPoint());
			var point = Items.GetElements(newRectangle, "point").FirstOrDefault();
			if (point != null) {
				var lines = Items.GetElements("line").Cast<GraphLine>().Where(control => control.StartPoint == point || control.EndPoint == point);
				foreach (var graphLine in lines) {
					this.Remove(graphLine);
				}
				this.Remove(point);
				var i = 1;
				if (Items.Count > 0) {
					foreach (var control in Items.GetElements("point").Cast<GraphPoint>().OrderBy(control => control.Number)) {
						control.Number = i;
						i++;
					}
				}
			}
		}

		public void AddPoint(Vector2 position) {
			var newRectangle = new Rectangle((position + this.Position).ToPoint(), SysSettings.PointSize.ToPoint());
			if (Items.GetElements(newRectangle, "collade-item").Any()) {
				return;
			}
			var points = Items.GetElements("point");
			var itemNumber = points.Count == 0 ? 1 : points.Cast<GraphPoint>().Max(graphPoint => graphPoint.Number) + 1;
			var point = new GraphPoint(GameManager) {
				BackgroundTexture = new ImageTexture(GameManager, "point1"),
				Position = position,
				Size = SysSettings.PointSize,
				Number = itemNumber
			};
			point.Tags.Add("point");
			point.Tags.Add("collade-item");
			this.Add(point);
		}

		public void AddLine(Vector2 position) {
			var newRectangle = new Rectangle((position + this.Position).ToPoint(), SysSettings.PointSize.ToPoint());
			var point = Items.GetElements(newRectangle, "point").FirstOrDefault();
			if (point != null) {
				if (CurrentLine == null) {
					CurrentLine = new GraphLine(GameManager);
					CurrentLine.StartPoint = point;
					CurrentLine.Tags.Add("line");
					this.Add(CurrentLine);
				} else {
					CurrentLine.EndPoint = point;
					CurrentLine = null;
				}
			}
		}

		public void SetPointingPath(Vector2 position) {
			var newRectangle = new Rectangle((position + this.Position).ToPoint(), SysSettings.PointSize.ToPoint());
			var point = Items.GetElements(newRectangle, "point").FirstOrDefault();
			if (point != null) {
				if (PointingPath != null) {
					((Button) PointingPath).Border = new Border();
				}
				((Button) point).Border = new Border() {Color = Color.Yellow, Width = 2};
				PointingPath = point;
			}
		}

		protected void OnClick(GameObjectClickEventArgs eventArgs) {
			Click?.Invoke(this, eventArgs);
		}
	}
}
