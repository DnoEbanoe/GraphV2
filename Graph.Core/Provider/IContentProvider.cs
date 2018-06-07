namespace Graph.Core.Provider {

	public interface IContentProvider<T> {
		T Get(string name);
	}
}
