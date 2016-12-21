using System;

namespace NewRestoran {
	
	public class Artikl {

		private int ID { get; set; }
		public string Sifra { get; set; }
		public string Naziv { get; set; }
		public string DuziNaziv { get; set; }
		public float Cijena { get; set; }
		public string Sastav { get; set; }
		public enum OznakaArtikla { Hrana, Pice, Ostalo }
		public OznakaArtikla Oznaka { get; set; }

		public Artikl (string sifra, string naziv, string duziNaziv, float cijena, string sastav, OznakaArtikla oznaka) {
			if (sifra.Equals ("") || naziv.Equals ("") || sastav.Equals ("") || oznaka.Equals (null))
				throw new ArgumentException ("Polja šifra, naziv, sastav i oznaka su obavezni.");

			if (cijena <= 0) throw new ArgumentException ("Cijena mora biti veća od nule", nameof(cijena));

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
