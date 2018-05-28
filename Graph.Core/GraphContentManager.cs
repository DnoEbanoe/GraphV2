using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Graph.Core.Provider;
using Microsoft.Xna.Framework.Content;

namespace Graph.Core {

	public class GraphContentManager : ContentManager {
		public Dictionary<string, IContentProvider<Stream>> Providers { get; }

		public GraphContentManager(IServiceProvider serviceProvider, Dictionary<string, IContentProvider<Stream>> providers) : base(serviceProvider) {
			Providers = providers;
		}

		protected override Stream OpenStream(string assetName) {
			if (assetName.Contains(":")) {
				var config = assetName.Split(':');
				if (config.Length != 2) {
					throw new FormatException(assetName);
				}
				var providerName = config[0];
				var textureName = config[1];
				var provider = Providers[providerName];
				var stream = provider.Get(textureName);
				return stream;
			}

			return base.OpenStream(assetName);
		}
	}
}
