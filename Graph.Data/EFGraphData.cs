using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Entity;

namespace Graph.Data {
	public class EFGraphData: IGraphData
	{
		public GraphDataContext Context { get; set; } = new GraphDataContext();
		public Font GetFont(string name) {
			return Context.Fonts.First(font => font.Name == name);
		}

		public Image GetImage(string name) {
			return Context.Images.First(image => image.Name == name);
		}
	}
}
