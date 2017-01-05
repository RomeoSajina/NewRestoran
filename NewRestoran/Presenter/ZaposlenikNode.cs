using System;
using Gtk;
using Gdk;
namespace NewRestoran {

	public class ZaposlenikNode : TreeNode{

		private string ime;
		private string prezime;
		private string password;
		private DateTime datumZaposlenja;
		private Zaposlenik.StatusZaposlenik status;
		private Zaposlenik.UlogaZaposlenik uloga;
		public Zaposlenik zaposlenik { get; }

		[TreeNodeValue(Column = 0)]
		public string Ime { 
			get { return ime;}
			set { 
				zaposlenik.Ime = value;
				ime = zaposlenik.Ime;
			}
		}

		[TreeNodeValue(Column = 1)]
		public string Prezime {
			get { return prezime; }
			set {
				zaposlenik.Prezime = value;
				prezime = zaposlenik.Prezime;
			}
		}

		[TreeNodeValue(Column = 2)]
		public string Password {
			get { return password; }
			set {
				zaposlenik.Password = value;
				password = zaposlenik.Password;
			}
		}

		[TreeNodeValue(Column = 3)]
		public string DatumZaposlenja {
			get { return datumZaposlenja.ToString("d"); }
			set {
				zaposlenik.DatumZaposlenja = DateTime.Parse(value);
				datumZaposlenja = zaposlenik.DatumZaposlenja;
			}
		}

		[TreeNodeValue(Column = 4)]
		public string StatusText;


		[TreeNodeValue(Column = 5)]
		public Pixbuf UlogaPixbuf;

		[TreeNodeValue(Column = 6)]
		public string UlogaText;

		public Zaposlenik.StatusZaposlenik Status {
			get {return status;}
			set {
				zaposlenik.Status = value;
				status = zaposlenik.Status;
				StatusText = zaposlenik.StatusToString();
			}
		}

		public Zaposlenik.UlogaZaposlenik Uloga {
			get {return uloga;}
			set {
				zaposlenik.Uloga = value;
				uloga = zaposlenik.Uloga;
				UlogaText = zaposlenik.UlogaToString();
				UlogaPixbuf = Pixbuf.LoadFromResource("NewRestoran.images." + uloga + ".png").ScaleSimple(20, 20, InterpType.Bilinear);
			}
		}

		public ZaposlenikNode(Zaposlenik z){
			zaposlenik = z;
			ime = z.Ime;
			prezime = z.Prezime;
			password = z.Password;
			datumZaposlenja = z.DatumZaposlenja;
			Status = z.Status;
			Uloga = z.Uloga;
		}
	
	
	}
}
