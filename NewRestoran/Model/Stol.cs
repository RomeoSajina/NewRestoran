using System;
namespace NewRestoran {
	
	public class Stol {

		public int ID { get; set; }
		public string Oznaka { get; set; }
		public int BrojStolica { get; set; }



		public Stol (string oznaka, int brojStolica){
			if (oznaka.Equals ("")) throw new ArgumentException ("Oznaka je obavezna.");

			if (brojStolica < 1) throw new ArgumentException ("Broj stolica mora biti veći od 0.");

			Oznaka = oznaka;
			BrojStolica = brojStolica;
		}

		private Stol (int id, string oznaka, int brojStolica) : this(oznaka, brojStolica){
			ID = id; 
		}
	
	
	}
}
