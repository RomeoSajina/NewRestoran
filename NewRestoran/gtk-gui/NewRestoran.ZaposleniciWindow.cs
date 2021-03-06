
// This file has been generated by the GUI designer. Do not modify.
namespace NewRestoran
{
	public partial class ZaposleniciWindow
	{
		private global::Gtk.HBox hbox2;

		private global::Gtk.VBox vboxNodeView;

		private global::Gtk.HBox hbox10;

		private global::Gtk.Button buttonSearch;

		private global::Gtk.Entry entrySearch;

		private global::Gtk.Label label13;

		private global::Gtk.ScrolledWindow GtkScrolledWindowZaposlenici;

		private global::Gtk.NodeView nodeviewZaposlenici;

		private global::Gtk.VBox vboxFormView;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label1;

		private global::Gtk.Entry entryIme;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label2;

		private global::Gtk.Entry entryPrezime;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label3;

		private global::Gtk.Entry entryPassword;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label4;

		private global::Gtk.Entry entryDatum;

		private global::Gtk.Button buttonDatum;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label label5;

		private global::Gtk.ComboBox comboboxStatus;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label label6;

		private global::Gtk.ComboBox comboboxUloga;

		private global::Gtk.HBox hbox8;

		private global::Gtk.HBox hbox12;

		private global::Gtk.Fixed fixed2;

		private global::Gtk.Button buttonOdustani;

		private global::Gtk.Button buttonSpremi;

		private global::Gtk.HBox hbox9;

		private global::Gtk.HBox hboxSpremljeno;

		private global::Gtk.Fixed fixed4;

		private global::Gtk.Image image250;

		private global::Gtk.Label labelSpremljeno;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Fixed fixed3;

		private global::Gtk.Button buttonDodajZaposlenika;

		private global::Gtk.Button buttonUp;

		private global::Gtk.Button buttonDown;

		private global::Gtk.Button buttonChange;

		private global::Gtk.Button buttonDelete;

		private global::Gtk.Button buttonBackAndSave;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget NewRestoran.ZaposleniciWindow
			this.Name = "NewRestoran.ZaposleniciWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("Zaposlenici");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.logo.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.Modal = true;
			this.BorderWidth = ((uint)(15));
			// Container child NewRestoran.ZaposleniciWindow.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vboxNodeView = new global::Gtk.VBox();
			this.vboxNodeView.Name = "vboxNodeView";
			this.vboxNodeView.Spacing = 6;
			// Container child vboxNodeView.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.buttonSearch = new global::Gtk.Button();
			this.buttonSearch.WidthRequest = 39;
			this.buttonSearch.HeightRequest = 25;
			this.buttonSearch.CanFocus = true;
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.UseUnderline = true;
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-find", global::Gtk.IconSize.SmallToolbar);
			this.buttonSearch.Image = w1;
			this.hbox10.Add(this.buttonSearch);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.buttonSearch]));
			w2.PackType = ((global::Gtk.PackType)(1));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.entrySearch = new global::Gtk.Entry();
			this.entrySearch.WidthRequest = 130;
			this.entrySearch.CanFocus = true;
			this.entrySearch.Name = "entrySearch";
			this.entrySearch.IsEditable = true;
			this.entrySearch.InvisibleChar = '●';
			this.hbox10.Add(this.entrySearch);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.entrySearch]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 1;
			w3.Expand = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.label13 = new global::Gtk.Label();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("Filtriraj zaposlenike: ");
			this.hbox10.Add(this.label13);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.label13]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.vboxNodeView.Add(this.hbox10);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vboxNodeView[this.hbox10]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vboxNodeView.Gtk.Box+BoxChild
			this.GtkScrolledWindowZaposlenici = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindowZaposlenici.WidthRequest = 900;
			this.GtkScrolledWindowZaposlenici.HeightRequest = 550;
			this.GtkScrolledWindowZaposlenici.Name = "GtkScrolledWindowZaposlenici";
			this.GtkScrolledWindowZaposlenici.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindowZaposlenici.Gtk.Container+ContainerChild
			this.nodeviewZaposlenici = new global::Gtk.NodeView();
			this.nodeviewZaposlenici.WidthRequest = 900;
			this.nodeviewZaposlenici.CanFocus = true;
			this.nodeviewZaposlenici.Name = "nodeviewZaposlenici";
			this.nodeviewZaposlenici.Reorderable = true;
			this.nodeviewZaposlenici.RulesHint = true;
			this.nodeviewZaposlenici.SearchColumn = 0;
			this.GtkScrolledWindowZaposlenici.Add(this.nodeviewZaposlenici);
			this.vboxNodeView.Add(this.GtkScrolledWindowZaposlenici);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vboxNodeView[this.GtkScrolledWindowZaposlenici]));
			w7.Position = 1;
			w7.Expand = false;
			this.hbox2.Add(this.vboxNodeView);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vboxNodeView]));
			w8.Position = 0;
			w8.Expand = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vboxFormView = new global::Gtk.VBox();
			this.vboxFormView.Name = "vboxFormView";
			this.vboxFormView.Spacing = 16;
			this.vboxFormView.BorderWidth = ((uint)(31));
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.WidthRequest = 100;
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Ime:");
			this.hbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			w9.Padding = ((uint)(25));
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryIme = new global::Gtk.Entry();
			this.entryIme.WidthRequest = 290;
			this.entryIme.CanFocus = true;
			this.entryIme.Name = "entryIme";
			this.entryIme.IsEditable = true;
			this.entryIme.MaxLength = 20;
			this.entryIme.InvisibleChar = '●';
			this.hbox1.Add(this.entryIme);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.entryIme]));
			w10.Position = 1;
			w10.Expand = false;
			this.vboxFormView.Add(this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox1]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.WidthRequest = 100;
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Prezime:");
			this.hbox3.Add(this.label2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label2]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			w12.Padding = ((uint)(25));
			// Container child hbox3.Gtk.Box+BoxChild
			this.entryPrezime = new global::Gtk.Entry();
			this.entryPrezime.WidthRequest = 290;
			this.entryPrezime.CanFocus = true;
			this.entryPrezime.Name = "entryPrezime";
			this.entryPrezime.IsEditable = true;
			this.entryPrezime.MaxLength = 20;
			this.entryPrezime.InvisibleChar = '●';
			this.hbox3.Add(this.entryPrezime);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.entryPrezime]));
			w13.Position = 1;
			w13.Expand = false;
			this.vboxFormView.Add(this.hbox3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox3]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.WidthRequest = 100;
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Lozinka:");
			this.hbox4.Add(this.label3);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label3]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			w15.Padding = ((uint)(25));
			// Container child hbox4.Gtk.Box+BoxChild
			this.entryPassword = new global::Gtk.Entry();
			this.entryPassword.WidthRequest = 290;
			this.entryPassword.CanFocus = true;
			this.entryPassword.Name = "entryPassword";
			this.entryPassword.IsEditable = true;
			this.entryPassword.MaxLength = 20;
			this.entryPassword.Visibility = false;
			this.entryPassword.InvisibleChar = '●';
			this.hbox4.Add(this.entryPassword);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.entryPassword]));
			w16.Position = 1;
			w16.Expand = false;
			this.vboxFormView.Add(this.hbox4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox4]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.WidthRequest = 100;
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Datum zaposlenja:");
			this.hbox5.Add(this.label4);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label4]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			w18.Padding = ((uint)(25));
			// Container child hbox5.Gtk.Box+BoxChild
			this.entryDatum = new global::Gtk.Entry();
			this.entryDatum.WidthRequest = 253;
			this.entryDatum.CanFocus = true;
			this.entryDatum.Name = "entryDatum";
			this.entryDatum.IsEditable = false;
			this.entryDatum.InvisibleChar = '●';
			this.hbox5.Add(this.entryDatum);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.entryDatum]));
			w19.Position = 1;
			w19.Expand = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.buttonDatum = new global::Gtk.Button();
			this.buttonDatum.WidthRequest = 30;
			this.buttonDatum.HeightRequest = 25;
			this.buttonDatum.CanFocus = true;
			this.buttonDatum.Name = "buttonDatum";
			this.buttonDatum.UseUnderline = true;
			global::Gtk.Image w20 = new global::Gtk.Image();
			w20.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "date", global::Gtk.IconSize.SmallToolbar);
			this.buttonDatum.Image = w20;
			this.hbox5.Add(this.buttonDatum);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.buttonDatum]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			this.vboxFormView.Add(this.hbox5);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox5]));
			w22.Position = 3;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label();
			this.label5.WidthRequest = 100;
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Status:");
			this.hbox6.Add(this.label5);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label5]));
			w23.Position = 0;
			w23.Expand = false;
			w23.Fill = false;
			w23.Padding = ((uint)(25));
			// Container child hbox6.Gtk.Box+BoxChild
			this.comboboxStatus = global::Gtk.ComboBox.NewText();
			this.comboboxStatus.WidthRequest = 290;
			this.comboboxStatus.Name = "comboboxStatus";
			this.hbox6.Add(this.comboboxStatus);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.comboboxStatus]));
			w24.Position = 1;
			w24.Expand = false;
			w24.Fill = false;
			this.vboxFormView.Add(this.hbox6);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox6]));
			w25.Position = 4;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label();
			this.label6.WidthRequest = 100;
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Uloga:");
			this.hbox7.Add(this.label6);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label6]));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			w26.Padding = ((uint)(25));
			// Container child hbox7.Gtk.Box+BoxChild
			this.comboboxUloga = new global::Gtk.ComboBox();
			this.comboboxUloga.WidthRequest = 290;
			this.comboboxUloga.Name = "comboboxUloga";
			this.hbox7.Add(this.comboboxUloga);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.comboboxUloga]));
			w27.Position = 1;
			w27.Expand = false;
			w27.Fill = false;
			this.vboxFormView.Add(this.hbox7);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox7]));
			w28.Position = 5;
			w28.Expand = false;
			w28.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.hbox12 = new global::Gtk.HBox();
			this.hbox12.Name = "hbox12";
			this.hbox12.Spacing = 20;
			this.hbox12.BorderWidth = ((uint)(25));
			// Container child hbox12.Gtk.Box+BoxChild
			this.fixed2 = new global::Gtk.Fixed();
			this.fixed2.WidthRequest = 98;
			this.fixed2.Name = "fixed2";
			this.fixed2.HasWindow = false;
			this.hbox12.Add(this.fixed2);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.fixed2]));
			w29.Position = 0;
			w29.Expand = false;
			// Container child hbox12.Gtk.Box+BoxChild
			this.buttonOdustani = new global::Gtk.Button();
			this.buttonOdustani.WidthRequest = 150;
			this.buttonOdustani.HeightRequest = 50;
			this.buttonOdustani.CanFocus = true;
			this.buttonOdustani.Name = "buttonOdustani";
			this.buttonOdustani.UseUnderline = true;
			this.buttonOdustani.Label = global::Mono.Unix.Catalog.GetString("Odustani");
			global::Gtk.Image w30 = new global::Gtk.Image();
			w30.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Button);
			this.buttonOdustani.Image = w30;
			this.hbox12.Add(this.buttonOdustani);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.buttonOdustani]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbox12.Gtk.Box+BoxChild
			this.buttonSpremi = new global::Gtk.Button();
			this.buttonSpremi.WidthRequest = 150;
			this.buttonSpremi.HeightRequest = 50;
			this.buttonSpremi.CanFocus = true;
			this.buttonSpremi.Name = "buttonSpremi";
			this.buttonSpremi.UseUnderline = true;
			this.buttonSpremi.Label = global::Mono.Unix.Catalog.GetString("Spremi");
			global::Gtk.Image w32 = new global::Gtk.Image();
			w32.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Button);
			this.buttonSpremi.Image = w32;
			this.hbox12.Add(this.buttonSpremi);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.buttonSpremi]));
			w33.Position = 2;
			w33.Expand = false;
			w33.Fill = false;
			this.hbox8.Add(this.hbox12);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.hbox12]));
			w34.Position = 0;
			this.vboxFormView.Add(this.hbox8);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox8]));
			w35.Position = 6;
			w35.Expand = false;
			w35.Fill = false;
			// Container child vboxFormView.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.hboxSpremljeno = new global::Gtk.HBox();
			this.hboxSpremljeno.WidthRequest = 0;
			this.hboxSpremljeno.Name = "hboxSpremljeno";
			this.hboxSpremljeno.Spacing = 6;
			this.hboxSpremljeno.BorderWidth = ((uint)(17));
			// Container child hboxSpremljeno.Gtk.Box+BoxChild
			this.fixed4 = new global::Gtk.Fixed();
			this.fixed4.WidthRequest = 247;
			this.fixed4.Name = "fixed4";
			this.fixed4.HasWindow = false;
			this.hboxSpremljeno.Add(this.fixed4);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.hboxSpremljeno[this.fixed4]));
			w36.Position = 0;
			w36.Expand = false;
			// Container child hboxSpremljeno.Gtk.Box+BoxChild
			this.image250 = new global::Gtk.Image();
			this.image250.Name = "image250";
			this.image250.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "Dostavljeno", global::Gtk.IconSize.Dnd);
			this.hboxSpremljeno.Add(this.image250);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.hboxSpremljeno[this.image250]));
			w37.Position = 1;
			w37.Expand = false;
			w37.Fill = false;
			// Container child hboxSpremljeno.Gtk.Box+BoxChild
			this.labelSpremljeno = new global::Gtk.Label();
			this.labelSpremljeno.Name = "labelSpremljeno";
			this.labelSpremljeno.LabelProp = global::Mono.Unix.Catalog.GetString("Spremljeno");
			this.hboxSpremljeno.Add(this.labelSpremljeno);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.hboxSpremljeno[this.labelSpremljeno]));
			w38.Position = 2;
			w38.Expand = false;
			w38.Fill = false;
			this.hbox9.Add(this.hboxSpremljeno);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.hboxSpremljeno]));
			w39.Position = 0;
			this.vboxFormView.Add(this.hbox9);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vboxFormView[this.hbox9]));
			w40.Position = 7;
			w40.Expand = false;
			w40.Fill = false;
			this.hbox2.Add(this.vboxFormView);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vboxFormView]));
			w41.Position = 1;
			w41.Expand = false;
			w41.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 23;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed3 = new global::Gtk.Fixed();
			this.fixed3.WidthRequest = 0;
			this.fixed3.HeightRequest = 7;
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			this.vbox2.Add(this.fixed3);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixed3]));
			w42.Position = 0;
			w42.Expand = false;
			w42.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonDodajZaposlenika = new global::Gtk.Button();
			this.buttonDodajZaposlenika.CanFocus = true;
			this.buttonDodajZaposlenika.Name = "buttonDodajZaposlenika";
			this.buttonDodajZaposlenika.UseUnderline = true;
			this.buttonDodajZaposlenika.FocusOnClick = false;
			global::Gtk.Image w43 = new global::Gtk.Image();
			w43.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.add.png");
			this.buttonDodajZaposlenika.Image = w43;
			this.vbox2.Add(this.buttonDodajZaposlenika);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonDodajZaposlenika]));
			w44.Position = 1;
			w44.Expand = false;
			w44.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonUp = new global::Gtk.Button();
			this.buttonUp.CanFocus = true;
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.UseUnderline = true;
			this.buttonUp.FocusOnClick = false;
			global::Gtk.Image w45 = new global::Gtk.Image();
			w45.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.up.png");
			this.buttonUp.Image = w45;
			this.vbox2.Add(this.buttonUp);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonUp]));
			w46.Position = 2;
			w46.Expand = false;
			w46.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonDown = new global::Gtk.Button();
			this.buttonDown.CanFocus = true;
			this.buttonDown.Name = "buttonDown";
			this.buttonDown.UseUnderline = true;
			this.buttonDown.FocusOnClick = false;
			global::Gtk.Image w47 = new global::Gtk.Image();
			w47.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.down.png");
			this.buttonDown.Image = w47;
			this.vbox2.Add(this.buttonDown);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonDown]));
			w48.Position = 3;
			w48.Expand = false;
			w48.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonChange = new global::Gtk.Button();
			this.buttonChange.CanFocus = true;
			this.buttonChange.Name = "buttonChange";
			this.buttonChange.UseUnderline = true;
			this.buttonChange.FocusOnClick = false;
			global::Gtk.Image w49 = new global::Gtk.Image();
			w49.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.change.png");
			this.buttonChange.Image = w49;
			this.vbox2.Add(this.buttonChange);
			global::Gtk.Box.BoxChild w50 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonChange]));
			w50.Position = 4;
			w50.Expand = false;
			w50.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button();
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.FocusOnClick = false;
			global::Gtk.Image w51 = new global::Gtk.Image();
			w51.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.delete.png");
			this.buttonDelete.Image = w51;
			this.vbox2.Add(this.buttonDelete);
			global::Gtk.Box.BoxChild w52 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonDelete]));
			w52.Position = 5;
			w52.Expand = false;
			w52.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonBackAndSave = new global::Gtk.Button();
			this.buttonBackAndSave.CanFocus = true;
			this.buttonBackAndSave.Name = "buttonBackAndSave";
			this.buttonBackAndSave.UseUnderline = true;
			this.buttonBackAndSave.FocusOnClick = false;
			global::Gtk.Image w53 = new global::Gtk.Image();
			w53.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("NewRestoran.images.back-save.png");
			this.buttonBackAndSave.Image = w53;
			this.vbox2.Add(this.buttonBackAndSave);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonBackAndSave]));
			w54.Position = 6;
			w54.Expand = false;
			w54.Fill = false;
			this.hbox2.Add(this.vbox2);
			global::Gtk.Box.BoxChild w55 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox2]));
			w55.Position = 2;
			w55.Expand = false;
			w55.Fill = false;
			w55.Padding = ((uint)(30));
			this.Add(this.hbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 1742;
			this.DefaultHeight = 634;
			this.hboxSpremljeno.Hide();
			this.vboxFormView.Hide();
			this.Hide();
			this.buttonSearch.Clicked += new global::System.EventHandler(this.OnButtonSearchClicked);
			this.buttonDatum.Clicked += new global::System.EventHandler(this.OnButtonDatumClicked);
			this.buttonOdustani.Clicked += new global::System.EventHandler(this.OnButtonOdustaniClicked);
			this.buttonSpremi.Clicked += new global::System.EventHandler(this.OnButtonSpremiClicked);
			this.buttonDodajZaposlenika.Clicked += new global::System.EventHandler(this.OnButtonDodajZaposlenikaClicked);
			this.buttonUp.Clicked += new global::System.EventHandler(this.OnButtonUpClicked);
			this.buttonDown.Clicked += new global::System.EventHandler(this.OnButtonDownClicked);
			this.buttonChange.Clicked += new global::System.EventHandler(this.OnButtonChangeClicked);
			this.buttonDelete.Clicked += new global::System.EventHandler(this.OnButtonDeleteClicked);
			this.buttonBackAndSave.Clicked += new global::System.EventHandler(this.OnButtonBackAndSaveClicked);
		}
	}
}
