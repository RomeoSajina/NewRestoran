using System;
using Gtk;
namespace NewRestoran {
	public partial class LoginWindow : Gtk.Window {

		MainWindow mainWin;

		public LoginWindow(MainWindow main) : base(Gtk.WindowType.Toplevel) {
			this.Build();
			mainWin = main;
			this.Destroyed += OnCancelLoginButtonClicked;
		}

		protected void OnLoginButtonClicked(object sender, EventArgs e) {
			if(imeEntry.Text == "" || passwordEntry.Text == "") {
				DialogBox.ShowWarning(this, "Unesite Vaše ime i lozinku.");
				return;
			}
		
			Zaposlenik z = DBZaposlenik.GetZaposlenik	(imeEntry.Text, passwordEntry.Text);
			if(z == null){
				DialogBox.ShowWarning(this, "Pogrešno ime ili lozinka.");
			}else {
				mainWin.zaposlenik = z;
				this.Destroyed -= OnCancelLoginButtonClicked;
				this.Destroy();
			}
		}

		protected void OnCancelLoginButtonClicked(object sender, EventArgs e) {
			this.Destroy();
			mainWin.OnDeleteEvent(sender, new DeleteEventArgs());
		}

	}
}
