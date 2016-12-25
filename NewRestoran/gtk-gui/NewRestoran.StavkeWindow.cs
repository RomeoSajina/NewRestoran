
// This file has been generated by the GUI designer. Do not modify.
namespace NewRestoran {
	public partial class StavkeWindow {
		private global::Gtk.HBox hbox1;

		private global::Gtk.VBox vboxNodeView;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Button buttonSearchNode;

		private global::Gtk.Entry entrySearchNode;

		private global::Gtk.ScrolledWindow GtkScrolledWindowStavke;

		private global::Gtk.NodeView nodeviewStavke;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label1;

		private global::Gtk.Label labelUkupno;

		private global::Gtk.VBox vboxFormView;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label8;

		private global::Gtk.ComboBox comboboxSifraArtikla;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.Entry entrySearchForm;

		private global::Gtk.Button buttonSearchForm;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label3;

		private global::Gtk.Label labelNazivArtikla;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label label4;

		private global::Gtk.Label labelCijenaArtikla;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label label5;

		private global::Gtk.SpinButton spinbuttonKolicina;

		private global::Gtk.HBox hbox8;

		private global::Gtk.Label label6;

		private global::Gtk.Label labelUkupnoArtikla;

		private global::Gtk.HBox hbox9;

		private global::Gtk.Label label7;

		private global::Gtk.ComboBox comboboxStatus;

		private global::Gtk.HBox hbox10;

		private global::Gtk.Button buttonOdustani;

		private global::Gtk.Button buttonSpremi;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Fixed fixed1;

		private global::Gtk.Button buttonDodajStavku;

		private global::Gtk.Button buttonUp;

		private global::Gtk.Button buttonDown;

		private global::Gtk.Button buttonChange;

		private global::Gtk.Button buttonDelete;

		private global::Gtk.Button buttonBackAndSave;

		private global::Gtk.Button buttonZakljuci;

		protected virtual void Build() {
			global::Stetic.Gui.Initialize(this);
			// Widget NewRestoran.StavkeWindow
			this.Name = "NewRestoran.StavkeWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("StavkeWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child NewRestoran.StavkeWindow.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(12));
			// Container child hbox1.Gtk.Box+BoxChild
			this.vboxNodeView = new global::Gtk.VBox();
			this.vboxNodeView.Name = "vboxNodeView";
			this.vboxNodeView.Spacing = 6;
			// Container child vboxNodeView.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonSearchNode = new global::Gtk.Button();
			this.buttonSearchNode.WidthRequest = 39;
			this.buttonSearchNode.HeightRequest = 25;
			this.buttonSearchNode.CanFocus = true;
			this.buttonSearchNode.Name = "buttonSearchNode";
			this.buttonSearchNode.UseUnderline = true;
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-find", global::Gtk.IconSize.Button);
			this.buttonSearchNode.Image = w1;
			this.hbox3.Add(this.buttonSearchNode);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonSearchNode]));
			w2.PackType = ((global::Gtk.PackType)(1));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.entrySearchNode = new global::Gtk.Entry();
			this.entrySearchNode.WidthRequest = 134;
			this.entrySearchNode.CanFocus = true;
			this.entrySearchNode.Name = "entrySearchNode";
			this.entrySearchNode.IsEditable = true;
			this.entrySearchNode.InvisibleChar = '●';
			this.hbox3.Add(this.entrySearchNode);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.entrySearchNode]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 1;
			w3.Expand = false;
			this.vboxNodeView.Add(this.hbox3);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxNodeView[this.hbox3]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vboxNodeView.Gtk.Box+BoxChild
			this.GtkScrolledWindowStavke = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindowStavke.Name = "GtkScrolledWindowStavke";
			this.GtkScrolledWindowStavke.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindowStavke.Gtk.Container+ContainerChild
			this.nodeviewStavke = new global::Gtk.NodeView();
			this.nodeviewStavke.WidthRequest = 845;
			this.nodeviewStavke.CanFocus = true;
			this.nodeviewStavke.Name = "nodeviewStavke";
			this.nodeviewStavke.Reorderable = true;
			this.nodeviewStavke.RulesHint = true;
			this.nodeviewStavke.SearchColumn = 0;
			this.GtkScrolledWindowStavke.Add(this.nodeviewStavke);
			this.vboxNodeView.Add(this.GtkScrolledWindowStavke);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vboxNodeView[this.GtkScrolledWindowStavke]));
			w6.Position = 1;
			// Container child vboxNodeView.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Ukupno:");
			this.hbox2.Add(this.label1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.labelUkupno = new global::Gtk.Label();
			this.labelUkupno.Name = "labelUkupno";
			this.hbox2.Add(this.labelUkupno);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.labelUkupno]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.vboxNodeView.Add(this.hbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vboxNodeView[this.hbox2]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			this.hbox1.Add(this.vboxNodeView);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vboxNodeView]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vboxFormView = new global::Gtk.VBox();
			this.vboxFormView.Name = "vboxFormView";
			this.vboxFormView.Spacing = 14;
			this.vboxFormView.BorderWidth = ((uint)(31));
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label();
			this.label8.WidthRequest = 90;
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Šifra artikla:");
			this.hbox4.Add(this.label8);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label8]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			w11.Padding = ((uint)(15));
			// Container child hbox4.Gtk.Box+BoxChild
			this.comboboxSifraArtikla = global::Gtk.ComboBox.NewText();
			this.comboboxSifraArtikla.WidthRequest = 180;
			this.comboboxSifraArtikla.Name = "comboboxSifraArtikla";
			this.hbox4.Add(this.comboboxSifraArtikla);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.comboboxSifraArtikla]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.WidthRequest = 20;
			this.vseparator1.Name = "vseparator1";
			this.hbox4.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.vseparator1]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.entrySearchForm = new global::Gtk.Entry();
			this.entrySearchForm.WidthRequest = 134;
			this.entrySearchForm.CanFocus = true;
			this.entrySearchForm.Name = "entrySearchForm";
			this.entrySearchForm.IsEditable = true;
			this.entrySearchForm.InvisibleChar = '●';
			this.hbox4.Add(this.entrySearchForm);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.entrySearchForm]));
			w14.Position = 3;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSearchForm = new global::Gtk.Button();
			this.buttonSearchForm.WidthRequest = 39;
			this.buttonSearchForm.HeightRequest = 25;
			this.buttonSearchForm.CanFocus = true;
			this.buttonSearchForm.Name = "buttonSearchForm";
			this.buttonSearchForm.UseUnderline = true;
			global::Gtk.Image w15 = new global::Gtk.Image();
			w15.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-find", global::Gtk.IconSize.Button);
			this.buttonSearchForm.Image = w15;
			this.hbox4.Add(this.buttonSearchForm);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSearchForm]));
			w16.Position = 4;
			w16.Expand = false;
			w16.Fill = false;
			this.vboxFormView.Add(this.hbox4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox4]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.WidthRequest = 90;
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Naziv artikla:");
			this.hbox5.Add(this.label3);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label3]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			w18.Padding = ((uint)(15));
			// Container child hbox5.Gtk.Box+BoxChild
			this.labelNazivArtikla = new global::Gtk.Label();
			this.labelNazivArtikla.Name = "labelNazivArtikla";
			this.hbox5.Add(this.labelNazivArtikla);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.labelNazivArtikla]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			this.vboxFormView.Add(this.hbox5);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox5]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.WidthRequest = 90;
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Cijena:");
			this.hbox6.Add(this.label4);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label4]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			w21.Padding = ((uint)(15));
			// Container child hbox6.Gtk.Box+BoxChild
			this.labelCijenaArtikla = new global::Gtk.Label();
			this.labelCijenaArtikla.Name = "labelCijenaArtikla";
			this.hbox6.Add(this.labelCijenaArtikla);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.labelCijenaArtikla]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			this.vboxFormView.Add(this.hbox6);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox6]));
			w23.Position = 2;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label();
			this.label5.WidthRequest = 90;
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Količina:");
			this.hbox7.Add(this.label5);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label5]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			w24.Padding = ((uint)(15));
			// Container child hbox7.Gtk.Box+BoxChild
			this.spinbuttonKolicina = new global::Gtk.SpinButton(0D, 100D, 1D);
			this.spinbuttonKolicina.WidthRequest = 180;
			this.spinbuttonKolicina.CanFocus = true;
			this.spinbuttonKolicina.Name = "spinbuttonKolicina";
			this.spinbuttonKolicina.Adjustment.PageIncrement = 10D;
			this.spinbuttonKolicina.ClimbRate = 1D;
			this.spinbuttonKolicina.Numeric = true;
			this.spinbuttonKolicina.SnapToTicks = true;
			this.hbox7.Add(this.spinbuttonKolicina);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.spinbuttonKolicina]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			this.vboxFormView.Add(this.hbox7);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox7]));
			w26.Position = 3;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label();
			this.label6.WidthRequest = 90;
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Ukupno:");
			this.hbox8.Add(this.label6);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.label6]));
			w27.Position = 0;
			w27.Expand = false;
			w27.Fill = false;
			w27.Padding = ((uint)(15));
			// Container child hbox8.Gtk.Box+BoxChild
			this.labelUkupnoArtikla = new global::Gtk.Label();
			this.labelUkupnoArtikla.Name = "labelUkupnoArtikla";
			this.hbox8.Add(this.labelUkupnoArtikla);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.labelUkupnoArtikla]));
			w28.Position = 1;
			w28.Expand = false;
			w28.Fill = false;
			this.vboxFormView.Add(this.hbox8);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox8]));
			w29.Position = 4;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label();
			this.label7.WidthRequest = 90;
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Status:");
			this.hbox9.Add(this.label7);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.label7]));
			w30.Position = 0;
			w30.Expand = false;
			w30.Fill = false;
			w30.Padding = ((uint)(15));
			// Container child hbox9.Gtk.Box+BoxChild
			this.comboboxStatus = new global::Gtk.ComboBox();
			this.comboboxStatus.WidthRequest = 180;
			this.comboboxStatus.Name = "comboboxStatus";
			this.hbox9.Add(this.comboboxStatus);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.comboboxStatus]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			this.vboxFormView.Add(this.hbox9);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox9]));
			w32.Position = 5;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 31;
			this.hbox10.BorderWidth = ((uint)(46));
			// Container child hbox10.Gtk.Box+BoxChild
			this.buttonOdustani = new global::Gtk.Button();
			this.buttonOdustani.WidthRequest = 150;
			this.buttonOdustani.HeightRequest = 50;
			this.buttonOdustani.CanFocus = true;
			this.buttonOdustani.Name = "buttonOdustani";
			this.buttonOdustani.UseUnderline = true;
			this.buttonOdustani.FocusOnClick = false;
			this.buttonOdustani.Label = global::Mono.Unix.Catalog.GetString("Odustani");
			global::Gtk.Image w33 = new global::Gtk.Image();
			w33.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.buttonOdustani.Image = w33;
			this.hbox10.Add(this.buttonOdustani);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.buttonOdustani]));
			w34.Position = 0;
			w34.Expand = false;
			w34.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.buttonSpremi = new global::Gtk.Button();
			this.buttonSpremi.WidthRequest = 150;
			this.buttonSpremi.HeightRequest = 50;
			this.buttonSpremi.CanFocus = true;
			this.buttonSpremi.Name = "buttonSpremi";
			this.buttonSpremi.UseUnderline = true;
			this.buttonSpremi.FocusOnClick = false;
			this.buttonSpremi.Label = global::Mono.Unix.Catalog.GetString("Spremi");
			global::Gtk.Image w35 = new global::Gtk.Image();
			w35.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Button);
			this.buttonSpremi.Image = w35;
			this.hbox10.Add(this.buttonSpremi);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.buttonSpremi]));
			w36.Position = 1;
			w36.Expand = false;
			w36.Fill = false;
			this.vboxFormView.Add(this.hbox10);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox10]));
			w37.Position = 6;
			w37.Expand = false;
			w37.Fill = false;
			this.hbox1.Add(this.vboxFormView);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vboxFormView]));
			w38.Position = 1;
			w38.Expand = false;
			w38.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 23;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed();
			this.fixed1.HeightRequest = 8;
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.vbox2.Add(this.fixed1);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed1]));
			w39.Position = 0;
			w39.Expand = false;
			w39.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonDodajStavku = new global::Gtk.Button();
			this.buttonDodajStavku.CanFocus = true;
			this.buttonDodajStavku.Name = "buttonDodajStavku";
			this.buttonDodajStavku.UseUnderline = true;
			this.buttonDodajStavku.FocusOnClick = false;
			global::Gtk.Image w40 = new global::Gtk.Image();
			w40.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.add.png");
			this.buttonDodajStavku.Image = w40;
			this.vbox2.Add(this.buttonDodajStavku);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonDodajStavku]));
			w41.Position = 1;
			w41.Expand = false;
			w41.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonUp = new global::Gtk.Button();
			this.buttonUp.CanFocus = true;
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.UseUnderline = true;
			this.buttonUp.FocusOnClick = false;
			global::Gtk.Image w42 = new global::Gtk.Image();
			w42.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.up.png");
			this.buttonUp.Image = w42;
			this.vbox2.Add(this.buttonUp);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonUp]));
			w43.Position = 2;
			w43.Expand = false;
			w43.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonDown = new global::Gtk.Button();
			this.buttonDown.CanFocus = true;
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.UseUnderline = true;
			this.buttonDown.FocusOnClick = false;
			global::Gtk.Image w44 = new global::Gtk.Image();
			w44.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.down.png");
			this.buttonDown.Image = w44;
			this.vbox2.Add(this.buttonDown);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonDown]));
			w45.Position = 3;
			w45.Expand = false;
			w45.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonChange = new global::Gtk.Button();
			this.buttonChange.CanFocus = true;
			this.buttonChange.Name = "buttonChange";
			this.buttonChange.UseUnderline = true;
			this.buttonChange.FocusOnClick = false;
			global::Gtk.Image w46 = new global::Gtk.Image();
			w46.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.change.png");
			this.buttonChange.Image = w46;
			this.vbox2.Add(this.buttonChange);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonChange]));
			w47.Position = 4;
			w47.Expand = false;
			w47.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button();
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.FocusOnClick = false;
			global::Gtk.Image w48 = new global::Gtk.Image();
			w48.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.delete.png");
			this.buttonDelete.Image = w48;
			this.vbox2.Add(this.buttonDelete);
			global::Gtk.Box.BoxChild w49 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonDelete]));
			w49.Position = 5;
			w49.Expand = false;
			w49.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonBackAndSave = new global::Gtk.Button();
			this.buttonBackAndSave.CanFocus = true;
			this.buttonBackAndSave.Name = "buttonBackAndSave";
			this.buttonBackAndSave.UseUnderline = true;
			this.buttonBackAndSave.FocusOnClick = false;
			global::Gtk.Image w50 = new global::Gtk.Image();
			w50.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.back-save.png");
			this.buttonBackAndSave.Image = w50;
			this.vbox2.Add(this.buttonBackAndSave);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonBackAndSave]));
			w51.Position = 6;
			w51.Expand = false;
			w51.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonZakljuci = new global::Gtk.Button();
			this.buttonZakljuci.CanFocus = true;
			this.buttonZakljuci.Name = "buttonZakljuci";
			this.buttonZakljuci.UseUnderline = true;
			this.buttonZakljuci.FocusOnClick = false;
			global::Gtk.Image w52 = new global::Gtk.Image();
			w52.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.lock.png");
			this.buttonZakljuci.Image = w52;
			this.vbox2.Add(this.buttonZakljuci);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonZakljuci]));
			w53.Position = 7;
			w53.Expand = false;
			w53.Fill = false;
			this.hbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
			w54.Position = 2;
			w54.Expand = false;
			w54.Fill = false;
			w54.Padding = ((uint)(31));
			this.Add(this.hbox1);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.DefaultWidth = 1605;
			this.DefaultHeight = 687;
			this.Show();
			this.comboboxSifraArtikla.Changed += new global::System.EventHandler(this.OnComboboxSifraArtiklaChanged);
			this.spinbuttonKolicina.ValueChanged += new global::System.EventHandler(this.OnSpinbuttonKolicinaValueChanged);
			this.buttonOdustani.Clicked += new global::System.EventHandler(this.OnButtonOdustaniClicked);
			this.buttonSpremi.Clicked += new global::System.EventHandler(this.OnButtonSpremiClicked);
			this.buttonDodajStavku.Clicked += new global::System.EventHandler(this.OnButtonDodajStavkuClicked);
			this.buttonUp.Clicked += new global::System.EventHandler(this.OnButtonUpClicked);
			this.buttonDown.Clicked += new global::System.EventHandler(this.OnButtonDownClicked);
			this.buttonChange.Clicked += new global::System.EventHandler(this.OnButtonChangeClicked);
			this.buttonDelete.Clicked += new global::System.EventHandler(this.OnButtonDeleteClicked);
			this.buttonBackAndSave.Clicked += new global::System.EventHandler(this.OnButtonBackAndSaveClicked);
			this.buttonZakljuci.Clicked += new global::System.EventHandler(this.OnButtonZakljuciClicked);
		}
	}
}