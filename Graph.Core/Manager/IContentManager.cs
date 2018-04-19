using System;
using System.Threading.Tasks;

namespace Graph.Core.Manager {
	public interface IContentManager<T> : IDisposable {
		void Add(string name, T item);
		T Get(string name);
		Task<T> GetAsync(string name);
	}
}
