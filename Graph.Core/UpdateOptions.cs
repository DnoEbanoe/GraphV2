using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Graph.Core
{
	public struct UpdateOptions
	{
		public Vector2 Position { get; set; }
		public Vector2 Size { get; set; }
		public static UpdateOptions Zero {
			get {
				return new UpdateOptions();
			}
		}

		public static UpdateOptions operator +(UpdateOptions options1, UpdateOptions options2) {
			return new UpdateOptions() {Position = options1.Position + options2.Position, Size = options1.Size + options2.Size};
		}
	}
}
