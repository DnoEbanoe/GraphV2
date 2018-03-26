using System.IO;

namespace Graph.Core.Provider {

	public interface IContentProvider {
		Stream Get(string name);
	}
}
