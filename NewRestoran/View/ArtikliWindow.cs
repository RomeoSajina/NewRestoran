using System;
using Gtk;
using Gdk;
namespace NewRestoran {
	public partial class ArtikliWindow : Gtk.Window {
		
		ArtiklNodeStore artikliNodeStore = new ArtiklNodeStore();
		private bool formPrikaz = false;

		public ArtikliWindow(bool visible) : base (Gtk.WindowType.Toplevel) {
			this.Build ();
			if(visible) Show();

			CellRendererPixbuf oznakaPixbufCell = new CellRendererPixbuf();
			CellRendererText oznakaTextCell = new CellRendererText ();

			TreeViewColumn oznakaColumn = new TreeViewColumn ();
			oznakaColumn.Title = "Oznaka";
			oznakaColumn.MinWidth = 100;
			oznakaColumn.PackStart (oznakaPixbufCell, false);
			oznakaColumn.PackStart (oznakaTextCell, true);
			oznakaColumn.AddAttribute (oznakaPixbufCell, "pixbuf", 5);
			oznakaColumn.AddAttribute (oznakaTextCell, "text", 6);

			nodeviewArtikli.AppendColumn ("Šifra", new CellRendererText(), "text", 0).MinWidth = 100;
			nodeviewArtikli.AppendColumn ("Naziv", new CellRendererText(), "text", 1).MinWidth = 100;
			nodeviewArtikli.AppendColumn ("Duži naziv", new CellRendererText(), "text", 2).MinWidth = 200;
			nodeviewArtikli.AppendColumn ("Sastav", new CellRendererText(), "text", 3).MinWidth = 250;
			nodeviewArtikli.AppendColumn ("Cijena", new CellRendererText(), "text", 4).MinWidth = 100;
			nodeviewArtikli.AppendColumn (oznakaColumn);

			nodeviewArtikli.NodeStore = artikliNodeStore;

			ListStore dropdownOznakaListStore = new ListStore(typeof(Pixbuf), typeof(string));
			dropdownOznakaListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Hrana.png").ScaleSimple(20, 20, InterpType.Bilinear), "Hrana");
			dropdownOznakaListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Pice.png").ScaleSimple(20, 20, InterpType.Bilinear), "Piće");
			dropdownOznakaListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Desert.png").ScaleSimple(20, 20, InterpType.Bilinear), "Desert");
			dropdownOznakaListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Ostalo.png").ScaleSimple(20, 20, InterpType.Bilinear), "Ostalo");

			comboboxOznaka.Model = dropdownOznakaListStore;
			comboboxOznaka.PackStart (oznakaPixbufCell, false);
			comboboxOznaka.PackStart (oznakaTextCell, true);
			comboboxOznaka.AddAttribute (oznakaPixbufCell, "pixbuf",0);
			comboboxOznaka.AddAttribute (oznakaTextCell, "text", 1);

			nodeviewArtikli.Selection.Changed += SelectedNodeChanged;

			artikliNodeStore.AddList(ArtikliPresenter.Artikli);
			this.Resize(500, 500);

			Color c = new Color();
			Color.Parse("#00bd00", ref c);
			labelSpremljeno.ModifyFg(StateType.Normal, c);
			labelSpremljeno.ModifyFont(Pango.FontDescription.FromString("bold 16"));
			ForAll<Label>(l => l.ModifyFont(Pango.FontDescription.FromString("bold 10")), new Container[] { hbox1, hbox3, hbox4, hbox5, hbox6, hbox7 });
			nodeviewArtikli.GrabFocus();
		}

		public Box GetContent() {
			this.Remove (hbox2);
			return hbox2;
		}

		protected void SelectedNodeChanged(object sender, EventArgs e) {
			ArtiklNode a = (nodeviewArtikli.NodeSelection.SelectedNode as ArtiklNode);
			if(a != null) { 
				entrySifra.Text = a.Sifra;
				entryNaziv.Text = a.Naziv;
				entryDuziNaziv.Text = a.DuziNaziv;
				entrySastav.Text = a.Sastav;
				spinbuttonCijena.Value = float.Parse(a.Cijena, System.Globalization.NumberStyles.Any);
				comboboxOznaka.Active = Artikl.OznakaGetIndex(a.Oznaka);
			}
		}

		protected void OnButtonDodajArtiklClicked(object sender, EventArgs e) {
			IsprazniFormu();
			nodeviewArtikli.Selection.UnselectAll();
			if(!formPrikaz) buttonChange.Click();
		}
		protected void IsprazniFormu() { 
			entrySifra.Text = "";
			entryNaziv.Text = "";
			entryDuziNaziv.Text = "";
			entrySastav.Text = "";
			spinbuttonCijena.Value = 0;
			comboboxOznaka.Active = -1;
		}

		protected void OnButtonUpClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter, prev, temp;
				nodeviewArtikli.Selection.GetSelected(out iter);
				nodeviewArtikli.Model.GetIterFirst(out prev);

				do {
					temp = prev;
					nodeviewArtikli.Model.IterNext(ref temp);
					if(temp.Equals(iter)) {
						nodeviewArtikli.Selection.SelectIter(prev);
						break;
					}
				} while(nodeviewArtikli.Model.IterNext(ref prev));

				nodeviewArtikli.Selection.SelectIter(prev);

			} else {
				GtkScrolledWindowArtikli.Vadjustment.Value -= 150;
			}
		}

		protected void OnButtonDownClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter;
				nodeviewArtikli.Selection.GetSelected(out iter);

				if(!nodeviewArtikli.Model.IterNext(ref iter))
					nodeviewArtikli.Model.GetIterFirst(out iter);

				nodeviewArtikli.Selection.SelectIter(iter);
			} else {
				double max = GtkScrolledWindowArtikli.Vadjustment.Upper - GtkScrolledWindowArtikli.Vadjustment.PageSize;

				if(GtkScrolledWindowArtikli.Vadjustment.Value + 150 > max)
					GtkScrolledWindowArtikli.Vadjustment.Value = max;
				else
					GtkScrolledWindowArtikli.Vadjustment.Value += 150;
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
			ArtiklNode an = nodeviewArtikli.NodeSelection.SelectedNode as ArtiklNode;
			if(an != null) {
				artikliNodeStore.IzbrisiArtikl(an);
				IsprazniFormu();
			}
		}

		protected void OnButtonBackAndSaveClicked(object sender, EventArgs e) {
			if((nodeviewArtikli.NodeSelection.SelectedNode as ArtiklNode) == null) {
				if(entrySifra.Text != "" || entryNaziv.Text != "" || entrySastav.Text != "") {
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
			buttonDodajArtikl.Click();
			buttonChange.Click();
		}

		protected bool SpremiPromjene() {
			ArtiklNode an = (nodeviewArtikli.NodeSelection.SelectedNode as ArtiklNode);
			try {
				if(an == null) { //Insert
					artikliNodeStore.DodajArtikl(entrySifra.Text, entryNaziv.Text, entryDuziNaziv.Text, entrySastav.Text, (float)spinbuttonCijena.Value, comboboxOznaka.Active);
					TreeIter iter;
					nodeviewArtikli.Model.IterNthChild(out iter, nodeviewArtikli.Model.IterNChildren() - 1);
					nodeviewArtikli.Selection.SelectIter(iter);
				} else { //Update
					artikliNodeStore.UpdateArtikl(an, entrySifra.Text, entryNaziv.Text, entryDuziNaziv.Text, entrySastav.Text, (float)spinbuttonCijena.Value, comboboxOznaka.Active);
				}
				hboxSpremljeno.Show();
				GLib.Timeout.Add(2000, () => { hboxSpremljeno.Hide(); return false; });
				return true;

			} catch(ArgumentException ae) {
				string msg;
				switch(ae.ParamName) {
				case "sifra": msg = "Šifra artikla je obavezna."; break;
				case "naziv": msg = "Naziv artikla je obavezan."; break;
				case "sastav": msg = "Sastav artikla je obavezan."; break;
				case "cijena": msg = "Cijena artikla je obavezna."; break;
				case "NewSifra": msg = "Šifra mora biti jedinstvena."; break;
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
			if(entrySearch.Text == "") nodeviewArtikli.NodeStore = artikliNodeStore;
			else {
				ArtiklNodeStore ans = new ArtiklNodeStore();

				foreach(ArtiklNode a in artikliNodeStore) {
					if(a.Sifra.ToLower().Contains(entrySearch.Text.ToLower()) || a.Naziv.ToLower().Contains(entrySearch.Text.ToLower()))
						ans.AddNode(a);
				}

				nodeviewArtikli.NodeStore = ans;
				nodeviewArtikli.Selection.SelectPath(new TreePath("0"));
			}
		}

	}
}
