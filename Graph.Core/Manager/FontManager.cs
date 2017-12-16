using Graph.Core.Data;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Graph.Core.Manager
{

	public class FontManager: BaseContentManager<SpriteFont>
	{
		private readonly ContentManager _contentManager;

		public FontManager(ContentManager contentManager) {
			_contentManager = contentManager;
		}

		public override SpriteFont Get(string name) {
			if (Items.ContainsKey(name)) {
				return Items[name];
			}
			return _contentManager.Load<SpriteFont>(name);
		}
	}
}
