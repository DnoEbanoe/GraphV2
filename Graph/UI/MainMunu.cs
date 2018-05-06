using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Component;
using Graph.Control;
using Graph.Control.Button;
using Graph.Control.Container;
using Graph.Control.Texture;
using Graph.Core;
using Microsoft.Xna.Framework;

namespace Graph.UI {
	internal class MainMunu : Container {
		private Vector2 ItemSize { get; set; } = new Vector2(100, 50);
		public event Action<IControl, MenuClickEventArgs> Click; 
		public MainMunu(GameManager gameManager) : base(gameManager) {
			AutoSize = true;
			var addPointButton = new Button(gameManager) {
				Text = "AddPoint",
				BackgroundTexture = new ColorTexture(GameManager, Color.Blue),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			addPointButton.Tags.Add("IsAddPoint");
			addPointButton.Click += (button, args) => { OnClick(button); };
			var addLineButton = new Button(gameManager) {
				Text = "AddLine",
				BackgroundTexture = new ColorTexture(GameManager, Color.Red),
				Position = new Vector2(ItemSize.X, 0),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			addLineButton.Tags.Add("IsAddLine");
			addLineButton.Click += (button, args) => { OnClick(button); };
			var pointingPathButton = new Button(gameManager) {
				Text = "pointingPat",
				BackgroundTexture = new ColorTexture(GameManager, Color.Red),
				Position = new Vector2(ItemSize.X * 2, 0),
				Size = ItemSize,
				Border = new Border() {Width = 2, Color = Color.Aqua},
				TextColor = Color.Yellow
			};
			pointingPathButton.Tags.Add("IsPointingPath");
			pointingPathButton.Click += (button, args) => { OnClick(button); };
			var searchPathButton = new Button(gameManager)
			{
				Text = "Search",
				BackgroundTexture = new ColorTexture(GameManager, Color.Red),
				Position = new Vector2(ItemSize.X * 3, 0),
				Size = ItemSize,
				Border = new Border() { Width = 2, Color = Color.Aqua },
				TextColor = Color.Yellow
			};
			searchPathButton.Tags.Add("SearchPath");
			searchPathButton.Click += (button, args) => { OnClick(button); };
			this.Add(addPointButton);
			this.Add(addLineButton);
			this.Add(pointingPathButton);
			this.Add(searchPathButton);
		}

		internal static void ResetSysSettings() {
			SysSettings.IsAddPoint = SysSettings.IsAddLine = false;
		}

		protected virtual void OnClick(IControl arg1) {
			Click?.Invoke(arg1, new MenuClickEventArgs());
		}
	}
}
