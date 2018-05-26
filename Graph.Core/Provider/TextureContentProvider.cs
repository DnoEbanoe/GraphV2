using System.IO;
using Graph.Data;

namespace Graph.Core.Provider {

	public class TextureContentProvider : IContentProvider {
		public IGraphData Data { get; }

		public TextureContentProvider(IGraphData data) {
			Data = data;
		}

		public Stream Get(string name) {
			return new MemoryStream(Data.GetImage(name).File);
		}
	}
}
