using System.IO;
using System.Linq;
using Graph.Data;

namespace Graph.Core.Provider {

	public class TextureContentProvider : IContentProvider {
		private static GraphDataContext DbContext { get; set; } = new GraphDataContext();

		public Stream Get(string name) {
			return new MemoryStream(DbContext.Images.First(image => image.Name == name).File);
		}
	}
}
