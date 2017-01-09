using System;
using Gtk;
using Gdk;
namespace NewRestoran {

	public class StavkaNarudzbeNode : TreeNode {

		private string kolicina;
		private string sifra;
		private StavkaNarudzbe.StatusStavke status;
		public StavkaNarudzbe stavka { get; }

		protected static Pixbuf NaCekanjuPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.NaCekanju.png").ScaleSimple(20, 20, InterpType.Bilinear);
		protected static Pixbuf UObradiPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.UObradi.png").ScaleSimple(20, 20, InterpType.Bilinear);
		protected static Pixbuf GotovoPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Gotovo.png").ScaleSimple(20, 20, InterpType.Bilinear);
		protected static Pixbuf DostavljenoPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Dostavljeno.png").ScaleSimple(20, 20, InterpType.Bilinear);


		[Gtk.TreeNodeValue(Column = 0)]
		public string Sifra {
			get {return sifra;}
			set {
				stavka.ArtiklStavke = ArtikliPresenter.GetArtikl(value);
				sifra = stavka.ArtiklStavke.Sifra;
				Naziv = stavka.ArtiklStavke.Naziv;
				Ukupno = (stavka.ArtiklStavke.Cijena * stavka.Kolicina).ToString("C");
			}
		}

		[Gtk.TreeNodeValue (Column = 1)]
		public string Naziv;

		[Gtk.TreeNodeValue (Column = 2)]
		public string Cijena;

		[Gtk.TreeNodeValue(Column = 3)]
		public string Kolicina {
			get { return kolicina; }
			set {
				stavka.Kolicina = int.Parse(value);
				kolicina = stavka.Kolicina.ToString();
				Ukupno = (stavka.ArtiklStavke.Cijena * stavka.Kolicina).ToString("C");
			}
		}

		[Gtk.TreeNodeValue(Column = 4)]
		public string Ukupno;

		[Gtk.TreeNodeValue (Column = 5)]
		public Pixbuf StatusPixbuf;

		[Gtk.TreeNodeValue (Column = 6)]
		public string StatusText;

		[Gtk.TreeNodeValue (Column = 7)]
		public string OznakaStola;

		public StavkaNarudzbe.StatusStavke Status {
			get {return status;}
			set {
				stavka.Status = value;
				status = stavka.Status;
				StatusText = stavka.StatusToString();
				switch(Status) {
					case StavkaNarudzbe.StatusStavke.NaCekanju: StatusPixbuf = NaCekanjuPixbuf; break;
					case StavkaNarudzbe.StatusStavke.UObradi: StatusPixbuf = UObradiPixbuf; break;
					case StavkaNarudzbe.StatusStavke.Gotovo: StatusPixbuf = GotovoPixbuf; break;
					case StavkaNarudzbe.StatusStavke.Dostavljeno: StatusPixbuf = DostavljenoPixbuf; break;
				}
			}
		}


		public StavkaNarudzbeNode(StavkaNarudzbe ns, string oznakaStola) {
			stavka = ns;
			sifra = ns.ArtiklStavke.Sifra;
			Naziv = ns.ArtiklStavke.Naziv;
			Cijena = ns.ArtiklStavke.Cijena.ToString("C");
			kolicina = ns.Kolicina.ToString();
			Ukupno = (ns.Kolicina * ns.ArtiklStavke.Cijena).ToString ("C");
			OznakaStola = oznakaStola;
			Status = ns.Status;
		}


		public void UpdateStatus(StavkaNarudzbe.StatusStavke status) {
			Status = status;
			DBStavkeNarudzbe.UpdateStavka(stavka);
		}

	}
}
