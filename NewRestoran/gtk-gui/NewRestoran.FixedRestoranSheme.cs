
// This file has been generated by the GUI designer. Do not modify.
namespace NewRestoran
{
	public partial class FixedRestoranSheme
	{
		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button buttonEdit;

		private global::Gtk.HBox hboxPrikazOznake;

		private global::Gtk.Label label4;

		private global::Gtk.Label labelOznakaStola;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label1;

		private global::Gtk.HScale hscaleSize;

		private global::Gtk.Button buttonApplySize;

		private global::Gtk.Button buttonChooseBg;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label3;

		private global::Gtk.Entry entryOznaka;

		private global::Gtk.Button buttonApply;

		private global::Gtk.Button buttonDelete;

		private global::Gtk.Fixed fixed3;

		private global::Gtk.HBox hboxSpremljeno;

		private global::Gtk.Image image250;

		private global::Gtk.Label labelSpremljeno;

		private global::Gtk.HBox hbox3;

		private global::Gtk.VBox vbox5;

		private global::Gtk.Fixed fixedSheme;

		private global::Gtk.VBox vbox6;

		private global::Gtk.EventBox Table2Chair;

		private global::Gtk.EventBox Table4Chair;

		private global::Gtk.EventBox Table6Chair;

		private global::Gtk.EventBox Table8Chair;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget NewRestoran.FixedRestoranSheme
			global::Stetic.BinContainer.Attach(this);
			this.Name = "NewRestoran.FixedRestoranSheme";
			// Container child NewRestoran.FixedRestoranSheme.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.WidthRequest = 0;
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			this.vbox4.BorderWidth = ((uint)(12));
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonEdit = new global::Gtk.Button();
			this.buttonEdit.CanFocus = true;
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.UseUnderline = true;
			this.buttonEdit.Label = global::Mono.Unix.Catalog.GetString("Finish");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-ok", global::Gtk.IconSize.Menu);
			this.buttonEdit.Image = w1;
			this.hbox2.Add(this.buttonEdit);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonEdit]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.hboxPrikazOznake = new global::Gtk.HBox();
			this.hboxPrikazOznake.Name = "hboxPrikazOznake";
			this.hboxPrikazOznake.Spacing = 6;
			// Container child hboxPrikazOznake.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Oznaka stola:");
			this.hboxPrikazOznake.Add(this.label4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hboxPrikazOznake[this.label4]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hboxPrikazOznake.Gtk.Box+BoxChild
			this.labelOznakaStola = new global::Gtk.Label();
			this.labelOznakaStola.Name = "labelOznakaStola";
			this.hboxPrikazOznake.Add(this.labelOznakaStola);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxPrikazOznake[this.labelOznakaStola]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.hbox2.Add(this.hboxPrikazOznake);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.hboxPrikazOznake]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox4.Add(this.hbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox2]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Icon size:");
			this.hbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.hscaleSize = new global::Gtk.HScale(null);
			this.hscaleSize.WidthRequest = 190;
			this.hscaleSize.CanFocus = true;
			this.hscaleSize.Name = "hscaleSize";
			this.hscaleSize.Adjustment.Lower = 10D;
			this.hscaleSize.Adjustment.Upper = 150D;
			this.hscaleSize.Adjustment.PageIncrement = 10D;
			this.hscaleSize.Adjustment.StepIncrement = 1D;
			this.hscaleSize.DrawValue = true;
			this.hscaleSize.Digits = 0;
			this.hscaleSize.ValuePos = ((global::Gtk.PositionType)(0));
			this.hbox1.Add(this.hscaleSize);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.hscaleSize]));
			w8.Position = 1;
			w8.Expand = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonApplySize = new global::Gtk.Button();
			this.buttonApplySize.CanFocus = true;
			this.buttonApplySize.Name = "buttonApplySize";
			this.buttonApplySize.UseUnderline = true;
			this.buttonApplySize.Label = global::Mono.Unix.Catalog.GetString("Apply");
			global::Gtk.Image w9 = new global::Gtk.Image();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonApplySize.Image = w9;
			this.hbox1.Add(this.buttonApplySize);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonApplySize]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonChooseBg = new global::Gtk.Button();
			this.buttonChooseBg.CanFocus = true;
			this.buttonChooseBg.Name = "buttonChooseBg";
			this.buttonChooseBg.UseUnderline = true;
			this.buttonChooseBg.Label = global::Mono.Unix.Catalog.GetString("Background");
			global::Gtk.Image w11 = new global::Gtk.Image();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-open", global::Gtk.IconSize.Menu);
			this.buttonChooseBg.Image = w11;
			this.hbox1.Add(this.buttonChooseBg);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonChooseBg]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox4.Add(this.hbox1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox1]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Oznaka:");
			this.hbox4.Add(this.label3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label3]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.entryOznaka = new global::Gtk.Entry();
			this.entryOznaka.WidthRequest = 140;
			this.entryOznaka.CanFocus = true;
			this.entryOznaka.Name = "entryOznaka";
			this.entryOznaka.IsEditable = true;
			this.entryOznaka.MaxLength = 20;
			this.entryOznaka.InvisibleChar = '●';
			this.hbox4.Add(this.entryOznaka);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.entryOznaka]));
			w15.Position = 1;
			w15.Expand = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonApply = new global::Gtk.Button();
			this.buttonApply.CanFocus = true;
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.UseUnderline = true;
			this.buttonApply.Label = global::Mono.Unix.Catalog.GetString("Apply");
			global::Gtk.Image w16 = new global::Gtk.Image();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonApply.Image = w16;
			this.hbox4.Add(this.buttonApply);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonApply]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button();
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.Label = global::Mono.Unix.Catalog.GetString("Delete");
			global::Gtk.Image w18 = new global::Gtk.Image();
			w18.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDelete.Image = w18;
			this.hbox4.Add(this.buttonDelete);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonDelete]));
			w19.Position = 3;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.fixed3 = new global::Gtk.Fixed();
			this.fixed3.WidthRequest = 60;
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			this.hbox4.Add(this.fixed3);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.fixed3]));
			w20.PackType = ((global::Gtk.PackType)(1));
			w20.Position = 4;
			w20.Expand = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.hboxSpremljeno = new global::Gtk.HBox();
			this.hboxSpremljeno.WidthRequest = 0;
			this.hboxSpremljeno.Name = "hboxSpremljeno";
			this.hboxSpremljeno.Spacing = 6;
			// Container child hboxSpremljeno.Gtk.Box+BoxChild
			this.image250 = new global::Gtk.Image();
			this.image250.Name = "image250";
			this.image250.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "Dostavljeno", global::Gtk.IconSize.SmallToolbar);
			this.hboxSpremljeno.Add(this.image250);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hboxSpremljeno[this.image250]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hboxSpremljeno.Gtk.Box+BoxChild
			this.labelSpremljeno = new global::Gtk.Label();
			this.labelSpremljeno.Name = "labelSpremljeno";
			this.labelSpremljeno.LabelProp = global::Mono.Unix.Catalog.GetString("Spremljeno");
			this.hboxSpremljeno.Add(this.labelSpremljeno);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hboxSpremljeno[this.labelSpremljeno]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			this.hbox4.Add(this.hboxSpremljeno);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.hboxSpremljeno]));
			w23.PackType = ((global::Gtk.PackType)(1));
			w23.Position = 5;
			w23.Expand = false;
			w23.Fill = false;
			this.vbox4.Add(this.hbox4);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox4]));
			w24.Position = 2;
			w24.Expand = false;
			w24.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.fixedSheme = new global::Gtk.Fixed();
			this.fixedSheme.WidthRequest = 600;
			this.fixedSheme.HeightRequest = 800;
			this.fixedSheme.Name = "fixedSheme";
			this.fixedSheme.HasWindow = false;
			this.vbox5.Add(this.fixedSheme);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.fixedSheme]));
			w25.Position = 0;
			w25.Expand = false;
			w25.Fill = false;
			this.hbox3.Add(this.vbox5);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox5]));
			w26.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox6 = new global::Gtk.VBox();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.Table2Chair = new global::Gtk.EventBox();
			this.Table2Chair.Name = "Table2Chair";
			this.vbox6.Add(this.Table2Chair);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.Table2Chair]));
			w27.Position = 0;
			// Container child vbox6.Gtk.Box+BoxChild
			this.Table4Chair = new global::Gtk.EventBox();
			this.Table4Chair.Name = "Table4Chair";
			this.vbox6.Add(this.Table4Chair);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.Table4Chair]));
			w28.Position = 1;
			// Container child vbox6.Gtk.Box+BoxChild
			this.Table6Chair = new global::Gtk.EventBox();
			this.Table6Chair.Name = "Table6Chair";
			this.vbox6.Add(this.Table6Chair);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.Table6Chair]));
			w29.Position = 2;
			// Container child vbox6.Gtk.Box+BoxChild
			this.Table8Chair = new global::Gtk.EventBox();
			this.Table8Chair.Name = "Table8Chair";
			this.vbox6.Add(this.Table8Chair);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.Table8Chair]));
			w30.Position = 3;
			this.hbox3.Add(this.vbox6);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox6]));
			w31.Position = 1;
			this.vbox4.Add(this.hbox3);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox3]));
			w32.Position = 3;
			w32.Expand = false;
			w32.Fill = false;
			this.Add(this.vbox4);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.hboxSpremljeno.Hide();
			this.Show();
			this.buttonEdit.Clicked += new global::System.EventHandler(this.OnButtonEditClicked);
			this.buttonApplySize.Clicked += new global::System.EventHandler(this.OnButtonApplySizeClicked);
			this.buttonChooseBg.Clicked += new global::System.EventHandler(this.OnButtonChooseBgClicked);
			this.buttonApply.Clicked += new global::System.EventHandler(this.OnButtonApplyClicked);
			this.buttonDelete.Clicked += new global::System.EventHandler(this.OnButtonDeleteClicked);
		}
	}
}
