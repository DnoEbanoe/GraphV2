using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Graph.Core {

	public interface IGameObject {
		GameManager GameManager { get; set; }
		void Drow(GameTime gameTime);
		void Update(GameTime gameTime);
	}

}
