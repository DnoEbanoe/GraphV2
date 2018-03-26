using System;

namespace Graph.Data.Entity {
	public abstract class BaseDbItem : IDbItem {
		[System.ComponentModel.DataAnnotations.Key]
		public Guid Id { get; set; }

		public string Name { get; set; }
	}
}
