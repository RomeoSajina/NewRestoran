using System;
using Gtk;
using Gdk;
namespace NewRestoran {
	
	public partial class StavkeWindow : Gtk.Window {

		ListStore dropdownStatusListStore = new ListStore(typeof(Pixbuf), typeof(string));
		private NarudzbeNode narudzba;
		private NarudzbeNodeStore narudzbaStore;
		private bool formPrikaz = false;

		public StavkeWindow(NarudzbeNode n, NarudzbeNodeStore ns, bool prikazi) : base(Gtk.WindowType.Toplevel) {
			this.Build();
			if(prikazi) this.Show();

			narudzba = n;
			narudzbaStore = ns;
			nodeviewStavke.NodeStore = n.stavkeNarudzbeNodeStore;

			CellRendererText statusText = new CellRendererText();
			CellRendererPixbuf statusPixbuf = new CellRendererPixbuf();

			TreeViewColumn statusColumn = new TreeViewColumn();
			statusColumn.Title = "Status";
			statusColumn.MinWidth = 100;
			statusColumn.PackStart(statusPixbuf, false);
			statusColumn.PackStart(statusText, true);
			statusColumn.AddAttribute(statusPixbuf, "pixbuf", 5);
			statusColumn.AddAttribute(statusText, "text", 6);

			nodeviewStavke.AppendColumn("Šifra", new CellRendererText(), "text", 0).MinWidth = 150;
			nodeviewStavke.AppendColumn("Naziv", new CellRendererText(), "text", 1).MinWidth = 200;
			nodeviewStavke.AppendColumn("Cijena", new CellRendererText(), "text", 2).MinWidth = 100;
			nodeviewStavke.AppendColumn("Količina", new CellRendererText(), "text", 3).MinWidth = 80;
			nodeviewStavke.AppendColumn("Ukupno", new CellRendererText(), "text", 4).MinWidth = 150;
			nodeviewStavke.AppendColumn(statusColumn);

			dropdownStatusListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.NaCekanju.png").ScaleSimple(20, 20, InterpType.Bilinear), "Na čekanju");
			dropdownStatusListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.UObradi.png").ScaleSimple(20, 20, InterpType.Bilinear), "U obradi");
			dropdownStatusListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Gotovo.png").ScaleSimple(20, 20, InterpType.Bilinear), "Gotovo");
			dropdownStatusListStore.AppendValues(Pixbuf.LoadFromResource("NewRestoran.images.Dostavljeno.png").ScaleSimple(20, 20, InterpType.Bilinear), "Dostavljeno");

			comboboxStatus.Model = dropdownStatusListStore;
			comboboxStatus.PackStart(statusPixbuf, false);
			comboboxStatus.PackStart(statusText, true);
			comboboxStatus.AddAttribute(statusPixbuf, "pixbuf", 0);
			comboboxStatus.AddAttribute(statusText, "text", 1);

			nodeviewStavke.NodeSelection.Changed += NodeSelectionChanged;
			comboboxSifraArtikla.Model = ArtikliPresenter.ArtikliListStore;

			vboxFormView.Hide();

			this.Resize(500, 500);
			labelBrojNarudzbe.LabelProp = narudzba.Broj;
			labelUkupno.LabelProp = narudzba.Ukupno;
			if(!narudzba.HasStavke()) buttonDodajStavku.Click();

			Color c = new Color();
			Color.Parse("#00bd00", ref c);
			labelSpremljeno.ModifyFg(StateType.Normal, c);
			labelSpremljeno.ModifyFont(Pango.FontDescription.FromString("bold 16"));

			ForAll<Label>(l => l.ModifyFont(Pango.FontDescription.FromString("bold 10")), new Container[]{hbox2, hbox4, hbox5, hbox6, hbox7, hbox8, hbox9});
		}

		public Box GetContent() {
			this.Remove(hbox1);
			return hbox1;
		}
			                   
		public void NodeSelectionChanged(object sender, EventArgs e) {
			StavkaNarudzbeNode s = (nodeviewStavke.NodeSelection.SelectedNode as StavkaNarudzbeNode);
			if(s != null) {
				comboboxSifraArtikla.Active = ArtikliPresenter.GetIndex(s.Sifra);
				labelNazivArtikla.LabelProp = s.Naziv;
				labelCijenaArtikla.LabelProp = s.Cijena;
				spinbuttonKolicina.Value = int.Parse(s.Kolicina);
				labelUkupnoArtikla.LabelProp = (spinbuttonKolicina.ValueAsInt * float.Parse(s.Cijena, System.Globalization.NumberStyles.Any)).ToString("C");
				comboboxStatus.Active = StavkaNarudzbe.StatusGetIndex(s.Status);
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

		protected void OnButtonUpClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter, prev, temp;
				nodeviewStavke.Selection.GetSelected(out iter);
				nodeviewStavke.Model.GetIterFirst(out prev);

				do{
					temp = prev;
					nodeviewStavke.Model.IterNext(ref temp);
					if(temp.Equals(iter)) {
						nodeviewStavke.Selection.SelectIter(prev);
						break;
					}
				}while(nodeviewStavke.Model.IterNext(ref prev));

				nodeviewStavke.Selection.SelectIter(prev);
			
			}else { 
				GtkScrolledWindowStavke.Vadjustment.Value -= 150;
			}
		}

		protected void OnButtonDownClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter;
				nodeviewStavke.Selection.GetSelected(out iter);

				if(!nodeviewStavke.Model.IterNext(ref iter))
					nodeviewStavke.Model.GetIterFirst(out iter);

				nodeviewStavke.Selection.SelectIter(iter);
			} else {
				double max = GtkScrolledWindowStavke.Vadjustment.Upper - GtkScrolledWindowStavke.Vadjustment.PageSize;

				if(GtkScrolledWindowStavke.Vadjustment.Value + 150 > max)
					GtkScrolledWindowStavke.Vadjustment.Value = max;
				else
					GtkScrolledWindowStavke.Vadjustment.Value += 150;
			}
		}

		protected void OnButtonDodajStavkuClicked(object sender, EventArgs e) {
			comboboxSifraArtikla.Active = -1;
			spinbuttonKolicina.Value = 1;
			comboboxStatus.Active = 0;
			labelUkupnoArtikla.LabelProp = "0,00 kn";
			labelNazivArtikla.LabelProp = "";
			labelCijenaArtikla.LabelProp = "";
			nodeviewStavke.Selection.UnselectAll();
			if(!formPrikaz) buttonChange.Click();
			comboboxSifraArtikla.Popup();

		}

		protected void OnButtonSpremiClicked(object sender, EventArgs e) {
			SpremiPromjene();
		}

		protected bool SpremiPromjene() { 
			StavkaNarudzbeNode ns = (nodeviewStavke.NodeSelection.SelectedNode as StavkaNarudzbeNode);
			try {
				if(ns == null) { //Insert
					narudzba.DodajStavku(comboboxSifraArtikla.ActiveText, spinbuttonKolicina.ValueAsInt, comboboxStatus.Active);
					TreeIter iter;
					nodeviewStavke.Model.IterNthChild(out iter, nodeviewStavke.Model.IterNChildren() - 1);
					nodeviewStavke.Selection.SelectIter(iter);
				} else { //Update
					narudzba.UpdateStavku(ns, comboboxSifraArtikla.ActiveText, spinbuttonKolicina.ValueAsInt, comboboxStatus.Active);
				}
				labelUkupno.LabelProp = narudzba.Ukupno;
				hboxSpremljeno.Show();
				GLib.Timeout.Add(2000, () => { hboxSpremljeno.Hide(); return false; });
				return true;

			} catch(ArgumentException ae) {
				string msg;
				switch(ae.ParamName) {
				case "artiklStavke":
				case "artikl": msg = "Šifra artikla mora biti odabrana"; break;
				case "kolicina": msg = "Količina mora biti veća od 0"; break;
				case "sifra": msg = "Stavka sa odabranim artiklom već postoji."; break;
				default: msg = ae.Message; break;
				}
				DialogBox.ShowError(this, msg);
				return false;
			} catch(System.Data.Common.DbException sqle) {
				string msg;
				switch(sqle.ErrorCode) {
					case -2147467259: msg = "Stavka sa odabranim artiklom već postoji.Sql"; break;
					default: msg = sqle.Message; break;
				}
				DialogBox.ShowError(this, msg);
				return false;
			}
		}

		protected void OnButtonOdustaniClicked(object sender, EventArgs e) {
			buttonDodajStavku.Click();
			buttonChange.Click();
		}

		protected void OnSpinbuttonKolicinaValueChanged(object sender, EventArgs e) {
			if(!labelCijenaArtikla.LabelProp.Equals(""))	 
				labelUkupnoArtikla.LabelProp = (spinbuttonKolicina.ValueAsInt * float.Parse(labelCijenaArtikla.LabelProp, System.Globalization.NumberStyles.Any)).ToString("C");
		}

		protected void OnComboboxSifraArtiklaChanged(object sender, EventArgs e) {
			string naziv, cijena, ukupno;
			ArtikliPresenter.ArtiklDetails(comboboxSifraArtikla.ActiveText, spinbuttonKolicina.ValueAsInt, out naziv, out cijena, out ukupno);
			labelNazivArtikla.LabelProp = naziv;
			labelCijenaArtikla.LabelProp = cijena;
			labelUkupnoArtikla.LabelProp = ukupno;
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e) {
			StavkaNarudzbeNode ns = (nodeviewStavke.NodeSelection.SelectedNode as StavkaNarudzbeNode);
			if(ns != null)
				narudzba.IzbrisiStavku(ns);
		}

		protected void OnButtonBackAndSaveClicked(object sender, EventArgs e) {
			if((nodeviewStavke.NodeSelection.SelectedNode as StavkaNarudzbeNode) == null) {
				if(comboboxSifraArtikla.Active > -1) {
					if(SpremiPromjene())
						this.Destroy();
				} else this.Destroy();

			} else if(SpremiPromjene())
						this.Destroy();
			
		}

		protected void OnButtonZakljuciClicked(object sender, EventArgs e) {
			narudzba.Zakljuci();
			narudzbaStore.RemoveNode(narudzba);
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
			if(entrySearch.Text == "") nodeviewStavke.NodeStore = narudzba.stavkeNarudzbeNodeStore;
			 else {
				StavkaNarudzbeNodeStore nsns = new StavkaNarudzbeNodeStore();

				foreach(StavkaNarudzbeNode nsn in narudzba.stavkeNarudzbeNodeStore) {
					if(nsn.Sifra.ToLower().Contains(entrySearch.Text.ToLower()) || nsn.Naziv.ToLower().Contains(entrySearch.Text.ToLower()))
						nsns.AddNode(nsn);
				}

				nodeviewStavke.NodeStore = nsns;
				nodeviewStavke.Selection.SelectPath(new TreePath("0"));
			}
		}
	
	
	}
}
