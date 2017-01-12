using System;
using Gtk;
using Gdk;
namespace NewRestoran {
	public class ArtiklButton : Button{

		protected static Pixbuf HranaPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Hrana.png").ScaleSimple(40, 40, InterpType.Bilinear);
		protected static Pixbuf PicePixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Pice.png").ScaleSimple(40, 40, InterpType.Bilinear);
		protected static Pixbuf DesertPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Desert.png").ScaleSimple(40, 40, InterpType.Bilinear);
		protected static Pixbuf OstaloPixbuf = Pixbuf.LoadFromResource("NewRestoran.images.Ostalo.png").ScaleSimple(40, 40, InterpType.Bilinear);

		public string Sifra { get; }

		public ArtiklButton(Artikl a) {
			this.Label = a.Sifra + " - " + a.Naziv;
			Sifra = a.Sifra;
			switch(a.Oznaka) {
				case Artikl.OznakaArtikla.Hrana: this.Image = new Gtk.Image(HranaPixbuf); break;
				case Artikl.OznakaArtikla.Pice: this.Image = new Gtk.Image(PicePixbuf); break;
				case Artikl.OznakaArtikla.Desert: this.Image = new Gtk.Image(DesertPixbuf); break;
				case Artikl.OznakaArtikla.Ostalo: this.Image = new Gtk.Image(OstaloPixbuf); break;
			}
			this.BorderWidth = 7;
			this.FocusOnClick = false;
		}
	}
}
