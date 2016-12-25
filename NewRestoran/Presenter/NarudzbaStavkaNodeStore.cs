using System;
using Gtk;
using System.Collections.Generic;

namespace NewRestoran {

	public class NarudzbaStavkaNodeStore : NodeStore{

		public NarudzbaStavkaNodeStore() : base(typeof(NarudzbaStavkaNode)){
		}
	
		public NarudzbaStavkaNode Add(NarudzbaStavka ns, string oznakaStola) {
			NarudzbaStavkaNode nsn = new NarudzbaStavkaNode(ns, oznakaStola);
			this.AddNode(nsn);
			return nsn;
		}

		public void AddList(List<NarudzbaStavka> stavkeNarudzbe, string oznakaStola) {
			stavkeNarudzbe.ForEach (ns => this.AddNode (new NarudzbaStavkaNode (ns, oznakaStola)));
		}


	}
}
