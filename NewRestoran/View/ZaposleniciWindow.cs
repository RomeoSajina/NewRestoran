using System;
using Gtk;
using Gdk;
namespace NewRestoran {
	
	public partial class ZaposleniciWindow : Gtk.Window {

		private ZaposlenikNodeStore zaposleniciNodeStore = new ZaposlenikNodeStore();
		private bool formPrikaz = false;

		public ZaposleniciWindow(bool prikazi) : base(Gtk.WindowType.Toplevel) {
			this.Build();
			if(prikazi) this.Show();

			CellRendererText ulogaTextCell = new CellRendererText();
			CellRendererPixbuf ulogaPixbufCell = new CellRendererPixbuf();

			TreeViewColumn ulogaColumn = new TreeViewColumn();
			ulogaColumn.Title = "Uloga";
			ulogaColumn.MinWidth = 150;
			ulogaColumn.PackStart(ulogaPixbufCell, false);
			ulogaColumn.PackStart(ulogaTextCell, true);
			ulogaColumn.AddAttribute(ulogaPixbufCell, "pixbuf", 5);
			ulogaColumn.AddAttribute(ulogaTextCell, "text", 6);

			nodeviewZaposlenici.AppendColumn("Ime", new CellRendererText(), "text", 0).MinWidth = 150;
			nodeviewZaposlenici.AppendColumn("Prezime", new CellRendererText(), "text", 1).MinWidth = 150;
			nodeviewZaposlenici.AppendColumn("Password", new CellRendererText(), "text", 2).MinWidth = 150;
			nodeviewZaposlenici.AppendColumn("Datum zaposlenja", new CellRendererText(), "text", 3).MinWidth = 140;
			nodeviewZaposlenici.AppendColumn("Status", new CellRendererText(), "text", 4).MinWidth = 150;
			nodeviewZaposlenici.AppendColumn(ulogaColumn);

			nodeviewZaposlenici.NodeStore = zaposleniciNodeStore;
			nodeviewZaposlenici.Selection.Changed += SelectionChanged;

			ListStore dropdownUlogaListStore = new ListStore(typeof(Pixbuf), typeof(string));
			dropdownUlogaListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Konobar.png").ScaleSimple(20, 20, InterpType.Bilinear), "Konobar");
			dropdownUlogaListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Kuhar.png").ScaleSimple(20, 20, InterpType.Bilinear), "Kuhar");
			dropdownUlogaListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Sef.png").ScaleSimple(20, 20, InterpType.Bilinear), "Šef");

			comboboxUloga.Model = dropdownUlogaListStore;
			comboboxUloga.PackStart(ulogaPixbufCell, false);
			comboboxUloga.PackStart(ulogaTextCell, true);
			comboboxUloga.AddAttribute(ulogaPixbufCell, "pixbuf", 0);
			comboboxUloga.AddAttribute(ulogaTextCell, "text", 1);

			comboboxStatus.AppendText("Sezonac");
			comboboxStatus.AppendText("Stalni sezonac");
			comboboxStatus.AppendText("Stalni radnik");

			this.Resize(500, 500);

			Color c = new Color();
			Color.Parse("#00bd00", ref c);
			labelSpremljeno.ModifyFg(StateType.Normal, c);
			labelSpremljeno.ModifyFont(Pango.FontDescription.FromString("bold 16"));
			ForAll<Label>(l => l.ModifyFont(Pango.FontDescription.FromString("bold 10")), new Container[] { hbox1, hbox3, hbox4, hbox5, hbox6, hbox7 });
			nodeviewZaposlenici.GrabFocus();

			entrySearch.Changed += (sender, e) => entrySearchForm.Text = entrySearch.Text;
			entrySearchForm.Changed += (sender, e) => entrySearch.Text = entrySearchForm.Text;
		}

		public Box GetContent() {
			this.Remove(hbox2);
			return hbox2;
		}

		protected void SelectionChanged(object sender, EventArgs e) {
			ZaposlenikNode zn = (nodeviewZaposlenici.NodeSelection.SelectedNode as ZaposlenikNode);
			if(zn != null) { 
				entryIme.Text = zn.Ime;
				entryPrezime.Text = zn.Prezime;
				entryPassword.Text = zn.Password;
				entryDatum.Text = zn.DatumZaposlenja;
				comboboxStatus.Active = Zaposlenik.GetStatus(zn.Status);
				comboboxUloga.Active = Zaposlenik.GetUloga(zn.Uloga);
			}
		}

		protected void IsprazniFormu() {
			entryIme.Text = "";
			entryPrezime.Text = "";
			entryPassword.Text = "";
			entryDatum.Text = DateTime.Now.ToString("d");
			comboboxStatus.Active = 0;
			comboboxUloga.Active = 0;
		}

		protected void OnButtonDatumClicked(object sender, EventArgs e) {
			CalendarWindow cw = new CalendarWindow();
			cw.DatumOdabran += (datum) => { entryDatum.Text = datum.ToString("d"); };
		}

		protected void OnButtonDodajZaposlenikaClicked(object sender, EventArgs e) {
			IsprazniFormu();
			nodeviewZaposlenici.Selection.UnselectAll();
			if(!formPrikaz) buttonChange.Click();
		}

		protected void OnButtonUpClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter, prev, temp;
				nodeviewZaposlenici.Selection.GetSelected(out iter);
				nodeviewZaposlenici.Model.GetIterFirst(out prev);

				do {
					temp = prev;
					nodeviewZaposlenici.Model.IterNext(ref temp);
					if(temp.Equals(iter)) {
						nodeviewZaposlenici.Selection.SelectIter(prev);
						break;
					}
				} while(nodeviewZaposlenici.Model.IterNext(ref prev));

				nodeviewZaposlenici.Selection.SelectIter(prev);

			} else {
				GtkScrolledWindowZaposlenici.Vadjustment.Value -= 150;
			}
		}

		protected void OnButtonDownClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter;
				nodeviewZaposlenici.Selection.GetSelected(out iter);

				if(!nodeviewZaposlenici.Model.IterNext(ref iter))
					nodeviewZaposlenici.Model.GetIterFirst(out iter);

				nodeviewZaposlenici.Selection.SelectIter(iter);
			} else {
				double max = GtkScrolledWindowZaposlenici.Vadjustment.Upper - GtkScrolledWindowZaposlenici.Vadjustment.PageSize;

				if(GtkScrolledWindowZaposlenici.Vadjustment.Value + 150 > max)
					GtkScrolledWindowZaposlenici.Vadjustment.Value = max;
				else
					GtkScrolledWindowZaposlenici.Vadjustment.Value += 150;
			}
		}

		protected void OnButtonChangeClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				vboxNodeView.Show();
				vboxFormView.Hide();
				formPrikaz = false;
			} else {
				vboxNodeView.Hide();
				vboxFormView.Show();
				formPrikaz = true;
			}
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e) {
			ZaposlenikNode zn = nodeviewZaposlenici.NodeSelection.SelectedNode as ZaposlenikNode;
			if(zn != null){
				zaposleniciNodeStore.IzbrisiZaposlenika(zn);
				IsprazniFormu();
			}
		}

		protected void OnButtonBackAndSaveClicked(object sender, EventArgs e) {
			if((nodeviewZaposlenici.NodeSelection.SelectedNode as ZaposlenikNode) == null) {
				if(entryIme.Text != "" || entryPrezime.Text != "" || entryPassword.Text != "") {
					if(SpremiPromjene())
						this.Destroy();
				}else this.Destroy();

			} else if(SpremiPromjene())
				this.Destroy();
		}

		protected void OnButtonSpremiClicked(object sender, EventArgs e) {
			SpremiPromjene();
		}

		protected void OnButtonOdustaniClicked(object sender, EventArgs e) {
			buttonDodajZaposlenika.Click();
			buttonChange.Click();
		}

		protected bool SpremiPromjene() {
			ZaposlenikNode zn = (nodeviewZaposlenici.NodeSelection.SelectedNode as ZaposlenikNode);
			try {
				if(zn == null) { //Insert
					zaposleniciNodeStore.DodajZaposlenika(entryIme.Text, entryPrezime.Text, entryPassword.Text, entryDatum.Text, comboboxStatus.Active, comboboxUloga.Active);
					TreeIter iter;
					nodeviewZaposlenici.Model.IterNthChild(out iter, nodeviewZaposlenici.Model.IterNChildren() - 1);
					nodeviewZaposlenici.Selection.SelectIter(iter);
				} else { //Update
					zaposleniciNodeStore.UpdateZaposlenika(zn, entryIme.Text, entryPrezime.Text, entryPassword.Text, entryDatum.Text, comboboxStatus.Active, comboboxUloga.Active);
				}
				hboxSpremljeno.Show();
				GLib.Timeout.Add(2000, () => { hboxSpremljeno.Hide(); return false; });
				return true;

			} catch(ArgumentException ae) {
				string msg;
				switch(ae.ParamName) {
				case "ime": msg = "Ime je obavezno."; break;
				case "prezime": msg = "Prezime je obavezno."; break;
				case "password": msg = "Lozinka je obavezna."; break;
				case "datumZaposlenja":
					if(entryDatum.Text.Equals(""))
						msg = "Datum zaposlenja je obavezan.";
					else 
						msg = "Datum mora biti manji od sadašnjeg datuma.";
					break;
				default: msg = ae.Message; break;
				}
				DialogBox.ShowError(this, msg);
				return false;
			}
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

		protected void OnButtonSearchClicked(object sender, EventArgs e) {
			if(entrySearch.Text == "") nodeviewZaposlenici.NodeStore = zaposleniciNodeStore;
			else {
				ZaposlenikNodeStore zns = new ZaposlenikNodeStore();

				foreach(ZaposlenikNode zn in zaposleniciNodeStore) {
					if(zn.Ime.ToLower().Contains(entrySearch.Text.ToLower()) || zn.Prezime.ToLower().Contains(entrySearch.Text.ToLower()))
						zns.AddNode(zn);
				}

				nodeviewZaposlenici.NodeStore = zns;
				nodeviewZaposlenici.Selection.SelectPath(new TreePath("0"));
			}
		}

	
	
	}
}