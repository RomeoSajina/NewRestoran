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

		private void UpdateUkupno() {
			Ukupno = narudzba.Ukupno().ToString("C");
			/*float u = 0;
			foreach(NarudzbaStavkaNode ns in stavkeNarudzbeNodeStore)
				u += float.Parse(ns.Ukupno,System.Globalization.NumberStyles.Any);
			
			Ukupno = u.ToString("C");*/
		}

		public void DodajStavku(NarudzbaStavka ns) {
			narudzba.Stavke.Add(ns);
			NarudzbaStavkaNode nsn = stavkeNarudzbeNodeStore.Add(ns, OznakaStola);
			UpdateUkupno();
			MainWindow.statusStore.AddNode(nsn);
			MainWindow.stavkeChanged();
			//SetUkupno(ns.ArtiklNarudzbe.Cijena, ns.Kolicina);
		}

		public void DodajStavku(string sifra, int kolicina, int status) {
			NarudzbaStavka ns = new NarudzbaStavka(ArtikliPresenter.GetArtikl(sifra), kolicina, NarudzbaStavka.GetStatus(status));
			narudzba.Stavke.Add(ns);
			NarudzbaStavkaNode nsn = stavkeNarudzbeNodeStore.Add(ns, OznakaStola);
			UpdateUkupno();
			MainWindow.statusStore.AddNode(nsn);
			MainWindow.stavkeChanged();

			//	Artikl artikl = ArtikliPresenter.GetArtikl(sifra);
			//	if(artikl == null) throw new ArgumentException("Artikl mora biti odabran.", nameof(artikl));

			//Prvo insert u bazu pa onda vratit ID i dodati sa ID
			//	SetUkupno(artikl.Cijena, kolicina);
		}

		public void UpdateStavku(NarudzbaStavkaNode ns, string sifra, int kolicina, int status) {
			ns.Sifra = sifra;
			ns.Kolicina = kolicina.ToString();
			ns.SetStatus(NarudzbaStavka.GetStatus(status));
			UpdateUkupno();
			MainWindow.stavkeChanged();
		//	Artikl a = ArtikliPresenter.GetArtikl(sifra);
		//	if(a != null) {
			//	SetUkupno(-ArtikliPresenter.GetArtikl(ns.Sifra).Cijena, int.Parse(ns.Kolicina));
			//	MainWindow.statusStore.RemoveNode(ns);
			//	ns.Sifra = a.Sifra;
			//	ns.Naziv = a.Naziv;
		//		ns.Kolicina = kolicina.ToString();
		//		ns.SetStatus(NarudzbaStavka.GetStatus(status));
		//		ns.Ukupno = (a.Cijena * kolicina).ToString("C");

				//SetUkupno(a.Cijena, kolicina);
		//		MainWindow.statusStore.AddNode(ns);
			//} 

			//Update to db
		}

		public void IzbrisiStavku(NarudzbaStavkaNode ns) {
			stavkeNarudzbeNodeStore.RemoveNode(ns);
			UpdateUkupno();
			MainWindow.statusStore.RemoveNode(ns);
			MainWindow.stavkeChanged();
			//	SetUkupno(-ArtikliPresenter.GetArtikl(ns.Sifra).Cijena, int.Parse(ns.Kolicina));

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
