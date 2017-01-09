using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {
	
	public class NarudzbeNodeStore : NodeStore{
	
		public NarudzbeNodeStore(bool loadFromDB) : base(typeof(NarudzbeNode)) {
			if(loadFromDB)
				this.AddList(DBNarudzba.GetNarudzbe());
		}

		public void Add(Narudzba n) {
			this.AddNode (new NarudzbeNode(n));
		}

		public void AddList(List<Narudzba> narudzbe) {
			narudzbe.ForEach (n => this.AddNode (new NarudzbeNode(n)));
		}

		public void DodajNarudzbu(string oznakaStola) {
			Narudzba n = new Narudzba("0", DateTime.Now, Narudzba.OznakaPotvrde.Nepotvrdeno, StoloviPresenter.stoloviList.Find(s => s.Oznaka == oznakaStola));
 			DBNarudzba.SaveNarudzba(ref n);
			this.Add(n);
		}


		public void IzbrisiNarudzbu(NarudzbeNode n) {
			this.RemoveNode (n);
			DBNarudzba.DeleteNarudzba(n.narudzba);
			MainWindow.stavkeChanged();
		}

	}
}
