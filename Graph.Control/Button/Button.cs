using System;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Graph.Control.Button {

	public class Button : Container.Container {
		private bool _isClick;

		public string Text {
			get => Label.Text;
			set => Label.Text = value;
		}

		private Label.Label Label { get; set; }

		public Button(GameManager manager) : base(manager) {
			this.Add(Label = new Label.Label(GameManager));
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			base.Update(gameTime, options);
			var mouseState = GameManager.MouseState;
			if (!_isClick &&
			    mouseState.LeftButton == ButtonState.Pressed &&
			    GameManager.MousePosition.Collide(this.GetRectangle())) {
				OnClick();
				_isClick = true;
				return;
			}
			if (mouseState.LeftButton == ButtonState.Released) {
				_isClick = false;
			}
		}

		protected virtual void OnClick() {
			OnClick(this, new ButtonEventArgs());
		}

		public event Action<Button, ButtonEventArgs> Click;

		protected virtual void OnClick(Button arg1, ButtonEventArgs arg2) {
			Click?.Invoke(arg1, arg2);
		}
	}
}