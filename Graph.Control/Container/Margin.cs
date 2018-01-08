using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Graph.Control.Container {

	public class Margin {
		public int Left { get; set; }
		public int Top { get; set; }
		public int Right { get; set; }
		public int Bottom { get; set; }
		public static Margin Zero {
			get { return new Margin(0, 0, 0, 0); }
		}

		public Margin(int margin) : this(margin, margin, margin, margin) { }

		public Margin(int left, int top, int right, int bottom) {
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
	}
}