using System;
using System.IO;
using System.Reflection;
using Graph.Core.Provider;
using Microsoft.Xna.Framework.Content;

namespace Graph.Core {

	public class GraphContentManager : ContentManager {
		public GraphContentManager(IServiceProvider serviceProvider) : base(serviceProvider) {
		}

		protected override Stream OpenStream(string assetName) {
			if (assetName.Contains(":")) {
				var config = assetName.Split(':');
				if (config.Length != 2) {
					throw new FormatException(assetName);
				}
				var providerName = config[0];
				var textureName = config[1];
				var provider = ProviderFactory.Create(providerName);
				var stream = provider.Get(textureName);
				return stream;
			}

			return base.OpenStream(assetName);
		}
	}
}
