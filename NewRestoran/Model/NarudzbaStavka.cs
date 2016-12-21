using System;
namespace NewRestoran {
	
	public class NarudzbaStavka {

		public Artikl ArtiklNarudzbe;
		public int Kolicina { get; set; }
		
		public NarudzbaStavka (Artikl a, int kolicina) {
			if (a.Equals (null)) throw new ArgumentException("Nepostojeći artikl.", nameof(a));
			if (a.Equals (null)) throw new ArgumentException ("Količina mora biti veća od 0.",  nameof(kolicina));

			ArtiklNarudzbe = a;
			Kolicina = kolicina;
		}

	}
}
