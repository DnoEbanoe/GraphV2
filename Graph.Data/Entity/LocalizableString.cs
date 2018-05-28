using System.ComponentModel.DataAnnotations.Schema;

namespace Graph.Data.Entity {
	[Table("LocalizableString")]
	public class LocalizableString : BaseDbItem {
		public string Value { get; set; }
		public Culture Culture { get; set; }
	}
}
