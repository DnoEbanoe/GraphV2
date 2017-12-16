using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core;
using Microsoft.Xna.Framework;

namespace Graph.Control.Button {

	public class Button : IButton {
		public Button() { }

		public GameManager GameManager { get; set; }

		public void Drow(GameTime gameTime) {
			if (Test != null) {
				
			}
		}

		public void Update(GameTime gameTime) { }

		public event Action<IButton, ButtonEventArgs> Click;
		public string Test { get; set; }

		protected virtual void OnClick(IButton arg1, ButtonEventArgs arg2) {
			Click?.Invoke(arg1, arg2);
		}
	}

}
