using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Core.Helper;
using Microsoft.Xna.Framework;

namespace Graph.Control.Helpers
{
	public static class ControlHelper
	{
		public static List<IControl> GetElements(this IEnumerable<IControl> items, string tag) {
			return items.Where(control => control.Tags.Contains(tag)).ToList();
		}

		public static List<IControl> GetElements(this IEnumerable<IControl> items, Rectangle rectangle) {
			return items.Where(control => control.GetRectangle().Collide(rectangle)).ToList();
		}

		public static List<IControl> GetElements(this IEnumerable<IControl> items, Rectangle rectangle, string tag) {
			return items.GetElements(tag).GetElements(rectangle);
		}

		public static Vector2 GetCenter(this IControl control) {
			return new Vector2(control.Position.X + control.Size.X / 2, control.Position.Y + control.Size.Y / 2);
		}
	}
}
