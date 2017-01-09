using System;
using Gtk;
using Gdk;
using System.Collections.Generic;
namespace NewRestoran {
	public partial class MainWindow : Gtk.Window {

		public NarudzbeNodeStore narudzbeNodeStore;
		public StavkaNarudzbeNodeStore current;
		private bool prikazStatusSve = true;
		private bool formPrikaz = false;
		public Zaposlenik Zaposlenik { get; set; }

		public delegate void Changed();
		public static Changed stavkeChanged;
		public static Changed stolChanged;

		public MainWindow() : base (Gtk.WindowType.Toplevel) {
			this.Build ();
			DB.OpenConnection();

			LoginWindow login = new LoginWindow(this);

			stavkeChanged += () => RefreshStatusNodeView();

			narudzbeNodeStore = new NarudzbeNodeStore(true);
			current = new StavkaNarudzbeNodeStore();

			fixedrestoransheme.HideToolbox ();
			notebookMain.CurrentPage = 0;

			entrySearch.Changed += (sender, e) => entrySearchForm.Text = entrySearch.Text;
			entrySearchForm.Changed += (sender, e) => entrySearch.Text = entrySearchForm.Text;

			//NodeView za prikaz narudžbi
			nodeviewNarudzbe.AppendColumn("Broj narudžbe", new CellRendererText(), "text", 0).MinWidth = 200;
			nodeviewNarudzbe.AppendColumn ("Datum", new CellRendererText (), "text", 1).MinWidth = 150;
			nodeviewNarudzbe.AppendColumn ("Oznaka stola", new CellRendererText (), "text", 2).MinWidth = 100;
			nodeviewNarudzbe.AppendColumn ("Ukupno", new CellRendererText (), "text", 3).MinWidth = 100;
			nodeviewNarudzbe.NodeStore = narudzbeNodeStore;

			//NodeView za prikaz statusa stavaka narudzbi
			CellRendererText statusText = new CellRendererText ();
			CellRendererPixbuf statusPixbuf = new CellRendererPixbuf ();

			TreeViewColumn statusColumn = new TreeViewColumn ();
			statusColumn.Title = "Status";
			statusColumn.MinWidth = 100;
			statusColumn.PackStart (statusPixbuf, false);
			statusColumn.PackStart (statusText, true);
			statusColumn.AddAttribute (statusPixbuf, "pixbuf", 5);
			statusColumn.AddAttribute (statusText, "text", 6);

			nodeviewNarudzbeStatus.AppendColumn ("Šifra artikla", new CellRendererText (), "text", 0).MinWidth = 150;
			nodeviewNarudzbeStatus.AppendColumn ("Naziv artikla", new CellRendererText (), "text", 1).MinWidth = 150;
			nodeviewNarudzbeStatus.AppendColumn ("Količina", new CellRendererText (), "text", 3).MinWidth = 70;
			nodeviewNarudzbeStatus.AppendColumn ("Oznaka stola", new CellRendererText (), "text", 7).MinWidth = 100;
			nodeviewNarudzbeStatus.AppendColumn (statusColumn);

			//Odabir prikaza stavaka prema statusu ili sve
			ListStore dropdownStatusListStore = new ListStore (typeof (Pixbuf), typeof (string));
			dropdownStatusListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.SveAktivne.png").ScaleSimple (20, 20, InterpType.Bilinear), "Sve aktivne");
			dropdownStatusListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.NaCekanju.png").ScaleSimple (20, 20, InterpType.Bilinear), "Na čekanju");
			dropdownStatusListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.UObradi.png").ScaleSimple (20, 20, InterpType.Bilinear), "U obradi");
			dropdownStatusListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Gotovo.png").ScaleSimple (20, 20, InterpType.Bilinear), "Gotovo");
			dropdownStatusListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Dostavljeno.png").ScaleSimple (20, 20, InterpType.Bilinear), "Dostavljeno");
			dropdownStatusListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Sve.png").ScaleSimple (20, 20, InterpType.Bilinear), "Sve");

			comboboxStatus.Model = dropdownStatusListStore;
			comboboxStatus.PackStart (statusPixbuf, false);
			comboboxStatus.PackStart (statusText, true);
			comboboxStatus.AddAttribute (statusPixbuf, "pixbuf", 0);
			comboboxStatus.AddAttribute (statusText, "text", 1);
			comboboxStatus.Active = 0;

			//Odabir prikaza statusa stavaka svih ili trenutne narudzbe
			ListStore dropdownSveTrenutnoListStore = new ListStore (typeof (Pixbuf), typeof (string));
			dropdownSveTrenutnoListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Sve.png").ScaleSimple (20, 20, InterpType.Bilinear), "Sve");
			dropdownSveTrenutnoListStore.AppendValues (Pixbuf.LoadFromResource ("NewRestoran.images.Selected.png").ScaleSimple (20, 20, InterpType.Bilinear), "Pojedinačno");

			CellRendererText sveTrenutnoText = new CellRendererText ();
			CellRendererPixbuf sveTrenutnoPixbuf = new CellRendererPixbuf ();

			comboboxSveTrenutna.Model = dropdownSveTrenutnoListStore;
			comboboxSveTrenutna.PackStart (sveTrenutnoPixbuf, false);
			comboboxSveTrenutna.PackStart (sveTrenutnoText, true);
			comboboxSveTrenutna.AddAttribute (sveTrenutnoPixbuf, "pixbuf", 0);
			comboboxSveTrenutna.AddAttribute (sveTrenutnoText, "text", 1);
			comboboxSveTrenutna.Active = 0;

			CellRendererText stolText = new CellRendererText();
			CellRendererPixbuf stolPixbuf = new CellRendererPixbuf();
			comboboxOznakaStola.PackStart(stolPixbuf, false);
			comboboxOznakaStola.PackStart(stolText, true);
			comboboxOznakaStola.AddAttribute(stolPixbuf, "pixbuf", 0);
			comboboxOznakaStola.AddAttribute(stolText, "text", 1);
			Pixbuf table2chairs = Pixbuf.LoadFromResource("NewRestoran.images.table2chairs.png").ScaleSimple(20, 20, InterpType.Bilinear);
			Pixbuf table4chairs = Pixbuf.LoadFromResource("NewRestoran.images.table4chairs.png").ScaleSimple(20, 20, InterpType.Bilinear);
			Pixbuf table6chairs = Pixbuf.LoadFromResource("NewRestoran.images.table6chairs.png").ScaleSimple(20, 20, InterpType.Bilinear);
			Pixbuf table8chairs = Pixbuf.LoadFromResource("NewRestoran.images.table8chairs.png").ScaleSimple(20, 20, InterpType.Bilinear);


			//Prikazivanje ili sakrivanje gumbova ovisno o fokusu
			vboxStatusButtons.Hide ();
			vboxNarudzbeButtons.Hide ();
			nodeviewNarudzbe.FocusInEvent += (o, args) => { vboxNarudzbeButtons.Show ();};
			nodeviewNarudzbe.FocusOutEvent += (o, args) => {  vboxNarudzbeButtons.Hide (); };
			nodeviewNarudzbeStatus.FocusInEvent += (o, args) => { vboxStatusButtons.Show (); };
			nodeviewNarudzbeStatus.FocusOutEvent += (o, args) => { vboxStatusButtons.Hide (); };
			nodeviewNarudzbe.Selection.Changed += NodeSelectionChanged;


			this.Resize(1400, 970);
			Color c = new Color();
			Color.Parse("#00bd00", ref c);
			labelSpremljen.ModifyFg(StateType.Normal, c);
			labelSpremljen.ModifyFont(Pango.FontDescription.FromString("bold 16"));

			ForAll<Label>(l => l.ModifyFont(Pango.FontDescription.FromString("bold 10")), new Container[] { hbox8, hbox9, hbox10, hbox11 });
			notebookMain.ShowTabs = false;

			
			stolChanged += () => {
				ListStore stolOznaka = new ListStore(typeof(Pixbuf), typeof(string));
				StoloviPresenter.stoloviList.ForEach(s => {
					switch(s.BrojStolica) {
						case 2: stolOznaka.AppendValues(table2chairs, s.Oznaka); break;
						case 4: stolOznaka.AppendValues(table4chairs, s.Oznaka); break;
						case 6: stolOznaka.AppendValues(table6chairs, s.Oznaka); break;
						case 8: stolOznaka.AppendValues(table8chairs, s.Oznaka); break;
						default: stolOznaka.AppendValues(null, s.Oznaka); break;
					}
				});	
				comboboxOznakaStola.Model = stolOznaka;

				fixedrestoransheme.RefreshComboBox(StoloviPresenter.GetOznake());
			};
			stolChanged();

			RefreshStatusNodeView();
			fixedrestoransheme.TableSelected += FixedRestoranShemeTableSelected;
		}

		protected void NodeSelectionChanged(object sender, EventArgs e) {
			if(!prikazStatusSve)
				RefreshStatusNodeView();
			
			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(n != null) {
				fixedrestoransheme.TableSelected -= FixedRestoranShemeTableSelected;
				fixedrestoransheme.SelectTable(n.OznakaStola);
				fixedrestoransheme.TableSelected += FixedRestoranShemeTableSelected;

				labelBroj.LabelProp = n.Broj;
				labelDatum.LabelProp = n.Datum;
				comboboxOznakaStola.Active = StoloviPresenter.stoloviList.FindIndex(s => s.Oznaka == n.OznakaStola);
				labelUkupno.LabelProp = n.Ukupno;
			}
		}

		public void OnDeleteEvent(object sender, DeleteEventArgs a) {
			DB.CloseConnection();
			Application.Quit ();
			a.RetVal = true;
		}

		//Button dodaj narudžbu 
		protected void OnButtonDodajClicked(object sender, EventArgs e) {
			narudzbeNodeStore.DodajNarudzbu ();
			TreeIter iter;
			nodeviewNarudzbe.Model.IterNthChild(out iter, nodeviewNarudzbe.Model.IterNChildren() - 1);
			nodeviewNarudzbe.Selection.SelectIter(iter);
		}

		//Button scroll up
		protected void OnButtonNarudzbeUpClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter, prev, temp;
				nodeviewNarudzbe.Selection.GetSelected(out iter);
				nodeviewNarudzbe.Model.GetIterFirst(out prev);

				do {
					temp = prev;
					nodeviewNarudzbe.Model.IterNext(ref temp);
					if(temp.Equals(iter)) {
						nodeviewNarudzbe.Selection.SelectIter(prev);
						break;
					}
				} while(nodeviewNarudzbe.Model.IterNext(ref prev));

				nodeviewNarudzbe.Selection.SelectIter(prev);

			} else GtkScrolledWindowNarudzbe.Vadjustment.Value -= 150;
		}

		//Button scroll down
		protected void OnButtonNarudzbeDownClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				TreeIter iter;
				nodeviewNarudzbe.Selection.GetSelected(out iter);

				if(!nodeviewNarudzbe.Model.IterNext(ref iter))
					nodeviewNarudzbe.Model.GetIterFirst(out iter);

				nodeviewNarudzbe.Selection.SelectIter(iter);
			} else {
				double max = GtkScrolledWindowNarudzbe.Vadjustment.Upper - GtkScrolledWindowNarudzbe.Vadjustment.PageSize;

				if(GtkScrolledWindowNarudzbe.Vadjustment.Value + 150 > max)
					GtkScrolledWindowNarudzbe.Vadjustment.Value = max;
				else
					GtkScrolledWindowNarudzbe.Vadjustment.Value += 150;
			}
		}

		protected void OnButtonDeleteNarudzbaClicked(object sender, EventArgs e) {
			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(n != null && n.HasStavke()) {
				if(DialogBox.ShowDaNeQuestion(this, "Narudžba sadrži stavke koje će se obrisati brisanjem narudzbe, želite li nastaviti?")) {
					narudzbeNodeStore.IzbrisiNarudzbu(n);
					ClearForm();
				}
			} else if(n != null) { 
				narudzbeNodeStore.IzbrisiNarudzbu(n);
				ClearForm();
			}
		}

		protected void OnButtonStavkeClicked(object sender, EventArgs e) {
			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(n == null) return;
			switch(Open(1)) {
			case 0:
				StavkeWindow sw = new StavkeWindow(n, narudzbeNodeStore, false);
				sw.Destroyed += (o, args) => { notebookMain.Page = 0; };

				boxStavke.Foreach(box => boxStavke.Remove(box));
				boxStavke.Add(sw.GetContent());
				break;
				case 1: StavkeWindow s = new StavkeWindow(n, narudzbeNodeStore, true); break;
			case 2: break;
			}
			nodeviewNarudzbe.NodeSelection.SelectedNode.Changed += (o, a) => { labelUkupno.LabelProp = (o as NarudzbeNode).Ukupno; };
		}

		protected void OnButtonZakljuciClicked(object sender, EventArgs e) {
			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(n != null) {
				n.Zakljuci();
				narudzbeNodeStore.RemoveNode(n);
				ClearForm();
			}
		}

		protected void OnButtonNarudzbeChangeClicked(object sender, EventArgs e) {
			if(formPrikaz) {
				vboxNodeViewPrikaz.Show();
				vboxFormPrikaz.Hide();
				nodeviewNarudzbe.GrabFocus();
				formPrikaz = false;
			} else {
				vboxNodeViewPrikaz.Hide();
				vboxFormPrikaz.Show();
				vboxNarudzbeButtons.Show();
				formPrikaz = true;
			}
		}

		private void ClearForm(){
			labelBroj.LabelProp = "";
			labelDatum.LabelProp = "";
			comboboxOznakaStola.Active = 0;
			labelUkupno.LabelProp = "";
		}

		protected void OnButtonStatusUpClicked(object sender, EventArgs e) {
			GtkScrolledWindowStatusStavaka.Vadjustment.Value -= 150;
		}

		protected void OnButtonStatusDownClicked(object sender, EventArgs e) {
			double max = GtkScrolledWindowStatusStavaka.Vadjustment.Upper - GtkScrolledWindowStatusStavaka.Vadjustment.PageSize;

			if(GtkScrolledWindowStatusStavaka.Vadjustment.Value + 150 > max)
				GtkScrolledWindowStatusStavaka.Vadjustment.Value = max;
			else
				GtkScrolledWindowStatusStavaka.Vadjustment.Value += 150;
		}

		protected void OnButtonUpdateStatusClicked(object sender, EventArgs e) {
			StavkaNarudzbeNode ns = (nodeviewNarudzbeStatus.NodeSelection.SelectedNode as StavkaNarudzbeNode);
			if(ns != null) {
				switch((sender as Button).Name) {
					case "buttonTakeOrder": ns.UpdateStatus(StavkaNarudzbe.StatusStavke.UObradi); break;
					case "buttonFinishOrder": ns.UpdateStatus(StavkaNarudzbe.StatusStavke.Gotovo); break;
					case "buttonDeliver": ns.UpdateStatus(StavkaNarudzbe.StatusStavke.Dostavljeno); break;
				}
				RefreshStatusNodeView();
				nodeviewNarudzbeStatus.GrabFocus();
				foreach(StavkaNarudzbeNode nsn in nodeviewNarudzbeStatus.NodeStore) {
					if(nsn == ns) {
						nodeviewNarudzbeStatus.NodeSelection.SelectNode(ns);
						break;
					}
				} 
			}
		}

		protected void OnComboboxStatusChanged(object sender, EventArgs e) { RefreshStatusNodeView(); }

		protected void RefreshStatusNodeView() { 
			if(prikazStatusSve) {
				switch(comboboxStatus.Active) {
				case 0: PrikaziStatus(StavkaNarudzbe.StatusStavke.Dostavljeno, true); break;
				case 1: PrikaziStatus(StavkaNarudzbe.StatusStavke.NaCekanju); break;
				case 2: PrikaziStatus(StavkaNarudzbe.StatusStavke.UObradi); break;
				case 3: PrikaziStatus(StavkaNarudzbe.StatusStavke.Gotovo); break;
				case 4: PrikaziStatus(StavkaNarudzbe.StatusStavke.Dostavljeno); break;
				case 5: PrikaziStatus(); break;
				}
			}

			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(!prikazStatusSve && n != null) {
				switch(comboboxStatus.Active) {
				case 0: PrikaziStatus(StavkaNarudzbe.StatusStavke.Dostavljeno, n.stavkeNarudzbeNodeStore, true); break;
				case 1: PrikaziStatus(StavkaNarudzbe.StatusStavke.NaCekanju); break;
				case 2: PrikaziStatus(StavkaNarudzbe.StatusStavke.UObradi); break;
				case 3: PrikaziStatus(StavkaNarudzbe.StatusStavke.Gotovo); break;
				case 4: PrikaziStatus(StavkaNarudzbe.StatusStavke.Dostavljeno); break;
				case 5: nodeviewNarudzbeStatus.NodeStore = n.stavkeNarudzbeNodeStore; break;
				}
			}
		}

		protected void PrikaziStatus() { 
			current.Clear();
			foreach(NarudzbeNode n in nodeviewNarudzbe.NodeStore) {
				foreach(StavkaNarudzbeNode ns in n.stavkeNarudzbeNodeStore) {
					current.AddNode(ns);
				}
			}
			nodeviewNarudzbeStatus.NodeStore = current;
		}

		protected void PrikaziStatus(StavkaNarudzbe.StatusStavke s, StavkaNarudzbeNodeStore nsns, bool prikaziOsimS = false) { 
			current.Clear();
			if(!prikaziOsimS) {
				foreach(StavkaNarudzbeNode ns in nsns) {
					if(ns.Status == s) current.AddNode(ns);
				}

			} else {
				foreach(StavkaNarudzbeNode ns in nsns) {
					if(ns.Status != s) current.AddNode(ns);
				}
			}
			nodeviewNarudzbeStatus.NodeStore = current;
		}

 		protected void PrikaziStatus(StavkaNarudzbe.StatusStavke s, bool prikaziOsimS = false) {
			current.Clear();
			if(!prikaziOsimS) {
				foreach(NarudzbeNode n in nodeviewNarudzbe.NodeStore) {
					foreach(StavkaNarudzbeNode ns in n.stavkeNarudzbeNodeStore) {
						if(ns.Status == s) current.AddNode(ns);
					}
				}
			} else { 
				foreach(NarudzbeNode n in nodeviewNarudzbe.NodeStore) {
					foreach(StavkaNarudzbeNode ns in n.stavkeNarudzbeNodeStore) {
						if(ns.Status != s) current.AddNode(ns);
					}
				}
			}
			nodeviewNarudzbeStatus.NodeStore = current;
		}

		protected void OnComboboxSveTrenutnaChanged(object sender, EventArgs e) {
			switch(comboboxSveTrenutna.Active) {
				case 0: prikazStatusSve = true; break;
				case 1: prikazStatusSve = false; break;
			}
			RefreshStatusNodeView();
		}

		protected void FixedRestoranShemeTableSelected(string name) {
			foreach(NarudzbeNode n in nodeviewNarudzbe.NodeStore) {
				if(n.OznakaStola == name) {
					nodeviewNarudzbe.NodeSelection.SelectNode(n);
					nodeviewNarudzbe.GrabFocus();
					return;
				}
			}
		}

		protected void OnButtonOdustaniClicked(object sender, EventArgs e) {
			NodeSelectionChanged(new object(), new EventArgs());
			buttonNarudzbeChange.Click();
		}

		protected void OnButtonSpremiClicked(object sender, EventArgs e) {
		 	NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(n != null) {
				try {
					n.Update(comboboxOznakaStola.Active);
				} catch(ArgumentException ae) {
					DialogBox.ShowError(this, ae.Message);
				}
				hboxSpremljen.Show();
				GLib.Timeout.Add(2000, () => { hboxSpremljen.Hide(); return false; });
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

		protected int Open(int page) {
			if(!windowAction.Active && notebookMain.Page != page) {
				notebookMain.Page = page;
				return 0;
			} else if(windowAction.Active) {
				notebookMain.Page = 0;
				return 1;
			}
			return 2;
		}

		protected void OnArtikliActionActivated(object sender, EventArgs e) {
			switch(Open(2)) {
			case 0:
				ArtikliWindow aw = new ArtikliWindow(false);
				aw.Destroyed += (o, args) => { notebookMain.Page = 0; };

				boxArtikli.Foreach(box => boxArtikli.Remove(box));
				boxArtikli.Add(aw.GetContent());
			break;
			case 1: ArtikliWindow a = new ArtikliWindow(true); break;
			case 2: break;
			}
		}

		protected void OnStoloviActionActivated(object sender, EventArgs e) {
			switch(Open(4)) {
				case 0: 
				StoloviWindow sw = new StoloviWindow(false);
					sw.Destroyed += (o, args) => { notebookMain.Page = 0; };

					boxStolovi.Foreach(box => boxStolovi.Remove(box));
					boxStolovi.Add(sw.GetContent()); 
				break;
				case 1: StoloviWindow s = new StoloviWindow(true); break;
				case 2: break;
			}

		}

		protected void OnZaposleniciActionActivated(object sender, EventArgs e) {
			if(Zaposlenik.Uloga != Zaposlenik.UlogaZaposlenik.Sef) return;
			switch(Open(3)) {
				case 0: 
					ZaposleniciWindow zw = new ZaposleniciWindow(false);
					zw.Destroyed += (o, args) => { notebookMain.Page = 0; };

					boxZaposlenici.Foreach(box => boxZaposlenici.Remove(box));
					boxZaposlenici.Add(zw.GetContent());
				break;
				case 1: ZaposleniciWindow z = new ZaposleniciWindow(true); break;
				case 2: break;
			}
		}

		protected void OnQuitActionActivated(object sender, EventArgs e) {
			this.OnDeleteEvent(sender, new DeleteEventArgs()); 
		}

		protected void OnSingOutActionActivated(object sender, EventArgs e) {
			Zaposlenik = null;
			LoginWindow l = new LoginWindow(this);
		}

		protected void OnHomeActionActivated(object sender, EventArgs e) { notebookMain.Page = 0; }

		protected void OnButtonSearchClicked(object sender, EventArgs e) {
			if(entrySearch.Text == "") nodeviewNarudzbe.NodeStore = narudzbeNodeStore;
			else {
				NarudzbeNodeStore nsn = new NarudzbeNodeStore(false);

				foreach(NarudzbeNode n in narudzbeNodeStore) {
					if(n.Broj.Contains(entrySearch.Text))
						nsn.AddNode(n);
				}
				nodeviewNarudzbe.NodeStore = nsn;
				nodeviewNarudzbe.Selection.SelectPath(new TreePath("0"));
				RefreshStatusNodeView();
			}
		}


	}
}
