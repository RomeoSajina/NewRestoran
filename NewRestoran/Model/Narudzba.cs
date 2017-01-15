using System;
using System.Collections.Generic;

namespace NewRestoran {

	public class Narudzba {

		public long ID { get; set; }
		private string broj;
		private DateTime datum;
		public enum OznakaPotvrde { Potvrdeno, Nepotvrdeno }
		public OznakaPotvrde Oznaka { get; set; }
		public Stol StolNarudzbe { get; set; }

		public List<StavkaNarudzbe> Stavke { get; set; }

		public string Broj {
			get {
				return broj;
			}
			set {
				if(value.Equals("")) throw new ArgumentException("Broj je obavezan.", nameof(broj));
				broj = value;
			}
		}
		public DateTime Datum {
			get { return datum; }
			set {
				if(datum.Equals("")) throw new ArgumentException("Datum je obavezan.");
				datum = value;
			}
		}

		public Narudzba(string broj, DateTime datum, OznakaPotvrde oznaka, Stol stol = null) {
			Broj = broj;
			Datum = datum;
			Oznaka = oznaka;
			StolNarudzbe = stol;
			Stavke = new List<StavkaNarudzbe>();
		}

		public Narudzba(long id, string broj, DateTime datum, OznakaPotvrde oznaka, Stol stol = null) : this(broj, datum, oznaka, stol) {
			ID = id;
		}

		public void AddStavka(StavkaNarudzbe sn) {
			CheckUniqueArtikl(sn, sn.ArtiklStavke.Sifra);
			Stavke.Add(sn);
		}

		public float Ukupno() {
			float ukupno = 0;
			Stavke.ForEach(s => ukupno += s.Kolicina * s.ArtiklStavke.Cijena);
			return ukupno;
		}

		public void CheckUniqueArtikl(StavkaNarudzbe sn, string sifra) {
			if(Stavke.Find(s => s.ArtiklStavke.Sifra == sifra && s != sn) != null)
				 throw new ArgumentException("Stavka sa odabranim artiklom već postoji.", nameof(sifra));			
		}

		public static OznakaPotvrde OznakaFromString(string oznaka) { 
			OznakaPotvrde o;
			switch(oznaka) {
			case "Potvrdeno": o = OznakaPotvrde.Potvrdeno; break;
			case "Nepotvrdeno": o = OznakaPotvrde.Nepotvrdeno; break;
			default: o = OznakaPotvrde.Nepotvrdeno; break;
			}
			return o;
		}

	}
}
