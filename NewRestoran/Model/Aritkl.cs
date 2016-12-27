using System;

namespace NewRestoran {
	
	public class Artikl {

		private int ID { get; set; }
		private string sifra;
		private string naziv;
		public string DuziNaziv { get; set; }
		private float cijena;
		private string sastav;
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

		public Artikl (int id, string sifra, string naziv, string duziNaziv, float cijena, string sastav, OznakaArtikla oznaka) : this(sifra, naziv, duziNaziv, cijena, sastav, oznaka) {
			ID = id;
		}



	}
}
