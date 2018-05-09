using System.Collections.Generic;

namespace Graph.Math {
	public class Dijstra {
		private double[] Distance { get; set; }
		private List<int> Queue { get; } = new List<int>();

		public IEnumerable<Distance> GetDistance(double[,] matrix, int elemCount) {
			Distance[] distances = new Distance[elemCount];
			distances[0] = new Distance();
			Initial(elemCount);
			while (Queue.Count > 0) {
				int nextVector = GetNextVertex();
				for (int i = 0; i < elemCount; i++) {
					var matrixIValue = matrix[nextVector, i];
					if (matrixIValue > 0) {
						var distanceValue = Distance[nextVector];
						if (Distance[i] > distanceValue + matrixIValue) {
							if (distances[i] == null) {
								distances[i] = new Distance();
							}
							distances[i].Path.AddRange(distances[nextVector].Path);
							distances[i].Path.Add(i);
							distances[i].Value = distanceValue + matrixIValue;
							Distance[i] = distanceValue + matrixIValue;
						}
					}
				}
			}
			return distances;
		}

		private int GetNextVertex() {
			var min = double.PositiveInfinity;
			int vertex = -1;
			foreach (int val in Queue) {
				if (Distance[val] <= min) {
					min = Distance[val];
					vertex = val;
				}
			}
			Queue.Remove(vertex);
			return vertex;
		}

		private void Initial(int len) {
			Distance = new double[len];
			for (int i = 0; i < len; i++) {
				Distance[i] = double.PositiveInfinity;
				Queue.Add(i);
			}
			Distance[0] = 0;
		}
	}

	public class Distance {
		public List<int> Path { get; set; } = new List<int>();
		public double Value { get; set; }
	}
}

