using System;
using Gtk;
using Gdk;
namespace NewRestoran {

	public class NarudzbaStavkaNode : TreeNode {

		private string kolicina;
		private string sifra;

		[Gtk.TreeNodeValue(Column = 0)]
		public string Sifra {
			get {return sifra;}
			set {
				if(stavka != null) {
					stavka.ArtiklNarudzbe = ArtikliPresenter.GetArtikl(value);
					MainWindow.statusStore.RemoveNode(this);

					sifra = stavka.ArtiklNarudzbe.Sifra;
					Naziv = stavka.ArtiklNarudzbe.Naziv;
					Ukupno = (stavka.ArtiklNarudzbe.Cijena * stavka.Kolicina).ToString("C");

					MainWindow.statusStore.AddNode(this);
				}
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
				if(stavka != null) stavka.Kolicina = int.Parse(value);
				kolicina = value;
				Ukupno = (stavka.ArtiklNarudzbe.Cijena * stavka.Kolicina).ToString("C");
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

		public int Id { get; set; }
		public NarudzbaStavka.StatusStavke Status { get; set;}
		private NarudzbaStavka stavka;



		public NarudzbaStavkaNode(NarudzbaStavka ns, string oznakaStola) {
			sifra = ns.ArtiklNarudzbe.Sifra;
			Naziv = ns.ArtiklNarudzbe.Naziv;
			Cijena = ns.ArtiklNarudzbe.Cijena.ToString("C");
			kolicina = ns.Kolicina.ToString();
			Ukupno = (ns.Kolicina * ns.ArtiklNarudzbe.Cijena).ToString ("C");
			SetStatus(ns.Status);
			OznakaStola = oznakaStola;
			Status = ns.Status;
			Id = ns.Id;
			stavka = ns;
		}

		public void SetStatus(NarudzbaStavka.StatusStavke status) { 
			StatusPixbuf = Pixbuf.LoadFromResource("NewRestoran.images." + status + ".png").ScaleSimple(20, 20, InterpType.Bilinear);
			StatusText = status.ToString();
			Status = status;

			MainWindow.stavkeChanged();

		}


	}
}
