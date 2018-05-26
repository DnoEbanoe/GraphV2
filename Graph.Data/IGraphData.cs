using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Entity;

namespace Graph.Data
{
	interface IGraphData {
		IEnumerable<Font> GetFont(string name);

		IEnumerable<Image> GetImage(string name);
	}
}
