using Microsoft.Xna.Framework;

namespace Graph.Core.Helper {
	public static class ColliderHelper {
		public static bool Collide(this Rectangle rectangle1, Rectangle rectangle2) {
			Rectangle goodSprite1 = new Rectangle(rectangle1.X,
				rectangle1.Y, rectangle1.Width, rectangle1.Height);
			Rectangle goodSprite2 = new Rectangle(rectangle2.X,
				rectangle2.Y, rectangle2.Width, rectangle2.Height);

			return goodSprite1.Intersects(goodSprite2);
		}

		public static Rectangle GetRectangle(Vector2 position, Vector2 size) {
			return new Rectangle((int) position.X, (int) position.Y, (int) size.X, (int) size.Y);
		}

		public static Rectangle GetRectangle(this IGameObject gameObject, int indent = 0) {
			return new Rectangle((int) gameObject.Position.X - indent, (int) gameObject.Position.Y - indent,
				(int) gameObject.Size.X + indent, (int) gameObject.Size.Y + indent);
		}
	}
}
