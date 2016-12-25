using System;
using Gtk;
using Gdk;
namespace NewRestoran {

	public class NarudzbaStavkaNode : TreeNode {

		[Gtk.TreeNodeValue (Column = 0)]
		public string Sifra;

		[Gtk.TreeNodeValue (Column = 1)]
		public string Naziv;

		[Gtk.TreeNodeValue (Column = 2)]
		public string Cijena;

		[Gtk.TreeNodeValue (Column = 3)]
		public string Kolicina;

		[Gtk.TreeNodeValue (Column = 4)]
		public string Ukupno;

		[Gtk.TreeNodeValue (Column = 5)]
		public Pixbuf StatusPixbuf;

		[Gtk.TreeNodeValue (Column = 6)]
		public string StatusText;

		[Gtk.TreeNodeValue (Column = 7)]
		public string OznakaStola;

		public int Id { get; set; }

		public NarudzbaStavkaNode(NarudzbaStavka ns, string oznakaStola) {
			Sifra = ns.ArtiklNarudzbe.Sifra;
			Naziv = ns.ArtiklNarudzbe.Naziv;
			Cijena = ns.ArtiklNarudzbe.Cijena.ToString("C");
			Kolicina = ns.Kolicina.ToString();
			Ukupno = (ns.Kolicina * ns.ArtiklNarudzbe.Cijena).ToString ("C");
			SetStatus(ns.Status);
			OznakaStola = oznakaStola;
			Id = ns.Id;
		}

		public void SetStatus(NarudzbaStavka.StatusStavke status) { 
			StatusPixbuf = Pixbuf.LoadFromResource("NewRestoran.images." + status + ".png").ScaleSimple(20, 20, InterpType.Bilinear);
			StatusText = status.ToString();
		}

	}
}
