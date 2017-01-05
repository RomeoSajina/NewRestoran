using System;
using Gdk;
using Gtk;
using System.Collections.Generic;

namespace NewRestoran {
	public class ArtiklNodeStore : NodeStore {

		public ArtiklNodeStore() : base(typeof(ArtiklNode)) {
		}

		public void Add(Artikl a) {
			this.AddNode(new ArtiklNode(a));
		}

		public void AddList(List<Artikl> artikli) {
			artikli.ForEach(a => this.Add(a));
		}

		public void IzbrisiArtikl(ArtiklNode a) {
			if(a != null) { 
				this.RemoveNode(a);
				ArtikliPresenter.DeleteArtikl(a.Sifra);
			}

		}

		public void DodajArtikl(string sifra, string naziv, string duziNaziv, string sastav, float cijena, int index) {
			Artikl art = new Artikl(sifra, naziv, duziNaziv, cijena, sastav, Artikl.GetOznaka(index));
			ArtikliPresenter.CheckUniqueSifra(art, sifra);
			this.Add(art);
			ArtikliPresenter.AddArtikl(art);
		}

		public void UpdateArtikl(ArtiklNode art,string sifra, string naziv, string duziNaziv, string sastav, float cijena, int index) {
			ArtikliPresenter.CheckUniqueSifra(art.artikl, sifra);
			string oldSifra = art.Sifra;
			art.Sifra = sifra;
			art.Naziv = naziv;
			art.DuziNaziv = duziNaziv;
			art.Sastav = sastav;
			art.Cijena = cijena.ToString();
			art.Oznaka = Artikl.GetOznaka(index);

			ArtikliPresenter.UpdateArtikl(oldSifra, art);
		}
	}
}
