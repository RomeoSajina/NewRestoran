using System;
using Gtk;
using System.Collections.Generic;

namespace NewRestoran {

	public class NarudzbaStavkaNodeStore : NodeStore{

		public NarudzbaStavkaNodeStore() : base(typeof(NarudzbaStavkaNode)){
		}
	
		public void Add(NarudzbaStavka ns, string oznakaStola) {
			this.AddNode(new NarudzbaStavkaNode (ns, oznakaStola));
		}

		public void AddList(List<NarudzbaStavka> stavkeNarudzbe, string oznakaStola) {
			stavkeNarudzbe.ForEach (ns => this.AddNode (new NarudzbaStavkaNode (ns, oznakaStola)));
		}
	}
}
