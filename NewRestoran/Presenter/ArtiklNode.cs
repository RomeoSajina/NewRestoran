using System;
using Gdk;
using Gtk;
namespace NewRestoran {

	public class ArtiklNode : TreeNode{
		public Artikl artikl { get; }
		private string sifra;
		private string naziv;
		private string duziNaziv;
		private string sastav;
		private string cijena;
		private Artikl.OznakaArtikla oznaka;

		protected static Pixbuf HranaPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Hrana.png").ScaleSimple(20,20, InterpType.Bilinear);
		protected static Pixbuf PicePixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Pice.png").ScaleSimple(20, 20, InterpType.Bilinear);
		protected static Pixbuf OstaloPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Ostalo.png").ScaleSimple(20, 20, InterpType.Bilinear);


		[Gtk.TreeNodeValue(Column = 0)]
		public string Sifra {
			get { return sifra; }
			set {
				artikl.Sifra = value;
				sifra = artikl.Sifra; 
			}
		}

		[Gtk.TreeNodeValue (Column = 1)]
		public string Naziv{
			get { return naziv; }
			set {
				artikl.Naziv = value;
				naziv = artikl.Naziv; 
			}
		}

		[Gtk.TreeNodeValue (Column = 2)]
		public string DuziNaziv{
			get { return duziNaziv; }
			set {
				artikl.DuziNaziv = value;
				duziNaziv = artikl.DuziNaziv; 
			}
		}

		[Gtk.TreeNodeValue (Column = 3)]
		public string Sastav{
			get { return sastav; }
			set {
				artikl.Sastav = value;
				sastav = artikl.Sastav; 
			}
		}

		[Gtk.TreeNodeValue (Column = 4)]
		public string Cijena{
			get { return cijena; }
			set {
				artikl.Cijena = float.Parse(value);
				cijena = artikl.Cijena.ToString("C");
			}
		}

		[Gtk.TreeNodeValue (Column = 5)]
		public Pixbuf OznakaPixbuf;

		[Gtk.TreeNodeValue (Column = 6)]
		public string OznakaText;

		public Artikl.OznakaArtikla Oznaka {
			get {return oznaka;}
			set {
				artikl.Oznaka = value;
				oznaka = artikl.Oznaka;
				OznakaPixbuf = Pixbuf.LoadFromResource("NewRestoran.images." + oznaka + ".png").ScaleSimple(20, 20, InterpType.Bilinear);
				OznakaText = oznaka.ToString();
			}
		}

		public ArtiklNode (Artikl a) {
			artikl = a;
			sifra = a.Sifra;
			naziv = a.Naziv;
			duziNaziv = a.DuziNaziv;
			sastav = a.Sastav;
			cijena = a.Cijena.ToString("C");
			oznaka = a.Oznaka;

			OznakaPixbuf = Pixbuf.LoadFromResource("NewRestoran.images."+ a.Oznaka +".png").ScaleSimple(20,20,InterpType.Bilinear);


			OznakaText = a.Oznaka.ToString();
		}

	}
}
