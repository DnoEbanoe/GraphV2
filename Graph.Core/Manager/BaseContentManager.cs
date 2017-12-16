using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Core.Manager
{

	public abstract class BaseContentManager<T> :IContentManager<T>
	{
		protected Dictionary<string, T> Items { get; set; }

		protected BaseContentManager() {
			 InitializeItems();
		}
		public void Dispose() {
			Items.Clear();
		}

		public virtual void InitializeItems() {
			Items = new Dictionary<string, T>();
		}

		public virtual void Add(string name, T item) {
			Items.Add(name, item);
		}

		public virtual T Get(string name) {
			return Items[name];
		}

		public virtual Task<T> GetAsync(string name) {
			return Task.Run(() => {
				return Items[name];
			});
		}
	}
}
