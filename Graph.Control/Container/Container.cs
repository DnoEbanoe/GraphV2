using System.Collections.Generic;
using Graph.Control.Texture;
using Graph.Core;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;

namespace Graph.Control.Container {

	public class Container : BaseControl {
		private Border _border = new Border();
		public List<IControl> Items { get; protected set; } = new List<IControl>();
		public BaseTexture BackgroundTexture { get; set; }
		public Margin Margin { get; set; } = Margin.Zero;
		public Margin ItemMargin { get; set; } = new Margin(0);
		public ContentAlign Align { get; set; }
		public Border Border {
			get => _border;
			set {
				_border = value;
				if (value != null
				    && LeftBorderLine != null && TopBorderLine != null
				    && RigthBorderLine != null && BottomBorderLine != null) {
					LeftBorderLine.Color = TopBorderLine.Color = RigthBorderLine.Color = BottomBorderLine.Color = value.Color;
					LeftBorderLine.Width = TopBorderLine.Width = RigthBorderLine.Width = BottomBorderLine.Width = value.Width;
				}
			}
		}
		public bool AutoSize { get; set; }
		private Line.Line LeftBorderLine { get; set; }
		private Line.Line TopBorderLine { get; set; }
		private Line.Line RigthBorderLine { get; set; }
		private Line.Line BottomBorderLine { get; set; }

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
			set { base.Size = value; }
		}

		public override Vector2 Position {
			get { return base.Position; }
			set {
				base.Position = value;
				UpdateBorder();
			}
		}

		public Container(GameManager gameManager) : base(gameManager) {
			GameManager = gameManager;
			LeftBorderLine = new Line.Line(gameManager);
			TopBorderLine = new Line.Line(gameManager);
			RigthBorderLine = new Line.Line(gameManager);
			BottomBorderLine = new Line.Line(gameManager);
		}

		public virtual void Add(IControl control) {
			Items.Add(control);
		}

		public virtual void Remove(IControl control) {
			Items.Remove(control);
		}

		public override void Draw(GameTime gameTime, DrowOptions options) {
			var rectangle = this.GetRectangle();
			if (BackgroundTexture != null && rectangle != Rectangle.Empty) {
				GameManager.SpriteBatch.Draw(BackgroundTexture.GetTexture(rectangle), this.GetRectangle(), null,
					Color.White);
			}
			foreach (var item in Items) {
				item.Draw(gameTime, options);
			}
			BorderDrow(gameTime, options);
			base.Draw(gameTime, options);
		}

		private void BorderDrow(GameTime gameTime, DrowOptions options) {
			if (!Border.IsEmpty(Border)) {
				LeftBorderLine.Draw(gameTime, options);
				TopBorderLine.Draw(gameTime, options);
				RigthBorderLine.Draw(gameTime, options);
				BottomBorderLine.Draw(gameTime, options);
			}
		}

		private void UpdateBorder() {
			if (!Border.IsEmpty(Border)) {
				LeftBorderLine.Start = Position;
				LeftBorderLine.End = Position + new Vector2(0, Size.Y);
				TopBorderLine.Start = Position;
				TopBorderLine.End = Position + new Vector2(Size.X, 0);
				RigthBorderLine.Start = Position + new Vector2(Size.X, 0);
				RigthBorderLine.End = Position + Size;
				BottomBorderLine.Start = Position + Size;
				BottomBorderLine.End = Position + new Vector2(0, Size.Y);
			}
		}

		public override void Update(GameTime gameTime, UpdateOptions options) {
			var itemStartPosition = Position + new Vector2(ItemMargin.Left + Margin.Left, ItemMargin.Top + Margin.Top) - UpdateOptions.Position;
			foreach (var item in Items) {
				item.Update(gameTime, options + new UpdateOptions {Position = itemStartPosition});
			}
			base.Update(gameTime, options);
			UpdateBorder();
		}
	}
}