using Microsoft.Xna.Framework;

namespace Graph.Core {

	public interface IGameObject {
		Vector2 Position { get; set; }
		Vector2 Size { get; set; }
		GameManager GameManager { get; set; }
		void Drow(GameTime gameTime, DrowOptions options);
		void Update(GameTime gameTime, UpdateOptions options);
	}
}