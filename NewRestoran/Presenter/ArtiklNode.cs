using System;
using Gdk;
using Gtk;
namespace NewRestoran {

	public class ArtiklNode : TreeNode{

		[Gtk.TreeNodeValue (Column = 0)]
		public string Sifra;

		[Gtk.TreeNodeValue (Column = 1)]
		public string Naziv;

		[Gtk.TreeNodeValue (Column = 2)]
		public string DuziNaziv;

		[Gtk.TreeNodeValue (Column = 3)]
		public string Sastav;

		[Gtk.TreeNodeValue (Column = 4)]
		public string Cijena;

		[Gtk.TreeNodeValue (Column = 5)]
		public Pixbuf OznakaPixbuf;

		[Gtk.TreeNodeValue (Column = 6)]
		public string OznakaText; 

		public ArtiklNode (Artikl a) {
			Sifra = a.Sifra;
			Naziv = a.Naziv;
			DuziNaziv = a.DuziNaziv;
			Sastav = a.Sastav;
			Cijena = a.Cijena.ToString("C");

			OznakaPixbuf = Pixbuf.LoadFromResource("NewRestoran.images."+ a.Oznaka +".png").ScaleSimple(20,20,InterpType.Bilinear);
			OznakaText = a.Oznaka.ToString();

		}

	}
}
