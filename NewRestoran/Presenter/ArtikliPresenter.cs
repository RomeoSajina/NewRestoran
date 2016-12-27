using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public static class ArtikliPresenter {

		private static List<Artikl> SviArtikli = new List<Artikl>();
		private static ListStore artikliListStore = new ListStore(typeof(string));

		public static ListStore ArtikliListStore {
			get {return artikliListStore;}
			set {artikliListStore = value;}
		}


		public static void AddArtikl(Artikl a) {
			SviArtikli.Add(a);
			artikliListStore.AppendValues(a.Sifra);
		}

		public static void LoadFromDB() { 
		
		}

		public static void DeleteArtikl(Artikl a) {
			SviArtikli.Remove(a);
			TreeIter iter;
			artikliListStore.GetIterFirst(out iter);
		
			while(artikliListStore.GetValue(iter, 0).ToString() != a.Sifra) 
				artikliListStore.IterNext(ref iter);

			artikliListStore.Remove(ref iter);
		}

		public static void ArtiklDetails(string sifra, int kolicina, out string naziv, out string cijena, out string ukupno) {
			Artikl art = SviArtikli.Find(a => a.Sifra == sifra);
			if(art != null) {
				naziv = art.Naziv;
				cijena = art.Cijena.ToString("C");
				ukupno = (art.Cijena * kolicina).ToString("C");
			} else {
				naziv = "";
				cijena = "";
				ukupno = "0,00 kn";
			}
		}

		public static int GetIndex(string sifra) {
			return SviArtikli.FindIndex(a => a.Sifra == sifra);
		}

		public static Artikl GetArtikl(string sifra) {
			return SviArtikli.Find(a => a.Sifra == sifra);
		}
	}
}
