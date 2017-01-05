using System;
namespace NewRestoran {

	public partial class CalendarWindow : Gtk.Window {
		public delegate void Datum(DateTime datum);
		public Datum DatumOdabran;

		public CalendarWindow() : base(Gtk.WindowType.Toplevel) {
			this.Build();
		}

		protected void OnButtonOdaberiClicked(object sender, EventArgs e) {
			DatumOdabran(calendar.Date);
			this.Destroy();
		}

		protected void OnButtonOdustaniClicked(object sender, EventArgs e) {
			this.Destroy();
		}
	}

}
