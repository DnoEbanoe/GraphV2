using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Core.Provider {

	public class TextureContentProvider : IContentProvider {
		private static GraphDataContext DbContext { get; set; } = new GraphDataContext();

		public Stream Get(string name) {
			return new MemoryStream(DbContext.Images.First(image => image.Name == name).File);
		}
	}
}
