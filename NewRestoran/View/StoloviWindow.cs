using System;
using Gtk;
using Gdk;
namespace NewRestoran {

	public partial class StoloviWindow : Gtk.Window {

		private StolNodeStore stoloviNodeStore = new StolNodeStore();
		private bool formPrikaz = false;

		public StoloviWindow(bool prikazi) : base(Gtk.WindowType.Toplevel) {
			this.Build();
			if(prikazi) this.Show();

			nodeviewStolovi.AppendColumn("Oznaka", new CellRendererText(), "text", 0).MinWidth = 200;
			nodeviewStolovi.AppendColumn("Broj stolica", new CellRendererText(), "text", 1).MinWidth = 190;
			nodeviewStolovi.NodeStore = stoloviNodeStore;
			nodeviewStolovi.Selection.Changed += SelectionChanged;
		
			this.Resize(500, 500);

			Color c = new Color();
			Color.Parse("#00bd00", ref c);
			labelSpremljeno.ModifyFg(StateType.Normal, c);
			labelSpremljeno.ModifyFont(Pango.FontDescription.FromString("bold 16"));
			ForAll<Label>(l => l.ModifyFont(Pango.FontDescription.FromString("bold 10")), new Container[] { hbox1, hbox3 });
			nodeviewStolovi.GrabFocus();
		}
		public Box GetContent() {
			this.Remove(hbox2);
			return hbox2;
		}

		protected void SelectionChanged(object sender, EventArgs e) {
			StolNode sn = nodeviewStolovi.NodeSelection.SelectedNode as StolNode;
			if(sn != null) {
				entryOznaka.Text = sn.Oznaka;
				spinbuttonBrojStolica.Value = int.Parse(sn.BrojStolica);
			}
		}

		protected void IsprazniFormu() {
			entryOznaka.Text = "";
			spinbuttonBrojStolica.Value = 0;
		}


		protected void OnButtonDodajStolClicked(object sender, EventArgs e) {
			IsprazniFormu();
			nodeviewStolovi.Selection.UnselectAll();
			if(!formPrikaz) buttonChange.Click();
		}

		protected void OnButtonUpClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter, prev, temp;
				nodeviewStolovi.Selection.GetSelected(out iter);
				nodeviewStolovi.Model.GetIterFirst(out prev);

				do {
					temp = prev;
					nodeviewStolovi.Model.IterNext(ref temp);
					if(temp.Equals(iter)) {
						nodeviewStolovi.Selection.SelectIter(prev);
						break;
					}
				} while(nodeviewStolovi.Model.IterNext(ref prev));

				nodeviewStolovi.Selection.SelectIter(prev);

			} else {
				GtkScrolledWindowStolovi.Vadjustment.Value -= 150;
			}
		}

		protected void OnButtonDownClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter;
				nodeviewStolovi.Selection.GetSelected(out iter);

				if(!nodeviewStolovi.Model.IterNext(ref iter))
					nodeviewStolovi.Model.GetIterFirst(out iter);

				nodeviewStolovi.Selection.SelectIter(iter);
			} else {
				double max = GtkScrolledWindowStolovi.Vadjustment.Upper - GtkScrolledWindowStolovi.Vadjustment.PageSize;

				if(GtkScrolledWindowStolovi.Vadjustment.Value + 150 > max)
					GtkScrolledWindowStolovi.Vadjustment.Value = max;
				else
					GtkScrolledWindowStolovi.Vadjustment.Value += 150;
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
			StolNode sn = nodeviewStolovi.NodeSelection.SelectedNode as StolNode;
			if(sn != null) {
				stoloviNodeStore.IzbrisiStol(sn);
				IsprazniFormu();
			}
		}

		protected void OnButtonBackAndSaveClicked(object sender, EventArgs e) {
			if((nodeviewStolovi.NodeSelection.SelectedNode as StolNode) == null) {
				if(entryOznaka.Text != "" || spinbuttonBrojStolica.ValueAsInt != 0) {
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
			buttonDodajStol.Click();
			buttonChange.Click();
		}

		protected bool SpremiPromjene() {
			StolNode sn = (nodeviewStolovi.NodeSelection.SelectedNode as StolNode);
			try {
				if(sn == null) { //Insert
					stoloviNodeStore.DodajStol(entryOznaka.Text, spinbuttonBrojStolica.ValueAsInt);
					TreeIter iter;
					nodeviewStolovi.Model.IterNthChild(out iter, nodeviewStolovi.Model.IterNChildren() - 1);
					nodeviewStolovi.Selection.SelectIter(iter);
				} else { //Update
					stoloviNodeStore.UpdateStol(sn, entryOznaka.Text, spinbuttonBrojStolica.ValueAsInt);
				}
				hboxSpremljeno.Show();
				GLib.Timeout.Add(2000, () => { hboxSpremljeno.Hide(); return false; });
				return true;

			} catch(ArgumentException ae) {
				string msg;
				switch(ae.ParamName) {
				case "oznaka": msg = "Oznaka je obavezna."; break;
				case "brojStolica": msg = "Broj stolica mora biti veči od 0."; break;
				case "NewOznaka": msg = "Oznaka mora biti jedinstvena."; break;
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
			if(entrySearch.Text == "") nodeviewStolovi.NodeStore = stoloviNodeStore;
			else {
				StolNodeStore sns = new StolNodeStore();

				foreach(StolNode sn in stoloviNodeStore) {
					if(sn.Oznaka.ToLower().Contains(entrySearch.Text.ToLower()))
						sns.AddNode(sn);
				}

				nodeviewStolovi.NodeStore = sns;
				nodeviewStolovi.Selection.SelectPath(new TreePath("0"));
			}
		}
	
	
	}
}
