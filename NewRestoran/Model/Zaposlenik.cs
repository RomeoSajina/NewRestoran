using System;
namespace NewRestoran {

	public class Zaposlenik {

		private int ID;
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Password { get; set; }
		public DateTime DatumZaposlenja { get; set; }
		public enum StatusZaposlenik { StalniRadnik, StalniSezonac, Sezonac }
		public StatusZaposlenik Status { get; set; }
		public enum UlogaZaposlenik { Konobar, Kuhar, Šef }
		public UlogaZaposlenik Uloga { get; set; }


		public Zaposlenik (string ime, string prezime, string password, DateTime datumZaposlenja, StatusZaposlenik status, UlogaZaposlenik uloga) {
			if (ime.Equals ("") || prezime.Equals ("") || password.Equals ("") || datumZaposlenja.Equals (null) || status.Equals (null) || uloga.Equals (null))
				throw new ArgumentException ("Sva polja su obavezna.");

			if (password.Length < 4) throw new ArgumentException ("Lozinka mora sadržavati najmanje 4 znaka.", nameof (password));
			if (datumZaposlenja > DateTime.Now) throw new ArgumentException ("Datum zaposlenja mora biti manji od trenutnog datuma.", nameof (datumZaposlenja));

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

	}
}
