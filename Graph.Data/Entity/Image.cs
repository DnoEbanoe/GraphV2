using System.ComponentModel.DataAnnotations.Schema;

namespace Graph.Data.Entity {
	[Table("Image")]
	public class Image : BaseDbItem {
		public byte[] File { get; set; }
	}
}
