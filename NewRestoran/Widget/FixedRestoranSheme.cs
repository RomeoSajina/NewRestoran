﻿using System;
using Gtk;
using Gdk;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;
namespace NewRestoran {

	[System.ComponentModel.ToolboxItem(true)]
	public partial class FixedRestoranSheme : Gtk.Bin {

		private static Gtk.TargetEntry[] target_table =
			new TargetEntry[] {
				new TargetEntry ("text/uri-list", 0, 0),
			  	new TargetEntry ("application/x-table", 0, 1),
			};
		private static Gtk.TargetEntry[] source_table =
			new TargetEntry[] {
				new TargetEntry ("application/x-table", 0, 0),
			};

		private static Gdk.Pixbuf table2Chair = new Pixbuf(null, "NewRestoran.images.table2chairs.png");
		private static Gdk.Pixbuf table4Chair = new Pixbuf(null, "NewRestoran.images.table4chairs.png");
		private static Gdk.Pixbuf table6Chair = new Pixbuf(null, "NewRestoran.images.table6chairs.png");
		private static Gdk.Pixbuf table8Chair = new Pixbuf(null, "NewRestoran.images.table8chairs.png");
		private Gtk.Image choosedImg;
		private int size;
		public bool ToolboxShown { get; set; }
		public delegate void TableSelection(string name);
		public TableSelection TableSelected;

		public FixedRestoranSheme() {
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

			fixedSheme.HeightRequest = (int)(Gdk.Screen.Default.Height / 1.35);
			fixedSheme.WidthRequest = (int)(fixedSheme.HeightRequest / 1.35);

			LoadFromXml();


			Color c = new Color();
			Color.Parse("#00bd00", ref c);
			labelSpremljeno.ModifyFg(StateType.Normal, c);
		}

		protected void Drag_Begin(object o, DragBeginArgs args) {
			string name;
			if(o is EventBox) name = (o as EventBox).Name;
			else name = (o as Button).Image.Name;

			switch(name) {
			case "Table2Chair": Gtk.Drag.SetIconPixbuf(args.Context, table2Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
			case "Table4Chair": Gtk.Drag.SetIconPixbuf(args.Context, table4Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
			case "Table6Chair": Gtk.Drag.SetIconPixbuf(args.Context, table6Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
			case "Table8Chair": Gtk.Drag.SetIconPixbuf(args.Context, table8Chair.ScaleSimple(size, size, InterpType.Bilinear), -5, -5); break;
			}
		}

		protected void Data_Get(object o, DragDataGetArgs args) {
			Atom[] targets = args.Context.Targets;

			string name;
			if(o is EventBox) name = (o as EventBox).Name;
			else name = (o as Button).Image.Name;

			switch(name) {
			case "Table2Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table2Chair")); break;
			case "Table4Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table4Chair")); break;
			case "Table6Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table6Chair")); break;
			case "Table8Chair": args.SelectionData.Set(targets[0], 8, System.Text.Encoding.UTF8.GetBytes("Table8Chair")); break;
			}
		}

		protected void Data_Received(object o, DragDataReceivedArgs args) {
			bool success = false;
			Gtk.Widget source = Gtk.Drag.GetSourceWidget(args.Context);
			string data = System.Text.Encoding.UTF8.GetString(args.SelectionData.Data);

			switch(args.Info) {
			case 0:  // uri-list
				string[] uri_list = Regex.Split(data, "\r\n");
				foreach(string u in uri_list) {
					//if(u.Length > 0)
					//System.Console.WriteLine("Got URI {0}", u);
				}
				success = true;
				break;
			case 1: // table
				success = true;
				string name = "NewTable";
				if(source is Button) { // Samo razmještaj stola
					name = (source as Button).Name;
				} else {  //Drag&Drop novog stola - INSERT
					int brojStolica;
					switch(data) { 
						case "Table2Chair": brojStolica = 2; break;
						case "Table4Chair": brojStolica = 4; break;
						case "Table6Chair": brojStolica = 6; break;
						case "Table8Chair": brojStolica = 8; break;
						default: brojStolica = 2; break;
					}

					bool notUnique = true;
					for(int i = 1; notUnique; i++) { 
						name = "NewTable"+i;
						Stol s = new Stol(name, brojStolica);
						try {
							StoloviPresenter.CheckUniqueOznaka(s, name);
							StoloviPresenter.Add(s);
							notUnique = false;
						} catch(ArgumentException){}
					}
					entryOznaka.Text = "";
				}

				AddNewTableButtonImage(name, data, args.X, args.Y, size);
				SaveToXml();
				break;
			}
			Gtk.Drag.Finish(args.Context, success, true, args.Time);
		}


		protected void AddNewTableButtonImage(string name, string type, int x, int y, int size = 50) {

			Gtk.Image img = new global::Gtk.Image();
			img.Name = type;
			switch(type) {
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

			button.FocusInEvent += (o, args) => {
				fixedSheme.Foreach((b) => {
					if(b is Button)
						(b as Button).Relief = ReliefStyle.None;
				});
				(o as Button).Relief = ReliefStyle.Half;
				labelOznakaStola.LabelProp = (o as Button).Name;
				entryOznaka.Text = (o as Button).Name;
				OnTableSelection(((o as Button)).Name);
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

		protected void OnTableSelection(string name) {
			TableSelection ts = TableSelected; 
			if(ts != null) {
				ts(name);
			}
		}

		protected void OnButtonApplySizeClicked(object sender, EventArgs e) {
			size = (int)hscaleSize.Value;

			fixedSheme.Foreach((b) => {
				if(b is Button) {
					switch(((b as Button).Image as Gtk.Image).Name) {
					case "Table2Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table2Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
					case "Table4Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table4Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
					case "Table6Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table6Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
					case "Table8Chair": ((b as Button).Image as Gtk.Image).Pixbuf = table8Chair.ScaleSimple(size, size, InterpType.Bilinear); break;
					}
				}
			});
			SaveToXml();
		}

		public void CreateBackgroundImage(Pixbuf pixbuf) {

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

		public void LoadFromXml() {

			if(System.IO.File.Exists("BackgroundImage.png")) {
				CreateBackgroundImage(new Pixbuf("BackgroundImage.png"));
			}

			if(System.IO.File.Exists("TableSettings.xml")) {
				XmlDocument doc = new XmlDocument();
				doc.Load("TableSettings.xml");

				XmlNodeList sizeList = doc.GetElementsByTagName("Size");
				size = int.Parse(sizeList[0].InnerText);
				hscaleSize.Value = size;

				XmlNodeList itemList = doc.GetElementsByTagName("Item");
				XmlNodeList detailsList;

				for(int i = 0; i < itemList.Count; i++) {
					detailsList = itemList[i].ChildNodes;
					AddNewTableButtonImage(detailsList[0].InnerText, detailsList[3].InnerText, int.Parse(detailsList[1].InnerText), int.Parse(detailsList[2].InnerText), size);
				}
			}
		}


		protected void OnButtonChooseBgClicked(object sender, EventArgs e) {
			Gtk.FileChooserDialog filechooser = new Gtk.FileChooserDialog("Choose the file to open",
																		  this.TooltipWindow, FileChooserAction.Open,
																		  "Cancel", ResponseType.Cancel,
																		  "Open", ResponseType.Accept);

			if(filechooser.Run() == (int)ResponseType.Accept) {
				System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);

				string[,] data = new string[fixedSheme.Children.Length, 4];
				int i = 0;

				fixedSheme.Foreach((b) => {
					if(b is Button) {
						data[i, 0] = b.Name;
						data[i, 1] = (b as Button).Image.Name;
						data[i, 2] = fixedSheme.ChildGetProperty(b, "x").Val.ToString();
						data[i, 3] = fixedSheme.ChildGetProperty(b, "y").Val.ToString();
						i++;
					}
					fixedSheme.Remove(b);
				});

				CreateBackgroundImage(new Pixbuf(filechooser.Filename));

				for(int j = 0; j < i; j++)
					AddNewTableButtonImage(data[j, 0], data[j, 1], int.Parse(data[j, 2]), int.Parse(data[j, 3]), size);

				file.Close();
			}
			filechooser.Destroy();

			choosedImg.Pixbuf.Save("BackgroundImage.png", "png");
			hboxSpremljeno.Show();
			GLib.Timeout.Add(2000, () => { hboxSpremljeno.Hide(); return false; });
		}

		protected void OnButtonApplyClicked(object sender, EventArgs e) {
			fixedSheme.Foreach((b) => {
				if(b is Button && (b as Button).Relief == ReliefStyle.Half) {
					try {
						StoloviPresenter.CheckUniqueOznaka(StoloviPresenter.GetStol(b.Name), entryOznaka.Text);
						StoloviPresenter.Update(b.Name, entryOznaka.Text);
						b.Name = entryOznaka.Text;
						labelOznakaStola.Text = entryOznaka.Text;
						SaveToXml();
						OnTableSelection(b.Name);
					} catch(ArgumentException ae) {
						DialogBox.ShowError(new Gtk.Window(Gtk.WindowType.Popup), ae.Message);
					}
					return;
				}
			});
		}

		protected void SaveToXml() { 
			XmlDocument doc = new XmlDocument();
			doc.LoadXml("<TableSettings></TableSettings>");

			XmlElement sizeElem = doc.CreateElement("Size");
			sizeElem.InnerText = size.ToString();
			doc.DocumentElement.AppendChild(sizeElem);

			fixedSheme.Foreach((b) => {
				if(b is Button) {
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
			hboxSpremljeno.Show();
			GLib.Timeout.Add(2000, () => { hboxSpremljeno.Hide(); return false; });
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e) {
			fixedSheme.Foreach((b) => {
				if(b is Button && (b as Button).Relief == ReliefStyle.Half) {
					StoloviPresenter.Delete(b.Name);
					fixedSheme.Remove(b);
					SaveToXml();
					return;
				}
			});
		}

		public void SelectTable(string name) {
			bool postoji = false;
			fixedSheme.Foreach(b => {
				if(b is Button && b.Name == name) {
					b.GrabFocus();
					postoji = true;
					return;
				} else if(b is Button) (b as Button).Relief = ReliefStyle.None;
			});
			if(!postoji) {
				labelOznakaStola.LabelProp = "";
				entryOznaka.Text = "";
			}
		}

		public string GetSelected() {
			foreach(Widget w in fixedSheme) {
				if(w is Button && (w as Button).Relief == ReliefStyle.Half) return w.Name;
			}
			return "-";
		}

		public void ShowToolbox() {
			hbox1.ShowAll();
			hbox4.ShowAll();
			vbox6.ShowAll();
			hboxSpremljeno.Hide();
			buttonEdit.Label = "Finish";
			buttonEdit.Image = new Gtk.Image(Stetic.IconLoader.LoadIcon(this, "gtk-ok", global::Gtk.IconSize.Menu));
			hboxPrikazOznake.Hide();
			ToolboxShown = true;

			fixedSheme.Foreach(b => {
				if(b is Button) {
					Gtk.Drag.SourceSet((b as Button), Gdk.ModifierType.Button1Mask, source_table, DragAction.Copy);
				}
			});
		}

		public void HideToolbox() {
			hbox1.Hide();
			hbox4.Hide();
			vbox6.Hide();
			buttonEdit.Label = "Edit";
			buttonEdit.Image = new Gtk.Image(Stetic.IconLoader.LoadIcon(this, "gtk-edit", global::Gtk.IconSize.Menu));
			hboxPrikazOznake.Show();
			ToolboxShown = false;

			fixedSheme.Foreach(b => {
				if(b is Button) {
					Gtk.Drag.SourceUnset((b as Button));
				}
			});
		}

		protected void OnButtonEditClicked(object sender, EventArgs e) {
			if(ToolboxShown) {
				HideToolbox();
			} else {
				ShowToolbox();
			}
		}

		public int Width{ get { return fixedSheme.WidthRequest; } }
		public int Height { get { return fixedSheme.HeightRequest; } }
	}
}
