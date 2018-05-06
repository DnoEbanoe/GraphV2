using System;
using System.Linq;
using Graph.Component;
using Graph.Control;
using Graph.Control.Button;
using Graph.Control.Container;
using Graph.Control.Cursor;
using Graph.Control.Helpers;
using Graph.Control.Line;
using Graph.Control.TextEdit;
using Graph.Control.Texture;
using Graph.Core;
using Graph.Core.Helper;
using Graph.Core.Manager;
using Graph.Math;
using Graph.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graph {

	public class MainGame : Game {
		private readonly GameEngine _gameEngine;
		private GameManager GameManager { get; set; }
		internal GraphPanel GraphPanel { get; private set; }

		public MainGame() {
			GameManager = new GameManager {GraphicsDeviceManager = new GraphicsDeviceManager(this)};
			GameManager.ContentManager = new GraphContentManager(Services);
			GameManager.FonsManager = new BaseContentManager<SpriteFont>(GameManager.ContentManager);
			GameManager.TextureManager = new BaseContentManager<Texture2D>(GameManager.ContentManager);
			_gameEngine = new GameEngine(GameManager);
			Content.RootDirectory = "Content";
		}

		protected override void LoadContent() {
			GameManager.SpriteBatch = new SpriteBatch(GraphicsDevice);

			//#region Створення тестової кнопки
			//var btn = new Button(GameManager)
			//{
			//	Text = "Azazazaz",
			//	Margin = new Margin(5, 15, 15, 15),
			//	BackgroundTexture = new ColorTexture(GameManager, Color.Blue),
			//	AutoSize = true,
			//	Border = new Border() { Width = 5, Color = Color.Aqua },
			//	Position = new Vector2(50, 100),
			//	ItemMargin = Margin.Zero,
			//	TextColor = Color.Yellow
			//};
			//btn.Click += (button, args) => {
			//	SysSettings.IsAddPoint = !SysSettings.IsAddPoint;
			//	SysSettings.IsAddLine = !SysSettings.IsAddLine;
			//};
			//_gameEngine.Add(btn);
			//#endregion

			#region MainMenu

			MainMunu mainMunu = new MainMunu(GameManager);
			mainMunu.Tags.Add("menu");
			mainMunu.Tags.Add("collade-item");
			mainMunu.Click += MainMunuOnClick;
			_gameEngine.Add(mainMunu);
			#endregion

			#region GraphPanel

			GraphPanel = new GraphPanel(GameManager){Position = new Vector2(0, 50), Size = new Vector2(500, 500)};
			_gameEngine.Add(GraphPanel);
			#endregion

			_gameEngine.Add(new Cursor(GameManager));
		}

		private void MainMunuOnClick(IControl control, MenuClickEventArgs eventArgs) {
			var button = (Button) control;
			if (button.Tags.Contains("IsAddPoint")) {
				MainMunu.ResetSysSettings();
				SysSettings.IsAddPoint = true;
			} else if (button.Tags.Contains("IsAddLine")) {
				MainMunu.ResetSysSettings();
				SysSettings.IsAddLine = true;
			}
			else if (button.Tags.Contains("IsPointingPath")) {
				MainMunu.ResetSysSettings();
				SysSettings.IsPointingPath = true;
			} else if (button.Tags.Contains("SearchPath")) {
				var points = GraphPanel.Items.GetElements("point").Cast<GraphPoint>().ToList();
				var lines = GraphPanel.Items.GetElements("line").Cast<GraphLine>();
				double[,] arr = new double[points.Count, points.Count];
				foreach (var graphLine in lines) {
					var startPoint = (GraphPoint)graphLine.StartPoint;
					var endPoint = (GraphPoint)graphLine.EndPoint;
					arr[startPoint.Number - 1, endPoint.Number - 1] = graphLine.Distance;

				}
				Dijstra d = new Dijstra(arr, points.Count);
				var rez = d.Dist;
			}
		}

		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			_gameEngine.Update(gameTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);
			GameManager.SpriteBatch.Begin();
			_gameEngine.Drow(gameTime);
			GameManager.SpriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
