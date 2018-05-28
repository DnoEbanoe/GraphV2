using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Entity;

namespace Graph.Data {

	public class GraphDataContext : DbContext {
		public DbSet<Culture> Cultures { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Font> Fonts { get; set; }
		public DbSet<LocalizableString> Strings { get; set; }

		public GraphDataContext() : base("SqliteConnection") {

		}
	}
}
