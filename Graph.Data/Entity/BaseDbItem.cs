using System;
using System.ComponentModel.DataAnnotations;

namespace Graph.Data.Entity {
	public abstract class BaseDbItem : IDbItem {
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
