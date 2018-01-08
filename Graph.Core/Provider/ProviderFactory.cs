using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Core.Provider {

	public static class ProviderFactory {
		static Dictionary<string, IContentProvider> providers =
			new Dictionary<string, IContentProvider> {
				{"font", new FontContentProvider()},
				{"image", new TextureContentProvider()}
			};

		public static IContentProvider Create(string name) {
			return providers[name];
		}
	}

}
