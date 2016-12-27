using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public class NarudzbeNode : TreeNode{

		public NarudzbaStavkaNodeStore stavkeNarudzbeNodeStore = new NarudzbaStavkaNodeStore();
		private Narudzba narudzba;

		[Gtk.TreeNodeValue (Column = 0)]
		public string Broj;

		[Gtk.TreeNodeValue (Column = 1)]
		public string Datum;

		[Gtk.TreeNodeValue (Column = 2)]
		public string OznakaStola;

		[Gtk.TreeNodeValue (Column = 3)]
		public string Ukupno;

		public NarudzbeNode(Narudzba n) {
			Broj = n.Broj;
			Datum = n.Datum.ToString("g");
			Ukupno = "0,00 kn";

			if (n.StolNarudzbe != null)
				OznakaStola = n.StolNarudzbe.Oznaka;
			else OznakaStola = "-";
			narudzba = n;
		}

		public void Update(string oznakaStola) {
			narudzba.StolNarudzbe = new Stol(oznakaStola, 4);//TODO Referenca umjesto novog objekta
			OznakaStola = oznakaStola;
		}

		private void UpdateUkupno() {
			Ukupno = narudzba.Ukupno().ToString("C");
			this.OnChanged();
		}

		public void DodajStavku(NarudzbaStavka ns) {
			narudzba.Stavke.Add(ns);
			NarudzbaStavkaNode nsn = stavkeNarudzbeNodeStore.Add(ns, OznakaStola);
			UpdateUkupno();
			MainWindow.statusStore.AddNode(nsn);
			MainWindow.stavkeChanged();

			//Insert u db i vrati ID
		}

		public void DodajStavku(string sifra, int kolicina, int status) {
			NarudzbaStavka ns = new NarudzbaStavka(ArtikliPresenter.GetArtikl(sifra), kolicina, NarudzbaStavka.GetStatus(status));
			narudzba.Stavke.Add(ns);
			NarudzbaStavkaNode nsn = stavkeNarudzbeNodeStore.Add(ns, OznakaStola);
			UpdateUkupno();
			MainWindow.statusStore.AddNode(nsn);
			MainWindow.stavkeChanged();

			//Insert u db i vrati ID
		}

		public void UpdateStavku(NarudzbaStavkaNode ns, string sifra, int kolicina, int status) {
			ns.Sifra = sifra;
			ns.Kolicina = kolicina.ToString();
			ns.SetStatus(NarudzbaStavka.GetStatus(status));
			UpdateUkupno();
			MainWindow.stavkeChanged();
	
			//Update to db
		}

		public void IzbrisiStavku(NarudzbaStavkaNode ns) {
			stavkeNarudzbeNodeStore.RemoveNode(ns);
			UpdateUkupno();
			MainWindow.statusStore.RemoveNode(ns);
			MainWindow.stavkeChanged();
		
			//Delete from db
		}

		public void Zakljuci() {
			foreach(NarudzbaStavkaNode ns in stavkeNarudzbeNodeStore) 
				MainWindow.statusStore.RemoveNode(ns);

			stavkeNarudzbeNodeStore.Clear();
			MainWindow.stavkeChanged();
			//DB zakljuci
		}
	}
}
