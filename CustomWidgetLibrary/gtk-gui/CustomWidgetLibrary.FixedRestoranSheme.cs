
// This file has been generated by the GUI designer. Do not modify.
namespace CustomWidgetLibrary
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

		private global::Gtk.SpinButton spinbuttonSize;

		private global::Gtk.Button buttonApplySize;

		private global::Gtk.Button buttonChooseBg;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label label3;

		private global::Gtk.Label labelOznaka;

		private global::Gtk.ComboBox comboboxName;

		private global::Gtk.Button buttonApply;

		private global::Gtk.Button buttonDelete;

		private global::Gtk.Fixed fixed3;

		private global::Gtk.Button buttonSave;

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
			// Widget CustomWidgetLibrary.FixedRestoranSheme
			global::Stetic.BinContainer.Attach(this);
			this.Name = "CustomWidgetLibrary.FixedRestoranSheme";
			// Container child CustomWidgetLibrary.FixedRestoranSheme.Gtk.Container+ContainerChild
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
			this.spinbuttonSize = new global::Gtk.SpinButton(0D, 100D, 1D);
			this.spinbuttonSize.CanFocus = true;
			this.spinbuttonSize.Name = "spinbuttonSize";
			this.spinbuttonSize.Adjustment.PageIncrement = 10D;
			this.spinbuttonSize.ClimbRate = 1D;
			this.spinbuttonSize.Numeric = true;
			this.hbox1.Add(this.spinbuttonSize);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.spinbuttonSize]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
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
			this.labelOznaka = new global::Gtk.Label();
			this.labelOznaka.WidthRequest = 118;
			this.labelOznaka.Name = "labelOznaka";
			this.labelOznaka.Xalign = 0F;
			this.hbox4.Add(this.labelOznaka);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.labelOznaka]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.comboboxName = global::Gtk.ComboBox.NewText();
			this.comboboxName.WidthRequest = 120;
			this.comboboxName.Name = "comboboxName";
			this.hbox4.Add(this.comboboxName);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.comboboxName]));
			w16.Position = 2;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonApply = new global::Gtk.Button();
			this.buttonApply.CanFocus = true;
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.UseUnderline = true;
			this.buttonApply.Label = global::Mono.Unix.Catalog.GetString("Apply");
			global::Gtk.Image w17 = new global::Gtk.Image();
			w17.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonApply.Image = w17;
			this.hbox4.Add(this.buttonApply);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonApply]));
			w18.Position = 3;
			w18.Expand = false;
			w18.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button();
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.Label = global::Mono.Unix.Catalog.GetString("Delete");
			global::Gtk.Image w19 = new global::Gtk.Image();
			w19.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDelete.Image = w19;
			this.hbox4.Add(this.buttonDelete);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonDelete]));
			w20.Position = 4;
			w20.Expand = false;
			w20.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.fixed3 = new global::Gtk.Fixed();
			this.fixed3.WidthRequest = 60;
			this.fixed3.Name = "fixed3";
			this.fixed3.HasWindow = false;
			this.hbox4.Add(this.fixed3);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.fixed3]));
			w21.PackType = ((global::Gtk.PackType)(1));
			w21.Position = 5;
			w21.Expand = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Relief = ((global::Gtk.ReliefStyle)(1));
			this.buttonSave.Label = "Save";
			global::Gtk.Image w22 = new global::Gtk.Image();
			w22.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Button);
			this.buttonSave.Image = w22;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w23.PackType = ((global::Gtk.PackType)(1));
			w23.Position = 6;
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
			this.Show();
			this.buttonEdit.Clicked += new global::System.EventHandler(this.OnButtonEditClicked);
			this.buttonApplySize.Clicked += new global::System.EventHandler(this.OnButtonApplySizeClicked);
			this.buttonChooseBg.Clicked += new global::System.EventHandler(this.OnButtonChooseBgClicked);
			this.buttonApply.Clicked += new global::System.EventHandler(this.OnButtonApplyClicked);
			this.buttonDelete.Clicked += new global::System.EventHandler(this.OnButtonDeleteClicked);
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
		}
	}
}
