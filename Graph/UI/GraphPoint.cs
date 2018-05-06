using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Control.Button;
using Graph.Core;

namespace Graph.UI
{
	internal class GraphPoint: Button
	{
		private int _number;

		public int Number {
			get => _number;
			set {
				_number = value;
				Text = value.ToString();
			}
		}

		public GraphPoint(GameManager manager) : base(manager) {
		}
	}
}
