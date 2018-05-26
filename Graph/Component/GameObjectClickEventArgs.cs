using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Graph.Component {
	public class GameObjectClickEventArgs : EventArgs {
		public MouseState MouseState { get; set; }
		public GameObjectClickEventArgs() {
		}

		public GameObjectClickEventArgs(MouseState mouseState) {
			MouseState = mouseState;
		}
		
	}
}
