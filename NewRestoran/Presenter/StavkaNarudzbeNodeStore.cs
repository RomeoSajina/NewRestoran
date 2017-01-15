using System;
using Gtk;
using System.Collections.Generic;

namespace NewRestoran {

	public class StavkaNarudzbeNodeStore : NodeStore{

		public StavkaNarudzbeNodeStore() : base(typeof(StavkaNarudzbeNode)){}

		public void Add(StavkaNarudzbe ns, string oznakaStola) {
			this.AddNode(new StavkaNarudzbeNode(ns, oznakaStola));
		}

		public void AddList(List<StavkaNarudzbe> stavkeNarudzbe, string oznakaStola) {
			stavkeNarudzbe.ForEach (ns => this.Add(ns, oznakaStola));
		}


	}
}
