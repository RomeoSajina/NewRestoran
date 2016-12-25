using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public class NarudzbeNode : TreeNode{

		public NarudzbaStavkaNodeStore stavkeNarudzbeNodeStore = new NarudzbaStavkaNodeStore();

		[Gtk.TreeNodeValue (Column = 0)]
		public string Broj;

		[Gtk.TreeNodeValue (Column = 1)]
		public string Datum;

		[Gtk.TreeNodeValue (Column = 2)]
		public string OznakaStola;

		[Gtk.TreeNodeValue (Column = 3)]
		public string Ukupno;

		private float Sveukupno;

		public NarudzbeNode(Narudzba n) {
			Broj = n.Broj;
			Datum = n.Datum.ToString("g");
			Ukupno = "0,00 kn";
			Sveukupno = 0;

			if (n.StolNarudzbe != null)
				OznakaStola = n.StolNarudzbe.Oznaka;
			else OznakaStola = "-";
		}

		private void SetUkupno(float cijena, int kolicina) { 
			Sveukupno += (cijena * kolicina);
			Ukupno = Sveukupno.ToString("C");
		}

		public void DodajStavku(NarudzbaStavka ns) {
			NarudzbaStavkaNode nsn = stavkeNarudzbeNodeStore.Add(ns, OznakaStola);
			SetUkupno(ns.ArtiklNarudzbe.Cijena, ns.Kolicina);

			MainWindow.statusStore.AddNode(nsn);
		}

		public void DodajStavku(string sifra, int kolicina, int status) {
			
			Artikl artikl = ArtikliPresenter.GetArtikl(sifra);
			if(artikl == null) throw new ArgumentException("Artikl mora biti odabran.", nameof(artikl));

			//Prvo insert u bazu pa onda vratit ID i dodati sa ID
			NarudzbaStavkaNode nsn = stavkeNarudzbeNodeStore.Add(new NarudzbaStavka(artikl, kolicina, NarudzbaStavka.GetStatus(status)), OznakaStola);
			SetUkupno(artikl.Cijena, kolicina);

			MainWindow.statusStore.AddNode(nsn);                                                  
		}

		public void UpdateStavku(NarudzbaStavkaNode ns, string sifra, int kolicina, int status) {
			Artikl a = ArtikliPresenter.GetArtikl(sifra);
			if(a != null) {
				SetUkupno(-ArtikliPresenter.GetArtikl(ns.Sifra).Cijena, kolicina);
				MainWindow.statusStore.RemoveNode(ns);

				ns.Sifra = a.Sifra;
				ns.Naziv = a.Naziv;
				ns.Kolicina = kolicina.ToString();
				ns.SetStatus(NarudzbaStavka.GetStatus(status));
				ns.Ukupno = (a.Cijena * kolicina).ToString("C");

				SetUkupno(a.Cijena, kolicina);
				MainWindow.statusStore.AddNode(ns);
				//Update to db

			}

		}

		public void IzbrisiStavku(NarudzbaStavkaNode ns) {
			stavkeNarudzbeNodeStore.RemoveNode(ns);
			SetUkupno(-ArtikliPresenter.GetArtikl(ns.Sifra).Cijena, int.Parse(ns.Kolicina));
			MainWindow.statusStore.RemoveNode(ns);
			//Delete from db
		}

		public void Zakljuci() {
			
			//DB zakljuci
		}
	}
}
