	using System;
using Gtk;

namespace NewRestoran {
	public partial class MainWindow : Gtk.Window {

		NarudzbeNodeStore narudzbeNodeStore = new NarudzbeNodeStore();

		public MainWindow() : base (Gtk.WindowType.Toplevel) {
			this.Build ();
			fixedrestoransheme2.HideToolbox ();
			notebookMain.CurrentPage = 0;

			//ArtikliWindow aw = new ArtikliWindow ();

			nodeviewNarudzbe.AppendColumn("Broj narudžbe", new CellRendererText(), "text", 0).MinWidth = 200;
			nodeviewNarudzbe.AppendColumn ("Datum", new CellRendererText (), "text", 1).MinWidth = 150;
			nodeviewNarudzbe.AppendColumn ("Oznaka stola", new CellRendererText (), "text", 2).MinWidth = 100;
			nodeviewNarudzbe.AppendColumn ("Ukupno", new CellRendererText (), "text", 3).MinWidth = 100;
			nodeviewNarudzbe.NodeStore = narudzbeNodeStore;



			nodeviewNarudzbeStatus.AppendColumn ("Šifra artikla", new CellRendererText (), "text", 0).MinWidth = 150;
			nodeviewNarudzbeStatus.AppendColumn ("Naziv artikla", new CellRendererText (), "text", 1).MinWidth = 150;
			nodeviewNarudzbeStatus.AppendColumn ("Količina", new CellRendererText (), "text", 3).MinWidth = 70;
			nodeviewNarudzbeStatus.AppendColumn ("Oznaka stola", new CellRendererText (), "text", 6).MinWidth = 100;
			nodeviewNarudzbeStatus.AppendColumn ("Status", new CellRendererText (), "text", 5).MinWidth = 100;


			//Test podaci
			narudzbeNodeStore.Add (new Narudzba ("1", DateTime.Now, Narudzba.OznakaNarudzbe.Nepotvrdeno));
			narudzbeNodeStore.Add (new Narudzba ("2", DateTime.Now, Narudzba.OznakaNarudzbe.Nepotvrdeno));
			narudzbeNodeStore.Add (new Narudzba ("3", DateTime.Now, Narudzba.OznakaNarudzbe.Nepotvrdeno));

			TreePath tp = new TreePath ("0");
			nodeviewNarudzbeStatus.NodeStore = (narudzbeNodeStore.GetNode (tp) as NarudzbeNode).stavkeNarudzbeNodeStore;
			(narudzbeNodeStore.GetNode (tp) as NarudzbeNode).DodajStavku (new NarudzbaStavka (new Artikl ("s", "n", "2", 22.2f, "2", Artikl.OznakaArtikla.Ostalo), 3, NarudzbaStavka.StatusStavke.Gotovo));

		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
			Application.Quit ();
			a.RetVal = true;
		}
	}
}
