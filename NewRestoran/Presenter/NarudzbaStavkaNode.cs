using System;
using Gtk;
using Gdk;
namespace NewRestoran {

	public class NarudzbaStavkaNode : TreeNode {

		public int Id { get; set; }
		private string kolicina;
		private string sifra;
		private NarudzbaStavka.StatusStavke status;
		private NarudzbaStavka stavka;

		[Gtk.TreeNodeValue(Column = 0)]
		public string Sifra {
			get {return sifra;}
			set {
				stavka.ArtiklStavke = ArtikliPresenter.GetArtikl(value);
				MainWindow.statusStore.RemoveNode(this);

				sifra = stavka.ArtiklStavke.Sifra;
				Naziv = stavka.ArtiklStavke.Naziv;
				Ukupno = (stavka.ArtiklStavke.Cijena * stavka.Kolicina).ToString("C");
				MainWindow.statusStore.AddNode(this);
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
				kolicina = value;
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

		public NarudzbaStavka.StatusStavke Status {
			get {return status;}
			set {
				stavka.Status = value;
				status = stavka.Status;
				StatusPixbuf = Pixbuf.LoadFromResource("NewRestoran.images." + status + ".png").ScaleSimple(20, 20, InterpType.Bilinear);
				StatusText = stavka.StatusToString();
				MainWindow.stavkeChanged();
			}
		}




		public NarudzbaStavkaNode(NarudzbaStavka ns, string oznakaStola) {
			stavka = ns;
			sifra = ns.ArtiklStavke.Sifra;
			Naziv = ns.ArtiklStavke.Naziv;
			Cijena = ns.ArtiklStavke.Cijena.ToString("C");
			kolicina = ns.Kolicina.ToString();
			Ukupno = (ns.Kolicina * ns.ArtiklStavke.Cijena).ToString ("C");
			Status = ns.Status;
			OznakaStola = oznakaStola;
			Status = ns.Status;
			Id = ns.Id;
		}


	}
}
