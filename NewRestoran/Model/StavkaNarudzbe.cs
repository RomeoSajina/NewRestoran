﻿using System;
namespace NewRestoran {
	
	public class StavkaNarudzbe {

		public long ID { get; set; }
		private Artikl artiklStavke;
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

		public Artikl ArtiklStavke {
			get {return artiklStavke;}
			set {
				if(value == null) throw new ArgumentException("Nepostojeći artikl.", nameof(artiklStavke));
				artiklStavke = value;
			}
		}

		public StavkaNarudzbe (Artikl artikl, int kolicina, StatusStavke status) {
			ArtiklStavke = artikl;
			Kolicina = kolicina;
			Status = status;
		}

		public StavkaNarudzbe(long id, Artikl a, int kolicina, StatusStavke status) : this(a, kolicina, status){
			ID = id;
		}

		public string StatusToString() {
			string s;
			switch(Status) {
			case StatusStavke.NaCekanju: s = "Na čekanju"; break;
			case StatusStavke.UObradi: s = "U obradi"; break;
			case StatusStavke.Gotovo: s = "Gotovo"; break;
			case StatusStavke.Dostavljeno: s = "Dostavljeno"; break;
			default: s = "Na čekanju"; break;
			}
			return s;
		}

		public static StatusStavke GetStatus(int index) {
			switch(index) {
				case 0: return StatusStavke.NaCekanju;
				case 1: return StatusStavke.UObradi; 
				case 2: return StatusStavke.Gotovo; 
				case 3: return StatusStavke.Dostavljeno;
				default: return StatusStavke.NaCekanju; 
			} 
		}

		public static int StatusGetIndex(StatusStavke s) { 
			switch(s) {
			case StatusStavke.NaCekanju: return 0;
			case StatusStavke.UObradi: return 1;
			case StatusStavke.Gotovo: return 2;
			case StatusStavke.Dostavljeno: return 3;
			default: return 0;
			}
			
		}

		public static StatusStavke StatusFromString(string status) { 
			StatusStavke s;
			switch(status) {
			case "NaCekanju": s = StatusStavke.NaCekanju; break;
			case "UObradi": s = StatusStavke.UObradi; break;
			case "Gotovo": s = StatusStavke.Gotovo; break;
			case "Dostavljeno": s = StatusStavke.Dostavljeno; break;
			default: s = StatusStavke.NaCekanju; break;
			}
			return s;		
		}


	}
}
