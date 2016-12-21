using System;
using Gtk;

namespace NewRestoran {
	public partial class MainWindow : Gtk.Window {

		public MainWindow() : base (Gtk.WindowType.Toplevel) {
			this.Build ();
			ArtikliWindow aw = new ArtikliWindow ();

		
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
			Application.Quit ();
			a.RetVal = true;
		}
	}
}
