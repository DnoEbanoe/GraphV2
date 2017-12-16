using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Graph.Core.Data
{

	public interface IContentProvider<T> {
		Stream Get(string name);
	}
}
