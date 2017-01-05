using System;

namespace NewRestoran {
	
	public class Artikl {

		public long ID { get; set; }
		private string sifra;
		private string naziv;
		public string DuziNaziv { get; set; }
		private string sastav;
		private float cijena;
		public enum OznakaArtikla { Hrana, Pice, Ostalo }
		public OznakaArtikla Oznaka;

		public string Sifra {
			get { return sifra; }
			set {
				if(value.Equals("")) throw new ArgumentException("Šifra je obavezna.", nameof(sifra));
				sifra = value;
			}
		}

		public string Naziv {
			get { return naziv; }
			set {
				if(value.Equals("")) throw new ArgumentException("Naziv je obavezan.", nameof(naziv));
				naziv = value;
			}
		}

		public float Cijena {
			get {return cijena;}
			set {
				if(value <= 0) throw new ArgumentException("Cijena mora biti veća od nule", nameof(cijena));
				cijena = value;
			}
		}

		public string Sastav {
			get {return sastav;}
			set {
				if(value.Equals("")) throw new ArgumentException("Sastav je obavezan.", nameof(sastav));
				sastav = value;
			}
		}


		public Artikl (string sifra, string naziv, string duziNaziv, float cijena, string sastav, OznakaArtikla oznaka) {
			Sifra = sifra;
			Naziv = naziv;
			DuziNaziv = duziNaziv;
			Cijena = cijena;
			Sastav = sastav;
			Oznaka = oznaka;		
		}

		public Artikl (long id, string sifra, string naziv, string duziNaziv, float cijena, string sastav, OznakaArtikla oznaka) : this(sifra, naziv, duziNaziv, cijena, sastav, oznaka) {
			ID = id;
		}


		public string OznakaToString() {
			string s;
			switch(Oznaka) {
				case OznakaArtikla.Hrana: s = "Hrana"; break;
				case OznakaArtikla.Pice: s = "Piće"; break;
				case OznakaArtikla.Ostalo: s = "Ostalo"; break;
				default: s = "Ostalo"; break;
			}
			return s;
		}

		public static OznakaArtikla GetOznaka(int index) {
			switch(index) {
				case 0: return OznakaArtikla.Hrana;
				case 1: return OznakaArtikla.Pice;
				case 2: return OznakaArtikla.Ostalo;
				default: return OznakaArtikla.Ostalo;
			}
		}

		public static int OznakaGetIndex(OznakaArtikla oznaka) {
			switch(oznaka) {
				case OznakaArtikla.Hrana: return 0;
				case OznakaArtikla.Pice: return 1;
				case OznakaArtikla.Ostalo: return 2;
				default: return 2;
			}
		}

		public static OznakaArtikla OznakaFromString(string oznaka) { 
			OznakaArtikla o;
			switch(oznaka) {
			case "Hrana": o = OznakaArtikla.Hrana; break;
			case "Pice": o = OznakaArtikla.Pice; break;
			case "Ostalo": o = OznakaArtikla.Ostalo; break;
			default: o = OznakaArtikla.Ostalo; break;
			}
			return o;
		}


	}
}
