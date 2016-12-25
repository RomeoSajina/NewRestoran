using System;
using Gdk;
using Gtk;
using System.Collections.Generic;

namespace NewRestoran {
	public class ArtiklNodeStore : NodeStore{

		public ArtiklNodeStore () : base(typeof(ArtiklNode)) {
		}

		public void Add (Artikl a) {
			this.AddNode (new ArtiklNode(a));
			ArtikliPresenter.AddArtikl(a);
		}

		public void AddList(List<Artikl> artikli) {
			artikli.ForEach (a => this.Add(a));
		}
	}
}
