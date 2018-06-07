using Graph.Data;

namespace Graph.Core.Provider {
	public class StringContentProvider : IContentProvider<string> {
		public IGraphData Data { get; }

		public StringContentProvider(IGraphData data) {
			Data = data;
		}

		public string Get(string name) {
			return Data.GetLocalizableString(name).Value;
		}
	}
}
