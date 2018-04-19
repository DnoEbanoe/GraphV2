﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace Graph.Core.Manager {

	public class BaseContentManager<T> : IContentManager<T> {
		protected ContentManager ContentManager { get; }
		protected Dictionary<string, T> Items { get; set; }

		public BaseContentManager(ContentManager contentManager) {
			ContentManager = contentManager;
			InitializeItems();
		}

		public virtual void InitializeItems() {
			Items = new Dictionary<string, T>();
		}

		public virtual void Add(string name, T item) {
			Items.Add(name, item);
		}

		public virtual T Get(string name) {
			if (Items.ContainsKey(name)) {
				return Items[name];
			}

			var item = ContentManager.Load<T>(name);
			Items.Add(name, item);
			return item;
		}

		public virtual Task<T> GetAsync(string name) {
			return Task.Run(() => Get(name));
		}

		public void Dispose() {
			Items.Clear();
		}
	}
}
