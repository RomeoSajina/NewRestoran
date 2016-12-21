using System;
using Gtk;
using Gdk;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;
namespace CustomWidgetLibrary{

	[System.ComponentModel.ToolboxItem (true)]
	public partial class FixedRestoranSheme : Gtk.Bin {

		private static Gtk.TargetEntry [] target_table =
			new TargetEntry [] {
				new TargetEntry ("text/uri-list", 0, 0),
			  	new TargetEntry ("application/x-table", 0, 1),
			};
		private static Gtk.TargetEntry [] source_table =
			new TargetEntry [] {
				new TargetEntry ("application/x-table", 0, 0),
			};

		private static Gdk.Pixbuf table2Chair = new Pixbuf (null, "CustomWidgetLibrary.images.table2chairs.png");
		private static Gdk.Pixbuf table4Chair = new Pixbuf (null, "CustomWidgetLibrary.images.table4chairs.png");
		private static Gdk.Pixbuf table6Chair = new Pixbuf (null, "CustomWidgetLibrary.images.table6chairs.png");
		private static Gdk.Pixbuf table8Chair = new Pixbuf (null, "CustomWidgetLibrary.images.table8chairs.png");
		private Gtk.Image choosedImg;
		private int size;
		private List<string> comboNamesList = new List<string> ();
		public bool ToolboxShown { get; set; }

		public FixedRestoranSheme(){
			this.Build();
			ToolboxShown = false;

			size = 60;
			Table2Chair.Add(new Gtk.Image(table2Chair.ScaleSimple(size, size, InterpType.Bilinear)));
			Table2Chair.ShowAll();
			Table4Chair.Add(new Gtk.Image(table4Chair.ScaleSimple(size, size, InterpType.Bilinear)));
			Table4Chair.ShowAll();
			Table6Chair.Add(new Gtk.Image(table6Chair.ScaleSimple(size, size, InterpType.Bilinear)));
			Table6Chair.ShowAll();
			Table8Chair.Add(new Gtk.Image(table8Chair.ScaleSimple(size, size, InterpType.Bilinear)));
			Table8Chair.ShowAll();

			Gtk.Drag.DestSet(fixedSheme, DestDefaults.All, target_table, Gdk.DragAction.Copy);
			fixedSheme.DragDataReceived += Data_Received;

			Gtk.Drag.SourceSet(Table2Chair, Gdk.ModifierType.Button1Mask, source_table, DragAction.Copy);
			Table2Chair.DragDataGet += Data_Get;
			Table2Chair.DragBegin += Drag_Begin;

			Gtk.Drag.SourceSet(Table4Chair, Gdk.ModifierType.Button1Mask, source_table, DragAction.Copy);
			Table4Chair.DragDataGet += Data_Get;
			Table4Chair.DragBegin += Drag_Begin;

			Gtk.Drag.SourceSet(Table6Chair, Gdk.ModifierType.Button1Mask, source_table, DragAction.Copy);
			Table6Chair.DragDataGet += Data_Get;
			Table6Chair.DragBegin += Drag_Begin;

			Gtk.Drag.SourceSet(Table8Chair, Gdk.ModifierType.Button1Mask, source_table, DragAction.Copy);
			Table8Chair.DragDataGet += Data_Get;
			Table8Chair.DragBegin += Drag_Begin;

			LoadFromXml();
		}

		protected void Drag_Begin(object o, DragBeginArgs args){
			string name;
			if (o is EventBox) name = (o as EventBox).Name;
			else name = (o as Button).Image.Name;

			switch (name){
				case "Table2Chair": Gtk.Drag.SetIconPixbuf(args.Context, table2Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
				case "Table4Chair": Gtk.Drag.SetIconPixbuf(args.Context, table4Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
				case "Table6Chair": Gtk.Drag.SetIconPixbuf(args.Context, table6Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
				case "Table8Chair": Gtk.Drag.SetIconPixbuf(args.Context, table8Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
			}
		}

		protected void Data_Get(object o, DragDataGetArgs args){
			Atom[] targets = args.Context.Targets;

			string name;
			if (o is EventBox) name = (o as EventBox).Name;
			else name = (o as Button).Image.Name;

			switch (name){
				case "Table2Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table2Chair")); break;
				case "Table4Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table4Chair")); break;
				case "Table6Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table6Chair")); break;
				case "Table8Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table8Chair")); break;
			}
		}

		protected void Data_Received(object o, DragDataReceivedArgs args){
			bool success = false;
			Gtk.Widget source = Gtk.Drag.GetSourceWidget(args.Context);
			string data = System.Text.Encoding.UTF8.GetString(args.SelectionData.Data);

			switch (args.Info){
				case 0:  // uri-list
					string[] uri_list = Regex.Split(data, "\r\n");
					foreach (string u in uri_list)
					{
						if (u.Length > 0)
							System.Console.WriteLine("Got URI {0}", u);
					}
					success = true;
					break;
				case 1: // table
					success = true;
					AddNewTableButtonImage("NewTable", data, args.X, args.Y, size);
					break;
			}
			Gtk.Drag.Finish(args.Context, success, true, args.Time);
		}


		protected void AddNewTableButtonImage(string name, string type, int x, int y, int size = 50){

			Gtk.Image img = new global::Gtk.Image();
			img.Name = type;
			switch (type){
				case "Table2Chair": img.Pixbuf = table2Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
				case "Table4Chair": img.Pixbuf = table4Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
				case "Table6Chair": img.Pixbuf = table6Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
				case "Table8Chair": img.Pixbuf = table8Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
			}

			Button button = new Button();
			button.Relief = ReliefStyle.None;

			button.Image = img;
			button.Name = name;
			Gtk.Drag.SourceSet(button, Gdk.ModifierType.Button1Mask, source_table, DragAction.Copy);

			button.FocusInEvent += (o, args) =>{
				fixedSheme.Foreach((b) =>{
					if (b is Button)
						(b as Button).Relief = ReliefStyle.None;
				});
				(o as Button).Relief = ReliefStyle.Half;
				labelOznaka.LabelProp = (o as Button).Name;
			};

			button.DragBegin += (o, args) => { (o as Button).Hide(); };
			button.DragBegin += Drag_Begin;
			button.DragDataGet += Data_Get;
			button.DragEnd += (o, args) => { (o as Button).Destroy(); };

			fixedSheme.Add(button);

			Fixed.FixedChild fc = ((Fixed.FixedChild)(fixedSheme[button]));
			fc.X = x;
			fc.Y = y;
			fixedSheme.ShowAll();
		}


		protected void OnButtonApplySizeClicked(object sender, EventArgs e){

			size = (int)spinbuttonSize.Value;

			fixedSheme.Foreach((b) =>{
				if (b is Button){
					switch (((b as Button).Image as Gtk.Image).Name){
						case "Table2Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table2Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
						case "Table4Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table4Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
						case "Table6Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table6Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
						case "Table8Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table8Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
					}
				}
			});
		}

		public void CreateBackgroundImage(Pixbuf pixbuf){

			choosedImg = new Gtk.Image();
			choosedImg.WidthRequest = fixedSheme.WidthRequest;
			choosedImg.HeightRequest = fixedSheme.HeightRequest;
			choosedImg.Name = "BGIMAGE";

			choosedImg.Pixbuf = pixbuf.ScaleSimple(fixedSheme.WidthRequest, fixedSheme.HeightRequest, InterpType.Bilinear);
			fixedSheme.Put(choosedImg, 0, 0);

			Fixed.FixedChild fcImg = ((Fixed.FixedChild)(fixedSheme[choosedImg]));
			fcImg.X = 0;
			fcImg.Y = 0;
			fixedSheme.ShowAll();

		}

		public void LoadFromXml(){

			if (System.IO.File.Exists("BackgroundImage.png")){
				CreateBackgroundImage(new Pixbuf("BackgroundImage.png"));
			}

			if (System.IO.File.Exists("TableSettings.xml")){
				XmlDocument doc = new XmlDocument();
				doc.Load("TableSettings.xml");

				XmlNodeList sizeList = doc.GetElementsByTagName("Size");
				size = int.Parse(sizeList[0].InnerText);
				spinbuttonSize.Value = size;

				XmlNodeList itemList = doc.GetElementsByTagName("Item");
				XmlNodeList detailsList;

				for (int i = 0; i < itemList.Count; i++){
					detailsList = itemList[i].ChildNodes;
					AddNewTableButtonImage(detailsList[0].InnerText, detailsList[3].InnerText, int.Parse(detailsList[1].InnerText), int.Parse(detailsList[2].InnerText), size);
				}
			}
		}


		protected void OnButtonChooseBgClicked(object sender, EventArgs e){
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog("Choose the file to open",
																		  this.TooltipWindow, FileChooserAction.Open,
																		  "Cancel", ResponseType.Cancel,
																		  "Open", ResponseType.Accept);

			if (filechooser.Run() == (int)ResponseType.Accept){
				System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);

				string[,] data = new string[fixedSheme.Children.Length, 4];
				int i = 0;

				fixedSheme.Foreach((b) =>{
					if (b is Button) {
						data [i, 0] = b.Name;
						data [i, 1] = (b as Button).Image.Name;
						data [i, 2] = fixedSheme.ChildGetProperty (b, "x").Val.ToString ();
						data [i, 3] = fixedSheme.ChildGetProperty (b, "y").Val.ToString ();
						i++;
					}
					fixedSheme.Remove (b);
				});

				CreateBackgroundImage (new Pixbuf (filechooser.Filename));

				for (int j = 0; j < i; j++)
					AddNewTableButtonImage(data[j, 0], data[j, 1], int.Parse(data[j, 2]), int.Parse(data[j, 3]), size);

				file.Close();
			}
			filechooser.Destroy();
		}

		protected void OnButtonApplyClicked(object sender, EventArgs e){
			fixedSheme.Foreach((b) =>{
				if (b is Button && (b as Button).Relief == ReliefStyle.Half){

					if (!(b as Button).Name.Equals("NewTable")){
						comboNamesList.Add(b.Name);
						comboboxName.AppendText(b.Name);
					}
					if (!comboboxName.ActiveText.Equals("")){
						b.Name = comboboxName.ActiveText;
						comboboxName.RemoveText(comboNamesList.FindIndex(x => x == b.Name));
						comboNamesList.Remove(b.Name);
						comboboxName.Active = 0;
					}
					else b.Name = "NewTable";

					labelOznaka.LabelProp = b.Name;
					return;
				}
			});
		}

		protected void OnButtonSaveClicked(object sender, EventArgs e){
			XmlDocument doc = new XmlDocument();
			doc.LoadXml("<TableSettings></TableSettings>");

			if (choosedImg != null){
				choosedImg.Pixbuf.Save("BackgroundImage.png", "png");
			}

			XmlElement sizeElem = doc.CreateElement("Size");
			sizeElem.InnerText = size.ToString();
			doc.DocumentElement.AppendChild(sizeElem);

			fixedSheme.Foreach((b) =>{
				if (b is Button){
					XmlElement data = doc.CreateElement("Item");

					XmlElement name = doc.CreateElement("Name");
					name.InnerText = b.Name;
					data.AppendChild(name);

					XmlElement x = doc.CreateElement("X");
					x.InnerText = fixedSheme.ChildGetProperty(b, "x").Val.ToString();
					data.AppendChild(x);

					XmlElement y = doc.CreateElement("Y");
					y.InnerText = fixedSheme.ChildGetProperty(b, "y").Val.ToString();
					data.AppendChild(y);

					XmlElement type = doc.CreateElement("Type");
					type.InnerText = (b as Button).Image.Name;
					data.AppendChild(type);

					doc.DocumentElement.AppendChild(data);
				}
			});

			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;

			XmlWriter writer = XmlWriter.Create("TableSettings.xml", settings);
			doc.Save(writer);
			writer.Close();
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e){
			fixedSheme.Foreach((b) =>{
				if (b is Button && (b as Button).Relief == ReliefStyle.Half){
					fixedSheme.Remove(b);
					return;
				}
			});
		}


		public void AddComboBoxValue(string s){
			bool postoji = false;
			fixedSheme.Foreach(b => {
				if (b is Button && (b as Button).Name.Equals(s)) {
					postoji = true;
					return;
				}
			});
			if (postoji) return;
			comboNamesList.Add(s);
			comboboxName.AppendText(s);
		}

		public void ShowToolbox() {
			hbox1.ShowAll();
			hbox4.ShowAll();
			vbox6.ShowAll();
			buttonEdit.Label = "Finish";
			buttonEdit.Image = new Gtk.Image (Stetic.IconLoader.LoadIcon (this, "gtk-ok", global::Gtk.IconSize.Menu));
			ToolboxShown = true;
		}

		public void HideToolbox() {
			hbox1.Hide();
			hbox4.Hide();
			vbox6.Hide();
			buttonEdit.Label = "Edit";
			buttonEdit.Image = new Gtk.Image (Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu));
			ToolboxShown = false;
		}

		protected void OnButtonEditClicked (object sender, EventArgs e) {
			if (ToolboxShown) {
				HideToolbox();
			} else {
				ShowToolbox();
			}
		}


	}
}
