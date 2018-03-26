using Graph.Control;
using Graph.Control.Button;
using Graph.Control.Container;
using Graph.Control.Cursor;
using Graph.Control.Line;
using Graph.Control.TextEdit;
using Graph.Control.Texture;
using Graph.Core;
using Graph.Core.Helper;
using Graph.Core.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graph {

	public class MainGame : Game {
		private readonly GameEngine _gameEngine;
		private GameManager GameManager { get; set; }

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
			//var container = new Container(GameManager){AutoSize = true};
			////container.Position = new Vector2(50, 50);
			//container.BackgroundTexture = new ColorTexture(GameManager, Color.Black);
			var btn = new Button(GameManager)
			{
				Text = "Azazazaz",
				Margin = new Margin(5, 15, 15, 15),
				BackgroundTexture = new ColorTexture(GameManager, Color.Blue),
				AutoSize = true,
				Border = new Border() { Width = 5, Color = Color.Aqua },
				Position = new Vector2(50, 100),
				ItemMargin = Margin.Zero,
				TextColor = Color.Yellow
			};
			btn.Click += (button, args) => { btn.Text += "A"; };
			_gameEngine.Add(btn);
			//container.Add(btn);
			//container.Add(new TextEdit(GameManager) { Text = "Azazazazaz"});
			//Line line = new Line(GameManager){};
			//line.Start = new Vector2(50,100);
			//_gameEngine.Add(line);
			_gameEngine.Add(new Cursor(GameManager));
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
