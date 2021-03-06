﻿using Graph.Data.Entity;

namespace Graph.Data
{
	public interface IGraphData {
		LocalizableString GetLocalizableString(string name);
		Font GetFont(string name);
		Image GetImage(string name);
	}
}
