using System.Collections.Generic;

namespace Graph.Math {
	public class Dijstra {
		public double[] Dist { get; set; }
		private List<int> Queue { get; } = new List<int>();

		public Dijstra(double[,] g, int s) {
			Initial(s);
			while (Queue.Count > 0) {
				int u = GetNextVertex();
				for (int i = 0; i < s; i++) {
					if (g[u, i] > 0) {
						if (Dist[i] > Dist[u] + g[u, i]) {
							Dist[i] = Dist[u] + g[u, i];
						}
					}
				}
			}
		}

		private int GetNextVertex() {
			var min = double.PositiveInfinity;
			int vertex = -1;
			foreach (int val in Queue) {
				if (Dist[val] <= min) {
					min = Dist[val];
					vertex = val;
				}
			}
			Queue.Remove(vertex);
			return vertex;
		}

		private void Initial(int len) {
			Dist = new double[len];
			for (int i = 0; i < len; i++) {
				Dist[i] = double.PositiveInfinity;
				Queue.Add(i);
			}
			Dist[0] = 0;
		}
	}
}

