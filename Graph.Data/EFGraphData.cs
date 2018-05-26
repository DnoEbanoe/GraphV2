using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Entity;

namespace Graph.Data {
	public class EFGraphData: IGraphData
	{
		public IEnumerable<Font> GetFont(string name) {
			throw new NotImplementedException();
		}

		public IEnumerable<Image> GetImage(string name) {
			throw new NotImplementedException();
		}
	}
}
