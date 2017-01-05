using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public static class ArtikliPresenter {

		private static List<Artikl> SviArtikli = new List<Artikl>();
		private static ListStore artikliListStore = new ListStore(typeof(string));

		static ArtikliPresenter(){
			DBArtikl.GetArtikle().ForEach(a => {
				SviArtikli.Add(a);
				artikliListStore.AppendValues(a.Sifra);
			});
		}

		public static List<Artikl> Artikli {
			get { return SviArtikli; }
		}

		public static ListStore ArtikliListStore {
			get {return artikliListStore;}
		}


		public static void AddArtikl(Artikl a) {
			SviArtikli.Add(a);
			artikliListStore.AppendValues(a.Sifra);
			DBArtikl.SaveArtikl(ref a);
		}

		public static void DeleteArtikl(Artikl a) {
			TreeIter iter;
			artikliListStore.IterNthChild(out iter, GetIndex(a.Sifra));
			artikliListStore.Remove(ref iter);

			SviArtikli.Remove(a);
			DBArtikl.DeleteArtikl(a);
		}

		public static void DeleteArtikl(string sifra) {
			DeleteArtikl(GetArtikl(sifra)); //Poziva prethodnu funkciju
		}

		public static void UpdateArtikl(string oldSifra, ArtiklNode an) {
			int index = GetIndex(oldSifra);
			SviArtikli[index].Sifra = an.Sifra;
			SviArtikli[index].Naziv = an.Naziv;
			SviArtikli[index].DuziNaziv = an.DuziNaziv;
			SviArtikli[index].Sastav = an.Sastav;
			SviArtikli[index].Cijena = float.Parse(an.Cijena, System.Globalization.NumberStyles.Any);
			SviArtikli[index].Oznaka = an.Oznaka;

			TreeIter iter;
			artikliListStore.IterNthChild(out iter, index);
			artikliListStore.SetValue(iter, 0, an.Sifra);

			DBArtikl.UpdateArtikl(an.artikl);
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

		public static Artikl GetArtikl(long id) {
			return SviArtikli.Find(a => a.ID == id);
		}

		public static void CheckUniqueSifra(Artikl art, string NewSifra) {
			if(SviArtikli.Find(a => a.Sifra == NewSifra && a != art) != null)
				throw new ArgumentException("Šifra artikla mora biti jedinstvena.", nameof(NewSifra));
		}
	}
}
