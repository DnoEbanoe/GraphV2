using System.IO;
using Graph.Data;

namespace Graph.Core.Provider {

	public class FontContentProvider : IContentProvider {
		private IGraphData Data { get; set; }

		public FontContentProvider(IGraphData data) {
			this.Data = data;
		}

		public Stream Get(string name) {
			return new MemoryStream(Data.GetFont(name).File);
		}
	}
}
