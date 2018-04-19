using System;
using System.ComponentModel.DataAnnotations;

namespace Graph.Data.Entity {
	public interface IDbItem {
		[Key]
		Guid Id { get; set; }
		string Name { get; set; }
	}
}
