using System;
namespace NewRestoran {
	
	public class NarudzbaStavka {

		public int Id { get; set; }
		public Artikl ArtiklNarudzbe { get; set; }
		public int Kolicina { get; set; }
		public enum StatusStavke { NaCekanju, UObradi, Gotovo, Dostavljeno }
		public StatusStavke Status { get; set; }
		
		public NarudzbaStavka (Artikl artikl, int kolicina, StatusStavke status) {
			if (artikl.Equals (null)) throw new ArgumentException("Nepostojeći artikl.", nameof(artikl));
			if (kolicina.Equals (0)) throw new ArgumentException ("Količina mora biti veća od 0.",  nameof(kolicina));

			ArtiklNarudzbe = artikl;
			Kolicina = kolicina;
			Status = status;
		}

		public NarudzbaStavka(int id, Artikl a, int kolicina, StatusStavke status) : this(a, kolicina, status){
			Id = id;
		}

		public static StatusStavke GetStatus(int index) {
			StatusStavke s;
			switch(index) {
				case 0: s = NarudzbaStavka.StatusStavke.NaCekanju; break;
				case 1: s = NarudzbaStavka.StatusStavke.UObradi; break;
				case 2: s = NarudzbaStavka.StatusStavke.Gotovo; break;
				case 3: s = NarudzbaStavka.StatusStavke.Dostavljeno; break;
				default: s = NarudzbaStavka.StatusStavke.NaCekanju; break;
			}
			return s;
		}
	}
}
