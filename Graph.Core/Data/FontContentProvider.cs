using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Core.Data {

	public class FontContentProvider : IContentProvider<SpriteFont> {
		private static GraphDataContext DbContext { get; set; } = new GraphDataContext();


		public Stream Get(string name) {
			return new MemoryStream(DbContext.Fonts.First(font => font.Name == name).File);
		}
	}

}
