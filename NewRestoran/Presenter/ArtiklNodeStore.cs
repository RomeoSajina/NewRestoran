using System;
using Gdk;
using Gtk;
using System.Collections.Generic;

namespace NewRestoran {
	public class ArtiklNodeStore : Gtk.NodeStore{

		public static ListStore dropdownOznakaListStore = new ListStore (typeof (Pixbuf), typeof (string));

		public ArtiklNodeStore () : base(typeof(ArtiklNode)) {
			dropdownOznakaListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Hrana.png").ScaleSimple (20, 20, InterpType.Bilinear), "Hrana");
			dropdownOznakaListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Pice.png").ScaleSimple (20, 20, InterpType.Bilinear), "Piće");
			dropdownOznakaListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Ostalo.png").ScaleSimple (20, 20, InterpType.Bilinear), "Ostalo");
		}

		public void Add (Artikl a) {
			this.AddNode (new ArtiklNode(a));
		}

		public void AddList(List<Artikl> artikli) {
			artikli.ForEach (a => this.AddNode (new ArtiklNode(a)));
		}
	}
}
