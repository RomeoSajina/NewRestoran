using System;
namespace NewRestoran {
	
	public class NarudzbaStavka {

		public Artikl ArtiklNarudzbe { get; set; }
		public int Kolicina { get; set; }
		public enum StatusStavke { NaCekanju, UObradi, Gotovo }
		public StatusStavke Status { get; set; }
		
		public NarudzbaStavka (Artikl a, int kolicina, StatusStavke status) {
			if (a.Equals (null)) throw new ArgumentException("Nepostojeći artikl.", nameof(a));
			if (a.Equals (null)) throw new ArgumentException ("Količina mora biti veća od 0.",  nameof(kolicina));

			ArtiklNarudzbe = a;
			Kolicina = kolicina;
			Status = status;
		}

	}
}
