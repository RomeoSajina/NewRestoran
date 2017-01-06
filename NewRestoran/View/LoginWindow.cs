using System;
using Gtk;
using Gdk;
namespace NewRestoran {
	public partial class LoginWindow : Gtk.Window {

		MainWindow mainWin;

		public LoginWindow(MainWindow main) : base(Gtk.WindowType.Toplevel) {
			this.Build();
			mainWin = main;
			this.Destroyed += OnCancelLoginButtonClicked;


			Color c = new Color();
			Color.Parse("#6c6c6d", ref c);
			ForAll<Label>(l => l.ModifyFont(Pango.FontDescription.FromString("bold 12")), new Container[] { hbox1, hbox2, vbox1});
			ForAll<Label>(l => l.ModifyFg(StateType.Normal, c), new Container[] { hbox1, hbox2, vbox1 });

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

		protected void ForAll<T>(Callback action, Container[] parents) where T : Gtk.Widget {
			foreach(Container parent in parents) {
				foreach(Widget w in parent) {
					if(w is T) {
						action.Invoke(w);
					}
				}
			}
		}

	}
}
