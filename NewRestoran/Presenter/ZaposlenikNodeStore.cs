using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public class ZaposlenikNodeStore : NodeStore{
	
		public ZaposlenikNodeStore() : base(typeof(ZaposlenikNode)){
		}
	

		public void Add(Zaposlenik z) {
			this.AddNode(new ZaposlenikNode(z));
		}

		public void AddList(List<Zaposlenik> zaposlenici) {
			zaposlenici.ForEach(z => this.Add(z));
		}


	}
}
