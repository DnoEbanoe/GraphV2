using Graph.Data.Entity;

namespace Graph.Data
{
	public interface IGraphData {
		Font GetFont(string name);

		Image GetImage(string name);
	}
}
