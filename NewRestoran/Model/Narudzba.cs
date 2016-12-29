using System;
using System.Collections.Generic;

namespace NewRestoran {

	public class Narudzba {

		private int ID;
		private string broj;
		private DateTime datum;
		public enum OznakaNarudzbe { Potvrdeno, Nepotvrdeno }
		public OznakaNarudzbe Oznaka { get; set; }
		public Stol StolNarudzbe { get; set; }

		public List<NarudzbaStavka> Stavke { get; set; }

		public string Broj {
			get {return broj;
			}
			set {
				if(value.Equals("")) throw new ArgumentException("Broj je obavezan.", nameof(broj));
				broj = value;
			}
		}
		public DateTime Datum {
			get {return datum;}
			set {
				if(datum.Equals("")) throw new ArgumentException("Datum je obavezan.");
				datum = value;
			}
		}

		public Narudzba (string broj, DateTime datum, OznakaNarudzbe oznaka, Stol stol=null) {
			Broj = broj;
			Datum = datum;
			Oznaka = oznaka;
			StolNarudzbe = stol;
			Stavke = new List<NarudzbaStavka> ();
		}

		public Narudzba (int id, string broj, DateTime datum, OznakaNarudzbe oznaka, Stol stol) : this(broj, datum, oznaka, stol){
			ID = id;
		}

		public float Ukupno() {
			float ukupno = 0;
			Stavke.ForEach (s => ukupno += s.Kolicina * s.ArtiklStavke.Cijena);
			return ukupno;
		}

	}
}
