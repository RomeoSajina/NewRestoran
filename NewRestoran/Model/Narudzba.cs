using System;
using System.Collections.Generic;

namespace NewRestoran {

	public class Narudzba {

		private int ID;
		public string Broj { get; set; }
		public DateTime Datum { get; set; }
		public enum OznakaNarudzbe { Potvrdeno, Nepotvrdeno }
		public OznakaNarudzbe Oznaka { get; set; }
		public Stol StolNarudzbe { get; set; }

		public List<NarudzbaStavka> Stavke { get; set;}

		public Narudzba (string broj, DateTime datum, OznakaNarudzbe oznaka, Stol stol=null) {
			if (broj.Equals ("") || datum.Equals ("")) 
				throw new ArgumentException ("Broj, datum su obavezni.");
			if(oznaka.Equals (null))
				throw new ArgumentException ("Došlo je do greške, pokušajte ponovno.");

			Broj = broj;
			Datum = datum;
			Oznaka = oznaka;
			StolNarudzbe = stol;
			Stavke = new List<NarudzbaStavka> ();
		}

		public Narudzba (int id, string broj, DateTime datum, OznakaNarudzbe oznaka, Stol stol) : this(broj, datum, oznaka, stol){
			ID = id;
		}

		public double Ukupno() {
			double ukupno = 0;
			Stavke.ForEach (s => ukupno += s.Kolicina * s.ArtiklNarudzbe.Cijena);
			return ukupno;
		}

	}
}
