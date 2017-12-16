using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Control.Button
{
	public interface IButton: IControl
	{
		event Action<IButton, ButtonEventArgs> Click;
		string Test { get; set; }
	}
}
