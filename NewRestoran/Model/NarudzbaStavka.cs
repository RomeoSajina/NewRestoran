using System;
namespace NewRestoran {
	
	public class NarudzbaStavka {

		public int Id { get; set; }
		private Artikl artiklNarudzbe;
		private int kolicina;
		public enum StatusStavke { NaCekanju, UObradi, Gotovo, Dostavljeno }
		public StatusStavke Status { get; set; }

		public int Kolicina {
			get {return kolicina;}
			set {
				if(value <= 0) throw new ArgumentException("Količina mora biti veća od 0.", nameof(kolicina));
				kolicina = value;
			}
		}

		public Artikl ArtiklNarudzbe {
			get {return artiklNarudzbe;}
			set {
				if(value == null) throw new ArgumentException("Nepostojeći artikl.", nameof(artiklNarudzbe));
				artiklNarudzbe = value;
			}
		}

		public NarudzbaStavka (Artikl artikl, int kolicina, StatusStavke status) {
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
				case 0: s = StatusStavke.NaCekanju; break;
				case 1: s = StatusStavke.UObradi; break;
				case 2: s = StatusStavke.Gotovo; break;
				case 3: s = StatusStavke.Dostavljeno; break;
				default: s = StatusStavke.NaCekanju; break;
			}
			return s;
		}
	}
}
