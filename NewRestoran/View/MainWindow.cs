using System;
using Gtk;
using Gdk;
using CustomWidgetLibrary;
using System.Collections.Generic;
namespace NewRestoran {
	public partial class MainWindow : Gtk.Window {

		public NarudzbeNodeStore narudzbeNodeStore = new NarudzbeNodeStore();
		public static NarudzbaStavkaNodeStore statusStore = new NarudzbaStavkaNodeStore();
		public NarudzbaStavkaNodeStore current = new NarudzbaStavkaNodeStore();
		public static List<string> OznakaStolList = new List<string>();
		private bool prikazStatusSve = true;
		private bool formPrikaz = false;

		public delegate void StavkeChanged();
		public static StavkeChanged stavkeChanged;

		public MainWindow() : base (Gtk.WindowType.Toplevel) {
			this.Build ();
			fixedrestoransheme.HideToolbox ();
			notebookMain.CurrentPage = 0;
			//nodeviewNarudzbe.SearchEntry = entrySearch;

			//ArtikliWindow aw = new ArtikliWindow ();

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


			//Prikazivanje ili sakrivanje gumbova ovisno o fokusu
			vboxStatusButtons.Hide ();
			vboxNarudzbeButtons.Hide ();
			nodeviewNarudzbe.FocusInEvent += (o, args) => { vboxNarudzbeButtons.Show ();};
			nodeviewNarudzbe.FocusOutEvent += (o, args) => {  vboxNarudzbeButtons.Hide (); };
			nodeviewNarudzbeStatus.FocusInEvent += (o, args) => { vboxStatusButtons.Show (); };
			nodeviewNarudzbeStatus.FocusOutEvent += (o, args) => { vboxStatusButtons.Hide (); };
			nodeviewNarudzbe.Selection.Changed += NodeSelectionChanged;

			stavkeChanged += () => OnComboboxStatusChanged(new object(), new EventArgs());

			ArtikliPresenter.LoadFromDB();

			Color c = new Color();
			Color.Parse("#00bd00", ref c);
			labelSpremljeno.ModifyFg(StateType.Normal, c);
			labelSpremljeno.ModifyFont(Pango.FontDescription.FromString("bold 16"));

			ForAll<Label>(l => l.ModifyFont(Pango.FontDescription.FromString("bold 10")), new Container[] { hbox8, hbox9, hbox10, hbox11 });


			//Test podaci
			Stol s = new Stol("T1", 4);
			Stol s1 = new Stol("T2", 4);
			Stol s2 = new Stol("T3", 4);

			narudzbeNodeStore.Add (new Narudzba ("1", DateTime.Now, Narudzba.OznakaNarudzbe.Nepotvrdeno, s));
			narudzbeNodeStore.Add (new Narudzba ("2", DateTime.Now, Narudzba.OznakaNarudzbe.Nepotvrdeno, s1));
			narudzbeNodeStore.Add (new Narudzba ("3", DateTime.Now, Narudzba.OznakaNarudzbe.Nepotvrdeno));

			TreePath tp = new TreePath ("0");

			ArtikliPresenter.AddArtikl(new Artikl("sif1", "na1", "ads", 1f, "svasta nesto", Artikl.OznakaArtikla.Ostalo));
			ArtikliPresenter.AddArtikl(new Artikl("sif2", "na2", "ads", 40.3f, "svasta nesto", Artikl.OznakaArtikla.Ostalo));
			ArtikliPresenter.AddArtikl(new Artikl("sif3", "na3", "ads", 50f, "svasta nesto", Artikl.OznakaArtikla.Ostalo));
			ArtikliPresenter.AddArtikl(new Artikl("sifra", "na4", "ads", 21f, "svasta nesto", Artikl.OznakaArtikla.Ostalo));
			ArtikliPresenter.AddArtikl(new Artikl("sifra2", "na5", "ads", 20f, "svasta nesto", Artikl.OznakaArtikla.Ostalo));
			ArtikliPresenter.AddArtikl(new Artikl("s", "na6", "ads", 29.3f, "svasta nesto", Artikl.OznakaArtikla.Ostalo));

			NarudzbeNode nar = (narudzbeNodeStore.GetNode(tp) as NarudzbeNode);
			nar.DodajStavku("s", 5, 0);
			nar.DodajStavku("sifra2", 3, 1);
			nar.DodajStavku("sifra", 8, 2);
			nar.DodajStavku("sif3", 3, 3);
			nar.DodajStavku("sif2", 2, 3);

			fixedrestoransheme.AddComboBoxValue("");
			fixedrestoransheme.AddComboBoxValue("T1");
			fixedrestoransheme.AddComboBoxValue("T2");
			fixedrestoransheme.AddComboBoxValue("T3");

			OznakaStolList.Add("-");
			OznakaStolList.Add("T1");
			OznakaStolList.Add("T2");
			OznakaStolList.Add("T3");
			OznakaStolList.ForEach(ozn => comboboxOznakaStola.AppendText(ozn));

			OnComboboxStatusChanged(new object(), new EventArgs());
			FixedRestoranSheme.TableSelected += FixedRestoranShemeTableSelected;
		}

		protected void NodeSelectionChanged(object sender, EventArgs e) {
			if(!prikazStatusSve)
				OnComboboxStatusChanged(sender, e);
			
			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(n != null) {
				fixedrestoransheme.SelectTable(n.OznakaStola);
				labelBroj.LabelProp = n.Broj;
				labelDatum.LabelProp = n.Datum;
				comboboxOznakaStola.Active = OznakaStolList.FindIndex(ozn => ozn == n.OznakaStola);
				labelUkupno.LabelProp = n.Ukupno;
			}
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
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
			narudzbeNodeStore.IzbrisiNarudzbu(nodeviewNarudzbe.NodeSelection.SelectedNode);
			ClearForm();
		}

		protected void OnButtonStavkeClicked(object sender, EventArgs e) {
			StavkeWindow sw = new StavkeWindow((nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode),narudzbeNodeStore);
			nodeviewNarudzbe.NodeSelection.SelectedNode.Changed += (o, a) => { labelUkupno.LabelProp = (o as NarudzbeNode).Ukupno; };
		}

		protected void OnButtonZakljuciClicked(object sender, EventArgs e) {
			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			n.Zakljuci();
			narudzbeNodeStore.RemoveNode(n);
			ClearForm();
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

		protected void OnButtonTakeOrderClicked(object sender, EventArgs e) {
			NarudzbaStavkaNode ns = (nodeviewNarudzbeStatus.NodeSelection.SelectedNode as NarudzbaStavkaNode);
			if(ns != null) {
				//ns.SetStatus(NarudzbaStavka.StatusStavke.UObradi);
				ns.Status = NarudzbaStavka.StatusStavke.UObradi;
				nodeviewNarudzbeStatus.GrabFocus();
			}
		}

		protected void OnButtonFinishOrderClicked(object sender, EventArgs e) {
			NarudzbaStavkaNode ns = (nodeviewNarudzbeStatus.NodeSelection.SelectedNode as NarudzbaStavkaNode);
			if(ns != null) {
				//ns.SetStatus(NarudzbaStavka.StatusStavke.Gotovo);
				ns.Status = NarudzbaStavka.StatusStavke.Gotovo;
				nodeviewNarudzbeStatus.GrabFocus();
			}
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

		protected void OnButtonDeliverClicked(object sender, EventArgs e) {
			NarudzbaStavkaNode ns = (nodeviewNarudzbeStatus.NodeSelection.SelectedNode as NarudzbaStavkaNode);
			if(ns != null) {
				//ns.SetStatus(NarudzbaStavka.StatusStavke.Dostavljeno);
				ns.Status = NarudzbaStavka.StatusStavke.Dostavljeno;
				nodeviewNarudzbeStatus.GrabFocus();
			}
		}


		protected void OnComboboxStatusChanged(object sender, EventArgs e) {
			if(prikazStatusSve) {
				switch(comboboxStatus.Active) {
					case 0: PrikaziStatus(NarudzbaStavka.StatusStavke.Dostavljeno, statusStore, true); break;
					case 1: PrikaziStatus(NarudzbaStavka.StatusStavke.NaCekanju, statusStore); break;
					case 2: PrikaziStatus(NarudzbaStavka.StatusStavke.UObradi, statusStore); break;
					case 3: PrikaziStatus(NarudzbaStavka.StatusStavke.Gotovo, statusStore); break;
					case 4: PrikaziStatus(NarudzbaStavka.StatusStavke.Dostavljeno, statusStore); break;
					case 5: nodeviewNarudzbeStatus.NodeStore = statusStore; break;
				}
			} 

			NarudzbeNode n = (nodeviewNarudzbe.NodeSelection.SelectedNode as NarudzbeNode);
			if(!prikazStatusSve && n != null) { 
				switch(comboboxStatus.Active) {
					case 0: PrikaziStatus(NarudzbaStavka.StatusStavke.Dostavljeno, n.stavkeNarudzbeNodeStore, true); break;
					case 1: PrikaziStatus(NarudzbaStavka.StatusStavke.NaCekanju, n.stavkeNarudzbeNodeStore); break;
					case 2: PrikaziStatus(NarudzbaStavka.StatusStavke.UObradi, n.stavkeNarudzbeNodeStore); break;
					case 3: PrikaziStatus(NarudzbaStavka.StatusStavke.Gotovo, n.stavkeNarudzbeNodeStore); break;
					case 4: PrikaziStatus(NarudzbaStavka.StatusStavke.Dostavljeno, n.stavkeNarudzbeNodeStore); break;
					case 5: nodeviewNarudzbeStatus.NodeStore = n.stavkeNarudzbeNodeStore; break;
				}
			}
		}
 		protected void PrikaziStatus(NarudzbaStavka.StatusStavke s, NarudzbaStavkaNodeStore nsns, bool prikaziOsimS = false) {
			current.Clear();
			if(!prikaziOsimS) {
				foreach(NarudzbaStavkaNode n in nsns) {
					if(n.Status == s) current.AddNode(n);
					}
			} else { 
				foreach(NarudzbaStavkaNode n in nsns) {
					if(n.Status != s) current.AddNode(n);
				}
			}
			nodeviewNarudzbeStatus.NodeStore = current;
		}

		protected void OnComboboxSveTrenutnaChanged(object sender, EventArgs e) {
			switch(comboboxSveTrenutna.Active) {
				case 0: prikazStatusSve = true; break;
				case 1: prikazStatusSve = false; break;
			}
			OnComboboxStatusChanged(sender, e);
		}

		protected void FixedRestoranShemeTableSelected(string name) {
			foreach(NarudzbeNode n in narudzbeNodeStore) {
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
					n.Update(comboboxOznakaStola.ActiveText);
				} catch(ArgumentException ae) {
					DialogBox.ShowError(this, ae.Message);
				}
				hboxSpremljeno.Show();
				GLib.Timeout.Add(2000, () => { hboxSpremljeno.Hide(); return false; });
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

		protected void OnArtikliActionActivated(object sender, EventArgs e) {
			if(!windowAction.Active && notebookMain.Page != 1) {
				notebookMain.Page = 1;
				ArtikliWindow aw = new ArtikliWindow(false);
				aw.Destroyed += (o, args) => { notebookMain.Page = 0; };

				boxArtikli.Foreach(box => boxArtikli.Remove(box));
				boxArtikli.Add(aw.GetContent());
			} else { 
				notebookMain.Page = 0;
				ArtikliWindow aw = new ArtikliWindow(true);
			}

		}
	}
}
