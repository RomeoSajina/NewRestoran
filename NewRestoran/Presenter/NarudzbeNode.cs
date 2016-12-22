using System;
using Gtk;

namespace NewRestoran {

	public class NarudzbeNode : TreeNode{

		public NarudzbaStavkaNodeStore stavkeNarudzbeNodeStore = new NarudzbaStavkaNodeStore();

		[Gtk.TreeNodeValue (Column = 0)]
		public string Broj;

		[Gtk.TreeNodeValue (Column = 1)]
		public string Datum;

		[Gtk.TreeNodeValue (Column = 2)]
		public string OznakaStola;

		[Gtk.TreeNodeValue (Column = 3)]
		public string Ukupno;

		public NarudzbeNode(Narudzba n) {
			Broj = n.Broj;
			Datum = n.Datum.ToString("g");
			Ukupno = n.Ukupno().ToString("C");

			if (n.StolNarudzbe != null)
				OznakaStola = n.StolNarudzbe.Oznaka;
			else OznakaStola = "-";
		}

		public void DodajStavku(NarudzbaStavka ns) {
			stavkeNarudzbeNodeStore.Add (ns, OznakaStola);
		}
	
	}
}
