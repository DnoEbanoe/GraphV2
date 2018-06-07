using System;
using Microsoft.Xna.Framework.Input;

namespace Graph.Core {
	public class GameObjectClickEventArgs : EventArgs {
		public MouseState MouseState { get; set; }
		public GameObjectClickEventArgs() {}

		public GameObjectClickEventArgs(MouseState mouseState) {
			MouseState = mouseState;
		}
	}
}
