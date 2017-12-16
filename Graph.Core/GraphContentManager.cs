using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Content;

namespace Graph.Core {

	public class GraphContentManager : ContentManager {
		public GraphContentManager(IServiceProvider serviceProvider) : base(serviceProvider) { }
		protected override Stream OpenStream(string assetName) {
			if (assetName.Contains(":")) {
				var config = assetName.Split(':');
				if (config.Length != 2) {
					throw new FormatException(assetName);
				}
				var methodName = "Get";
				var providerName = config[0];
				var textureName = config[1];
				Type providerType = Type.GetType(providerName);
				if (providerType == null) {
					throw new NullReferenceException(providerName);
				}
				object providerInstance = Activator.CreateInstance(providerType, null);
				MethodInfo methodInfo = providerType.GetMethod(methodName);
				if (methodInfo == null) {
					throw new NullReferenceException(methodName);
				}
				return (Stream)methodInfo.Invoke(providerInstance, new object[] { textureName });
			}
			return base.OpenStream(assetName);
		}
	}
}
