using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Container
{
	public class Container: BaseControl
	{
		public GameManager GameManager { get; }
		private List<IControl> Items { get; set; } = new List<IControl>();
		public Texture2D BackgroundTexture { get; set; }
		public Container(GameManager gameManager) : base(gameManager) {
			GameManager = gameManager;
		}

		public void Add(IControl control) {
			control.Position += Position;
			control.Size += Size;
			Size += control.Size;
			Items.Add(control);
		}
		public override void Drow(GameTime gameTime) {
			foreach (var control in Items) {
				control.Drow(gameTime);
			}
			if (BackgroundTexture != null) {
				GameManager.SpriteBatch.Draw(BackgroundTexture, this.GetRectangle(), null, Color.White);
			}
		}

		public override void Update(GameTime gameTime) {
			foreach (var control in Items) {
				control.Update(gameTime);
			}
		}
	}
}
