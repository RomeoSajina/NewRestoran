using System;
namespace NewRestoran {

	public class Zaposlenik {

		public long ID { get; set; }
		private string ime;
		private string prezime;
		private string password;
		private DateTime datumZaposlenja;
		public enum StatusZaposlenik { StalniRadnik, StalniSezonac, Sezonac }
		public StatusZaposlenik Status;
		public enum UlogaZaposlenik { Konobar, Kuhar, Sef }
		public UlogaZaposlenik Uloga;

		public string Ime {
			get { return ime; }
			set {
				if(value.Equals("")) throw new ArgumentException("Ime je obavezno.", nameof(ime));
				ime = value;
			}
		}
		public string Prezime {
			get { return prezime; }
			set {
				if(value.Equals("")) throw new ArgumentException("Prezime je obavezno.", nameof(prezime));
				prezime = value;
			}
		}
		public string Password {
			get { return password; }
			set {
				if(value.Length < 4) throw new ArgumentException("Lozinka mora sadržavati najmanje 4 znaka.", nameof(password));
				password = value;
			}
		}
		public DateTime DatumZaposlenja {
			get { return datumZaposlenja; }
			set {
				if(value.Equals("")) throw new ArgumentException("Datum zaposlenja je obavezan.", nameof(datumZaposlenja));
				if(value > DateTime.Now) throw new ArgumentException("Datum zaposlenja mora biti manji od trenutnog datuma.", nameof(datumZaposlenja));
				datumZaposlenja = value;
			}
		}

		public Zaposlenik(string ime, string prezime, string password, DateTime datumZaposlenja, StatusZaposlenik status, UlogaZaposlenik uloga) {
			Ime = ime;
			Prezime = prezime;
			Password = password;
			DatumZaposlenja = datumZaposlenja;
			Status = status;
			Uloga = uloga;
		}

		public Zaposlenik(long id, string ime, string prezime, string password, DateTime datumZaposlenja, StatusZaposlenik status, UlogaZaposlenik uloga)
			: this(ime, prezime, password, datumZaposlenja, status, uloga) {
			ID = id;
		}

		public string StatusToString() {
			string s;
			switch(Status) {
			case StatusZaposlenik.Sezonac: s = "Sezonac"; break;
			case StatusZaposlenik.StalniSezonac: s = "Stalni sezonac"; break;
			case StatusZaposlenik.StalniRadnik: s = "Stalni radnik"; break;
			default: s = "Sezonac"; break;
			}
			return s;
		}

		public string UlogaToString() {
			string u;
			switch(Uloga) {
			case UlogaZaposlenik.Konobar: u = "Konobar"; break;
			case UlogaZaposlenik.Kuhar: u = "Kuhar"; break;
			case UlogaZaposlenik.Sef: u = "Šef"; break;
			default: u = "Konobar"; break;
			}
			return u;
		}

		public static StatusZaposlenik StatusFromString(string status) {
			StatusZaposlenik s;
			switch(status) {
			case "Sezonac": s = StatusZaposlenik.Sezonac; break;
			case "StalniSezonac": s = StatusZaposlenik.StalniSezonac; break;
			case "StalniRadnik": s = StatusZaposlenik.StalniRadnik; break;
			default: s = StatusZaposlenik.Sezonac; break;
			}
			return s;
		}

		public static UlogaZaposlenik UlogaFromString(string uloga) {
			UlogaZaposlenik u;
			switch(uloga) {
			case "Konobar": u = UlogaZaposlenik.Konobar; break;
			case "Kuhar": u = UlogaZaposlenik.Kuhar; break;
			case "Sef": u = UlogaZaposlenik.Sef; break;
			default: u = UlogaZaposlenik.Kuhar; break;
			}
			return u;
		}


		public static StatusZaposlenik GetStatus(int index) {
			switch(index) {
			case 0: return StatusZaposlenik.Sezonac;
			case 1: return StatusZaposlenik.StalniSezonac;
			case 2: return StatusZaposlenik.StalniRadnik;
			default: return StatusZaposlenik.Sezonac; ;
			}
		}

		public static UlogaZaposlenik GetUloga(int index) {
			switch(index) {
			case 0: return UlogaZaposlenik.Konobar;
			case 1: return UlogaZaposlenik.Kuhar;
			case 2: return UlogaZaposlenik.Sef;
			default: return UlogaZaposlenik.Konobar;
			}
		}

		public static int GetStatus(StatusZaposlenik status) {
			switch(status) {
				case StatusZaposlenik.Sezonac: return 0;
				case StatusZaposlenik.StalniSezonac: return 1;
				case StatusZaposlenik.StalniRadnik: return 2;
				default: return 0; 
			}
		}

		public static int GetUloga(UlogaZaposlenik uloga) {
			switch(uloga) {
				case UlogaZaposlenik.Konobar: return 0;
				case UlogaZaposlenik.Kuhar: return 1;
				case UlogaZaposlenik.Sef: return 2;
				default: return 0;
			}
		}




	}
}