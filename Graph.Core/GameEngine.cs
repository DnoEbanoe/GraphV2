using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Graph.Core {
	public class GameEngine {
		private GameManager GameManager { get; }
		private List<IGameObject> GameObjects { get; set; } = new List<IGameObject>();

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

		public void Drow(GameTime gameTime) {
			foreach (var gameObject in GameObjects) {
				gameObject.Drow(gameTime, DrowOptions.Zero);
			}
		}
	}
}