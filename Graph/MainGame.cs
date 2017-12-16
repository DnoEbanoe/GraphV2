using Graph.Core;
using Graph.Core.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graph
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MainGame : Game
	{
		private GameEngine GameEngine;
		private GameManager GameManager { get; set; }

		public MainGame() {
			GameManager = new GameManager {
				GraphicsDeviceManager = new GraphicsDeviceManager(this)
			};
			GameManager.ContentManager = new GraphContentManager(Services);
			GameManager.FonsManager = new FontManager(GameManager.ContentManager);
			GameEngine = new GameEngine(GameManager);
			Content.RootDirectory = "Content";
		}

		protected override void LoadContent()
		{
			GameManager.spriteBatch = new SpriteBatch(GraphicsDevice);
			var font = GameManager.FonsManager.Get("Graph.Core.Data.FontContentProvider:test");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			GameEngine.Update(gameTime);
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			GameEngine.Drow(gameTime);

			base.Draw(gameTime);
		}
	}
}
