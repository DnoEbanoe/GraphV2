using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Graph.Core {
	public class GameEngine {
		protected GameManager GameManager { get; }
		protected List<IGameObject> GameObjects { get; set; } = new List<IGameObject>();

		public GameEngine(GameManager gameManager) {
			GameManager = gameManager;
		}

		public void Add(IGameObject gameObject) {
			GameObjects.Add(gameObject);
		}
		public void Repove(IGameObject gameObject) {
			GameObjects.Remove(gameObject);
		}
		public void Update(GameTime gameTime) {
			foreach (var gameObject in GameObjects) {
				gameObject.Update(gameTime, UpdateOptions.Zero);
			}
		}
		public void Draw(GameTime gameTime) {
			foreach (var gameObject in GameObjects) {
				gameObject.Draw(gameTime, DrowOptions.Zero);
			}
		}
	}
}