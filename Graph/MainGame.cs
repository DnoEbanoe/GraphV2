﻿using System.Collections.Generic;
using System.Linq;
using Graph.Component;
using Graph.Control;
using Graph.Control.Button;
using Graph.Control.Cursor;
using Graph.Control.Helpers;
using Graph.Control.Label;
using Graph.Core;
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
		private GraphPanel GraphPanel { get; set; }
		private Label MessageLabel { get; set; }

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

			#region MainMenu

			MainMenu mainMenu = new MainMenu(GameManager);
			mainMenu.Tags.Add("menu");
			mainMenu.Tags.Add("collade-item");
			mainMenu.Click += MainMunuOnClick;
			_gameEngine.Add(mainMenu);
			#endregion

			#region GraphPanel
			
			var graphWidth = GameManager.GraphicsDeviceManager.PreferredBackBufferWidth;
			var graphHeight = GameManager.GraphicsDeviceManager.PreferredBackBufferHeight;
			GraphPanel = new GraphPanel(GameManager){Position = new Vector2(0, 42), Size = new Vector2(graphWidth, graphHeight - 70), Border = new Border(){Color = Color.Gold, Width = 3}};
			_gameEngine.Add(GraphPanel);
			new GraphBuilder(GameManager, GraphPanel);

			#endregion

			#region MessageLabel

			MessageLabel = new Label(GameManager) {Color = Color.Black, Position = new Vector2(50, graphHeight - 20)};
			_gameEngine.Add(MessageLabel);
			#endregion

			_gameEngine.Add(new Cursor(GameManager));
		}

		private void MainMunuOnClick(IControl control, GameObjectClickEventArgs eventArgs) {
			var button = (Button) control;
			if (button.Tags.Contains("IsAddPoint")) {
				MainMenu.ResetSysSettings();
				SysSettings.IsAddPoint = true;
			}
			else if (button.Tags.Contains("IsAddLine")) {
				MainMenu.ResetSysSettings();
				SysSettings.IsAddLine = true;
			}
			else if (button.Tags.Contains("IsRemovePoint")) {
				MainMenu.ResetSysSettings();
				SysSettings.IsRemovePoint = true;
			}
			else if (button.Tags.Contains("IsPointingPath")) {
				MainMenu.ResetSysSettings();
				SysSettings.IsPointingPath = true;
			}
			else if (button.Tags.Contains("SearchPath")) {
				MainMenu.ResetSysSettings();
				ResetPreviousPath();
				SearchPath();
			}
		}

		private void ResetPreviousPath() {
			var lines = GraphPanel.Items.GetElements("line").Cast<GraphLine>();
			foreach (var graphLine in lines) {
				graphLine.ResetColor();
			}
		}

		private void SearchPath() {
			string message;
			if (GraphPanel.PointingPath == null) {
				message = "Specify the end point!!!";
			} else {
				var points = GraphPanel.Items.GetElements("point").Cast<GraphPoint>().ToList();
				var lines = GraphPanel.Items.GetElements("line").Cast<GraphLine>().ToList();
				double[,] arr = new double[points.Count, points.Count];
				foreach (var graphLine in lines) {
					var startPoint = (GraphPoint) graphLine.StartPoint;
					var endPoint = (GraphPoint) graphLine.EndPoint;
					arr[startPoint.Number - 1, endPoint.Number - 1] = graphLine.Distance;
					arr[endPoint.Number - 1, startPoint.Number - 1] = graphLine.Distance;
				}
				Dijstra d = new Dijstra();
				var rez = d.GetDistance(arr, points.Count).ToList();
				var pointingPathNumber = ((GraphPoint) GraphPanel.PointingPath).Number - 1;
				var distance = rez[pointingPathNumber];
				if (distance == null) {
					message = "Path not found";
				}
				else {
					var path = ValidatePath(distance.Path.Select(i => i + 1)).ToList();
					message = $"Shortcut: {string.Join(" --> ", path)}. Distance: {distance.Value:F1}";
					for (int i = 1; i < path.Count; i++) {
						var startI = path[i - 1];
						var endI = path[i];
						var line = lines.First(graphLine => (((GraphPoint) graphLine.StartPoint).Number == startI || ((GraphPoint) graphLine.StartPoint).Number == endI)
							&& (((GraphPoint) graphLine.EndPoint).Number == startI || ((GraphPoint) graphLine.EndPoint).Number == endI));
						line.Color = new Color(Color.Yellow, 0.1f);
					}
				}
			}
			MessageLabel.Text = message;
		}


		private IEnumerable<int> ValidatePath(IEnumerable<int> path) {
			var pathList = path.ToList();
			foreach (var i in path) {
				var startIndex = pathList.IndexOf(i);
				var endIndex = pathList.LastIndexOf(i);
				if (startIndex != endIndex) {
					pathList.RemoveRange(startIndex, endIndex - startIndex);
				}
			}
			pathList.Insert(0, 1);
			return pathList;
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
