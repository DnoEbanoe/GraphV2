using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.Entity {

	public class Font {
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public byte[] File { get; set; }
	}

}
