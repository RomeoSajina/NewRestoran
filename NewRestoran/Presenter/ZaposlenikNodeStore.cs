using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {

	public class ZaposlenikNodeStore : NodeStore{
	
		public ZaposlenikNodeStore() : base(typeof(ZaposlenikNode)){
			this.AddList(DBZaposlenik.GetZaposlenike());
		}	

		public void Add(Zaposlenik z) {
			this.AddNode(new ZaposlenikNode(z));
		}

		public void AddList(List<Zaposlenik> zaposlenici) {
			zaposlenici.ForEach(z => this.Add(z));
		}

		public void DodajZaposlenika(string ime, string prezime, string password, string datumZaposlenja, int status, int uloga) {
			Zaposlenik z = new Zaposlenik(ime, prezime, password, DateTime.Parse(datumZaposlenja), Zaposlenik.GetStatus(status), Zaposlenik.GetUloga(uloga));
			this.Add(z);
			DBZaposlenik.SaveZaposlenik(ref z);
		}

		public void UpdateZaposlenika(ZaposlenikNode zn, string ime, string prezime, string password, string datumZaposlenja, int status, int uloga) {
			zn.Ime = ime;
			zn.Prezime = prezime;
			zn.Password = password;
			zn.DatumZaposlenja = datumZaposlenja;
			zn.Status = Zaposlenik.GetStatus(status);
			zn.Uloga = Zaposlenik.GetUloga(uloga);

			DBZaposlenik.UpdateZaposlenik(zn.zaposlenik);
		}

		public void IzbrisiZaposlenika(ZaposlenikNode zn) {
			this.RemoveNode(zn);
			DBZaposlenik.DeleteZaposlenik(zn.zaposlenik);		
		}

	}
}
