using System;
using Graph.Control;
using Graph.Control.Button;
using Graph.Control.Container;
using Graph.Control.Texture;
using Graph.Core;
using Microsoft.Xna.Framework;

namespace Graph.UI {
	internal class MainMenu : Container {
		private Vector2 ItemSize { get; set; } = new Vector2(42, 42);
		public Button AddPointButton { get; private set; }
		public Button AddLineButton { get; private set; }
		public Button PointingPathButton { get; private set; }
		public Button SearchPathButton { get; private set; }
		public Button RemovePointButton { get; private set; }

		public event Action<IControl, GameObjectClickEventArgs> Click;

		public MainMenu(GameManager gameManager) : base(gameManager) {
			AutoSize = true;
			AddPointButton = new Button(gameManager) {
				BackgroundTexture = new ImageTexture(gameManager, "point-btn"),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			AddPointButton.Tags.Add("IsAddPoint");
			AddPointButton.Click += (button, args) => { OnClick(button); };
			AddLineButton = new Button(gameManager) {
				BackgroundTexture = new ImageTexture(gameManager, "line-btn"),
				Position = new Vector2(ItemSize.X, 0),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			AddLineButton.Tags.Add("IsAddLine");
			AddLineButton.Click += (button, args) => { OnClick(button); };
			RemovePointButton = new Button(gameManager) {
				BackgroundTexture = new ImageTexture(gameManager, "remove-btn"),
				Position = new Vector2(ItemSize.X * 2, 0),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			RemovePointButton.Tags.Add("IsRemovePoint");
			RemovePointButton.Click += (button, args) => { OnClick(button); };
			PointingPathButton = new Button(gameManager) {
				BackgroundTexture = new ImageTexture(gameManager, "pointing-pat-btn"),
				Position = new Vector2(ItemSize.X * 3, 0),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			PointingPathButton.Tags.Add("IsPointingPath");
			PointingPathButton.Click += (button, args) => { OnClick(button); };
			SearchPathButton = new Button(gameManager) {
				BackgroundTexture = new ImageTexture(gameManager, "search-btn"),
				Position = new Vector2(ItemSize.X * 4, 0),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			SearchPathButton.Tags.Add("SearchPath");
			SearchPathButton.Click += (button, args) => { OnClick(button); };
			this.Add(AddPointButton);
			this.Add(AddLineButton);
			this.Add(RemovePointButton);
			this.Add(PointingPathButton);
			this.Add(SearchPathButton);
		}

		internal static void ResetSysSettings() {
			SysSettings.IsAddPoint = SysSettings.IsAddLine = SysSettings.IsPointingPath = SysSettings.IsRemovePoint = false;
		}

		private void ResetActiveButtons() {
			AddPointButton.Border = new Border(){Width = 2, Color = Color.Blue};
			AddLineButton.Border = new Border() { Width = 2, Color = Color.Blue };
			RemovePointButton.Border = new Border() { Width = 2, Color = Color.Blue };
			PointingPathButton.Border = new Border() { Width = 2, Color = Color.Blue };
			SearchPathButton.Border = new Border() { Width = 2, Color = Color.Blue };
		}

		protected virtual void OnClick(Button button) {
			ResetActiveButtons();
			button.Border = new Border() { Width = 2, Color = Color.Red };
			Click?.Invoke(button, new GameObjectClickEventArgs());
		}
	}
}
