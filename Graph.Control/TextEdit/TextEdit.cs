using System;
using System.Runtime.Remoting.Messaging;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graph.Control.TextEdit {

	public class TextEdit : Container.Container {
		private float _sleapTime = 100;
		private float _oldClickTime;
		private Label.Label Label { get; set; }
		private bool _isFocused = false;

		public string Text {
			get { return Label.Text; }
			set { Label.Text = value; }
		}

		public TextEdit(GameManager gameManager) : base(gameManager) {
			this.Add(Label = new Label.Label(gameManager));
			GameManager = gameManager;
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			var mouseState = GameManager.MouseState;
			if (mouseState.LeftButton == ButtonState.Pressed) {
				if (this.GetRectangle().Collide(GameManager.MousePosition)) {
					_isFocused = true;
				}
				else {
					_isFocused = false;
				}
			}
			if (_isFocused) {
				var keyState = GameManager.KeyboardState;
				var keys = keyState.GetPressedKeys();
				if (keys.Length == 1) {
					_oldClickTime += gameTime.ElapsedGameTime.Milliseconds;
					if (_oldClickTime >= _sleapTime) {
						_oldClickTime = 0;
						Text = GetNewText(keys[0], Text);
					}
				}
			}
		}

		private string GetNewText(Keys key, string text) {
			var newText = (string) text.Clone();
			if (key > Keys.A && key < Keys.Z) {
				newText += (char) key;
			}
			else if (key > Keys.D0 && key < Keys.D9) {
				newText += (char) key;
			}
			else if (key == Keys.Back) {
				newText = newText.Remove(newText.Length - 1, 1);
			}
			return newText;
		}
	}
}
