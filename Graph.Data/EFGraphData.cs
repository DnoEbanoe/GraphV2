using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Entity;

namespace Graph.Data {
	public class EFGraphData: IGraphData
	{
		protected string CultureName { get; }
		public GraphDataContext Context { get; set; } = new GraphDataContext();

		public EFGraphData(string cultureName) {
			CultureName = cultureName;
		}
		public LocalizableString GetLocalizableString(string name) {
			return Context.Strings.First(str => str.Name == name && str.Culture.Name == CultureName);
		}

		public Font GetFont(string name) {
			return Context.Fonts.First(font => font.Name == name && font.Culture.Name == CultureName);
		}

		public Image GetImage(string name) {
			return Context.Images.First(image => image.Name == name);
		}
	}
}
