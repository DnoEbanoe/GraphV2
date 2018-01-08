using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Control.Texture;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Control.Container {

	public class Container : BaseControl {
		private List<IControl> Items { get; set; } = new List<IControl>();
		public BaseTexture BackgroundTexture { get; set; }
		public Margin Margin { get; set; } = Margin.Zero;
		public Margin ItemMargin { get; set; } = new Margin(5);
		public ContentAlign Align { get; set; }
		public bool AutoSize { get; set; }

		public override Vector2 Size {
			get {
				var size = base.Size;
				if (AutoSize) {
					size = Vector2.Zero;
					foreach (var item in Items) {
						size += item.Size + item.Position - Position;
					}
				}
				return new Vector2(size.X + (Margin.Right + Margin.Left), size.Y + (Margin.Bottom + Margin.Top));
			}
			set {
				base.Size = value;
			}
		}

		public Container(GameManager gameManager) : base(gameManager) {
			GameManager = gameManager;
		}

		public virtual void Add(IControl control) {
			Items.Add(control);
		}

		public override void Drow(GameTime gameTime, DrowOptions options) {
			if (BackgroundTexture != null) {
				GameManager.SpriteBatch.Draw(BackgroundTexture.GetTexture(this.GetRectangle()), this.GetRectangle(), null,
					Color.White);
			}
			foreach (var item in Items) {
				item.Drow(gameTime, options);
			}
			base.Drow(gameTime, options);
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			var itemStartPosition = Position + new Vector2(ItemMargin.Left, ItemMargin.Top);
			foreach (var item in Items) {
				item.Update(gameTime, options + new UpdateOptions(){Position = itemStartPosition});
			}
			base.Update(gameTime, options);
		}
	}
}
