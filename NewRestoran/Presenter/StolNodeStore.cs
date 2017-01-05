using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public class StolNodeStore : NodeStore{
	
		public StolNodeStore() : base(typeof(StolNode)){
			DBStol.GetStolove().ForEach(s => this.Add(s));
		}

		public void Add(Stol s) {
			this.AddNode(new StolNode(s));
		}

		public void AddList(List<Stol> stolovi) {
			stolovi.ForEach(s => this.Add(s));
		}

		public void DodajStol(string oznaka, int brojStolica) {
			Stol s = new Stol(oznaka, brojStolica);
			StoloviPresenter.CheckUniqueOznaka(s, oznaka);
			this.Add(s);
			StoloviPresenter.Add(s);
		}

		public void UpdateStol(StolNode sn, string oznaka, int brojStolica) {
			StoloviPresenter.CheckUniqueOznaka(sn.stol, oznaka);
			StoloviPresenter.Update(sn.Oznaka, oznaka, brojStolica);
			sn.Oznaka = oznaka;
			sn.BrojStolica = brojStolica.ToString();
		}

		public void IzbrisiStol(StolNode sn) {
			this.RemoveNode(sn);
			StoloviPresenter.Delete(sn.stol);
		}


	}
}
