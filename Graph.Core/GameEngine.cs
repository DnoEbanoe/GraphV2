using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				gameObject.Update(gameTime);
			}
		}

		public void Drow(GameTime gameTime) {
			foreach (var gameObject in GameObjects) {
				gameObject.Drow(gameTime);
			}
		}
	}
}
