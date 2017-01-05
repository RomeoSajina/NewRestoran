using System;
namespace NewRestoran {
	
	public class Stol {

		public long ID { get; set; }
		private string oznaka;
		private int brojStolica;

		public string Oznaka {
			get { return oznaka; }
			set {
				if(value.Equals("")) throw new ArgumentException("Oznaka je obavezna.", nameof(oznaka));
				oznaka = value;
			}
		}

		public int BrojStolica {
			get {return brojStolica;}
			set {
				if(value <= 0) throw new ArgumentException("Broj stolica mora biti veći od 0.", nameof(brojStolica));
				brojStolica = value;
			}
		}

		public Stol (string oznaka, int brojStolica){
			Oznaka = oznaka;
			BrojStolica = brojStolica;
		}

		public Stol (long id, string oznaka, int brojStolica) : this(oznaka, brojStolica){
			ID = id; 
		}
	
	
	}
}
