using System;
namespace NewRestoran {

	public class Zaposlenik {

		private int ID;
		private string ime;
		private string prezime;
		private string password;
		private DateTime datumZaposlenja;
		public enum StatusZaposlenik { StalniRadnik, StalniSezonac, Sezonac }
		public StatusZaposlenik Status;
		public enum UlogaZaposlenik { Konobar, Kuhar, Sef }
		public UlogaZaposlenik Uloga;

		public string Ime {
			get {return ime;}
			set {
				if(value.Equals("")) throw new ArgumentException("Ime je obavezno.", nameof(ime));
				ime = value;
			}
		}
		public string Prezime {
			get {return prezime;}
			set {
				if(value.Equals("")) throw new ArgumentException("Prezime je obavezno.", nameof(prezime));
				prezime = value;
			}
		}
		public string Password {
			get {return password;}
			set {
				if(value.Length < 4) throw new ArgumentException("Lozinka mora sadržavati najmanje 4 znaka.", nameof(password));
				password = value;
			}
		}
		public DateTime DatumZaposlenja {
			get {return datumZaposlenja;}
			set {
				if(value.Equals("")) throw new ArgumentException("Datum zaposlenja je obavezan.", nameof(datumZaposlenja));
				if(value > DateTime.Now) throw new ArgumentException("Datum zaposlenja mora biti manji od trenutnog datuma.", nameof(datumZaposlenja));
				datumZaposlenja = value;
			}
		}

		public Zaposlenik (string ime, string prezime, string password, DateTime datumZaposlenja, StatusZaposlenik status, UlogaZaposlenik uloga) {
			Ime = ime;
			Prezime = prezime;
			Password = password;
			DatumZaposlenja = datumZaposlenja;
			Status = status;
			Uloga = uloga;
		}

		public Zaposlenik (int id, string ime, string prezime, string password, DateTime datumZaposlenja, StatusZaposlenik status, UlogaZaposlenik uloga)
			: this(ime, prezime, password, datumZaposlenja, status, uloga){
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
				default: u = "Sezonac"; break;
			}
			return u;
		}

	}
}
