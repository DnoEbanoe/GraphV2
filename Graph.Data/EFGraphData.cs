using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Entity;

namespace Graph.Data {
	public class EFGraphData: IGraphData
	{
		readonly GraphDataContext _context = new GraphDataContext();
		public Font GetFont(string name) {
			return _context.Fonts.First(font => font.Name == name);
		}

		public Image GetImage(string name) {
			return _context.Images.First(image => image.Name == name);
		}
	}
}
