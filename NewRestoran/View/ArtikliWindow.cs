using System;
using Gtk;

namespace NewRestoran {
	public partial class ArtikliWindow : Gtk.Window {

		ArtiklNodeStore artikliNodeStore = new ArtiklNodeStore();

		public ArtikliWindow() : base (Gtk.WindowType.Toplevel) {
			this.Build ();

			artikliNodeStore.Add (new Artikl ("sifra", "naziv", "", 3.4f, "sastav", Artikl.OznakaArtikla.Pice));
			artikliNodeStore.Add (new Artikl ("sifra1", "naziv1", "", 3.4f, "sastav1", Artikl.OznakaArtikla.Pice));
			artikliNodeStore.Add (new Artikl ("sifra2", "naziv2", "", 3.4f, "sastav2", Artikl.OznakaArtikla.Pice));

			CellRendererText sifraCell = new CellRendererText ();
			sifraCell.Xalign = 0;
			sifraCell.Alignment = Pango.Alignment.Left;
			sifraCell.Xpad = 0;

			CellRendererText nazivCell = new CellRendererText ();
			nazivCell.Xalign = 0;

			CellRendererText duziNazivCell = new CellRendererText ();
			duziNazivCell.Xalign = 0;

			CellRendererText sastavCell = new CellRendererText ();
			sastavCell.Xalign = 0;

			CellRendererText cijenaCell = new CellRendererText ();
			cijenaCell.Xalign = 1;

			CellRendererPixbuf oznakaPixbufCell = new CellRendererPixbuf();
			oznakaPixbufCell.Width = 20;
			oznakaPixbufCell.Xalign = 0;

			CellRendererText oznakaTextCell = new CellRendererText ();
			oznakaTextCell.Xalign = 0;

			TreeViewColumn oznakaColumn = new TreeViewColumn ();
			oznakaColumn.Title = "Oznaka";
			oznakaColumn.PackStart (oznakaPixbufCell, false);
			oznakaColumn.PackStart (oznakaTextCell, true);
			oznakaColumn.AddAttribute (oznakaPixbufCell, "pixbuf", 5);
			oznakaColumn.AddAttribute (oznakaTextCell, "text", 6);


			nodeviewArtikli.AppendColumn ("Šifra", sifraCell, "text", 0).MinWidth = 100;
			nodeviewArtikli.AppendColumn ("Naziv", nazivCell, "text", 1).MinWidth = 100;
			nodeviewArtikli.AppendColumn ("Duži naziv", duziNazivCell, "text", 2).MinWidth = 200;
			nodeviewArtikli.AppendColumn ("Sastav", sastavCell, "text", 3).MinWidth = 250;
			nodeviewArtikli.AppendColumn ("Cijena", cijenaCell, "text", 4).MinWidth = 100;
			nodeviewArtikli.AppendColumn (oznakaColumn);

			nodeviewArtikli.NodeStore = artikliNodeStore;

			comboboxOznaka.Model = ArtiklNodeStore.dropdownOznakaListStore;
			comboboxOznaka.PackStart (oznakaPixbufCell, false);
			comboboxOznaka.PackStart (oznakaTextCell, true);
			comboboxOznaka.AddAttribute (oznakaPixbufCell, "pixbuf",0);
			comboboxOznaka.AddAttribute (oznakaTextCell, "text", 1);
		
		}

		public Box GetContent() {
			this.Remove (hbox2);
			return hbox2;
		}

		protected void OnButtonSearchClicked(object sender, EventArgs e) {
			/*TreeIter iter;
			comboboxOznaka.GetActiveIter (out iter);
			Console.WriteLine (ArtiklNodeStore.dropdownOznakaListStore.GetValue (iter, 1).ToString ());*/ // Dohvaćanje combobox stringa
		}
	}
}
