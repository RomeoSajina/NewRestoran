using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public class NarudzbeNode : TreeNode{

		public NarudzbaStavkaNodeStore stavkeNarudzbeNodeStore = new NarudzbaStavkaNodeStore();
		public Narudzba narudzba { get; }

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
			Ukupno = n.Ukupno().ToString("C");

			if (n.StolNarudzbe != null)
				OznakaStola = n.StolNarudzbe.Oznaka;
			else OznakaStola = "-";
			narudzba = n;

			stavkeNarudzbeNodeStore.AddList(n.Stavke, OznakaStola);
		}

		public void Update(int stol) {
			narudzba.StolNarudzbe = StoloviPresenter.stoloviList[stol];
			OznakaStola = narudzba.StolNarudzbe.Oznaka;

			foreach(NarudzbaStavkaNode ns in stavkeNarudzbeNodeStore)
				ns.OznakaStola = narudzba.StolNarudzbe.Oznaka;
			
			DBNarudzba.UpdateNarudzba(narudzba);
		}

		private void UpdateUkupno() {
			Ukupno = narudzba.Ukupno().ToString("C");
			this.OnChanged();
		}

		public void DodajStavku(NarudzbaStavka ns) {
			narudzba.AddStavka(ns);//CheckUniqueArtikl u proceduri
			stavkeNarudzbeNodeStore.Add(ns, OznakaStola);
			UpdateUkupno();

			DBStavkeNarudzbe.SaveStavka(narudzba, ref ns);
			MainWindow.stavkeChanged();
		}

		public void DodajStavku(string sifra, int kolicina, int status) {
			DodajStavku(new NarudzbaStavka(ArtikliPresenter.GetArtikl(sifra), kolicina, NarudzbaStavka.GetStatus(status)));
		}

		public void UpdateStavku(NarudzbaStavkaNode ns, string sifra, int kolicina, int status) {
			narudzba.CheckUniqueArtikl(ns.stavka, sifra);
			ns.Sifra = sifra;
			ns.Kolicina = kolicina.ToString();
			ns.Status = NarudzbaStavka.GetStatus(status);
			UpdateUkupno();

			DBStavkeNarudzbe.UpdateStavka(ns.stavka);
			MainWindow.stavkeChanged();

		}

		public void IzbrisiStavku(NarudzbaStavkaNode ns) {
			stavkeNarudzbeNodeStore.RemoveNode(ns);
			narudzba.Stavke.Remove(ns.stavka);
			UpdateUkupno();

			DBStavkeNarudzbe.DeleteStavka(ns.stavka);
			MainWindow.stavkeChanged();
		}

		public void Zakljuci() {
			narudzba.Oznaka = Narudzba.OznakaPotvrde.Potvrdeno;
			DBNarudzba.UpdateNarudzba(narudzba);

			stavkeNarudzbeNodeStore.Clear();
			MainWindow.stavkeChanged();
		}

		public bool HasStavke() { 
			if(narudzba.Stavke.Count > 0) return true;
			return false;
		}

	}
}
