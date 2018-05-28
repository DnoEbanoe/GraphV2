using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graph.Data.Entity {
	[Table("Font")]
	public class Font : BaseDbItem {
		public Culture Culture { get; set; }
		public byte[] File { get; set; }
	}
}
