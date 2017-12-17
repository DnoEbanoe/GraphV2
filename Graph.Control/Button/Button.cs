using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graph.Control.Button {

	public class Button : BaseControl {
		private const int _clickedTime = 200;
		private bool isClick;
		private int _oldClickedTime = 0;
		private SpriteFont Font { get; set; }
		public Button(GameManager manager): base(manager)
		{
			Font = GameManager.FonsManager.Get("font:test");
			Size = new Vector2(50, 50);
		}
		public override void Drow(GameTime gameTime) {
			if (Test != null) {
				GameManager.SpriteBatch.DrawString(Font, Test, Position, Color);
			}
		}

		public override void Update(GameTime gameTime) {
			var mouseState = GameManager.MouseState;
			if (GetIsClicked() &&
				mouseState.LeftButton == ButtonState.Pressed &&
				GameManager.MousePosition.Collide(this.GetRectangle())) {
				OnClick();
				_oldClickedTime = _clickedTime;
				isClick = true;
				return;
			}
			if (mouseState.LeftButton == ButtonState.Released) {
				isClick = false;
			}
		}

		void OnClick() {
			Test += "az";
		}

		private bool GetIsClicked() {
			return !isClick;
			//_oldClickedTime == 0;
		}
		private void SetClickedSlip(GameTime gameTime) {
			if (_oldClickedTime < 0) {
				_oldClickedTime = 0;
				return;
			}
			_oldClickedTime -= gameTime.ElapsedGameTime.Milliseconds;
		}

		public event Action<Button, ButtonEventArgs> Click;
		public string Test { get; set; }

		protected virtual void OnClick(Button arg1, ButtonEventArgs arg2) {
			Click?.Invoke(arg1, arg2);
		}
	}

}
