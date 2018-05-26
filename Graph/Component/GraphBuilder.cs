using Graph.Core;
using Graph.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Graph.Component {
	public class GraphBuilder {
		public GameManager GameManager { get; }
		public GraphPanel GraphPanel { get; }

		public GraphBuilder(GameManager gameManager, GraphPanel graphPanel) {
			GameManager = gameManager;
			GraphPanel = graphPanel;
			graphPanel.Click += GraphPanelClick;
		}

		private void GraphPanelClick(object o, GameObjectClickEventArgs gameObjectClickEventArgs) {
			var pointSize = SysSettings.PointSize;
			var newPosition = GameManager.MousePosition.Location.ToVector2() - new Vector2(pointSize.X / 2, pointSize.Y / 2) - GraphPanel.Position;
			if (gameObjectClickEventArgs.MouseState.LeftButton == ButtonState.Pressed) {
				if (SysSettings.IsAddPoint) {
					GraphPanel.AddPoint(newPosition);
				}
				else if (SysSettings.IsAddLine) {
					GraphPanel.AddLine(newPosition);
				}
				else if (SysSettings.IsPointingPath) {
					GraphPanel.SetPointingPath(newPosition);
				}
				else if (SysSettings.IsRemovePoint) {
					GraphPanel.RepovePoint(newPosition);
				}
			}
			if (gameObjectClickEventArgs.MouseState.RightButton == ButtonState.Pressed) {
				if (GraphPanel.CurrentLine != null) {
					GraphPanel.Remove(GraphPanel.CurrentLine);
				}
			}
		}
	}
}
