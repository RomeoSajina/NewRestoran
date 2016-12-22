using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {
	
	public class NarudzbeNodeStore : NodeStore{
	
		public NarudzbeNodeStore() : base(typeof(NarudzbeNode)) {
		}

		public void Add(Narudzba n) {
			this.AddNode (new NarudzbeNode(n));
		}

		public void AddList(List<Narudzba> narudzbe) {
			narudzbe.ForEach (n => this.AddNode (new NarudzbeNode(n)));
		}

	}
}
