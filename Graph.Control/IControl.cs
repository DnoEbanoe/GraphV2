using System.Collections.Generic;
using Graph.Core;

namespace Graph.Control {
	public interface IControl : IGameObject {
		List<string> Tags { get; set; }
	}
}