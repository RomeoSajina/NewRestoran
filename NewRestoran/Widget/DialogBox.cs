using System;
using Gtk;
namespace NewRestoran{
	
	public static class DialogBox{
	 
		public static void Show(Window window, MessageType msgType, string message){
			Dialog d = new Gtk.MessageDialog(window, DialogFlags.Modal, msgType, ButtonsType.Ok, message);
			d.SetPosition(WindowPosition.Center);
			d.Icon = Gdk.Pixbuf.LoadFromResource("NewRestoran.images.logo.png");
			d.Run();
			d.Destroy();
		}


		public static bool ShowDaNe (Window w, MessageType msgType, string message) {

			Dialog d = new Gtk.MessageDialog (w, DialogFlags.Modal, msgType, ButtonsType.None, message);
			d.AddButton ("Da", Gtk.ResponseType.Yes);
			d.AddButton ("Ne", Gtk.ResponseType.No);
			d.SetPosition (WindowPosition.Center);
			d.Icon = Gdk.Pixbuf.LoadFromResource("NewRestoran.images.logo.png");

			ResponseType rt = (ResponseType)d.Run ();
			d.Destroy ();
			if (rt == ResponseType.Yes) return true;
			return false;
		}

		public static void ShowNoneButtons(Window window, string message, uint timeout) {
			Dialog d = new Gtk.MessageDialog(window, DialogFlags.Modal, MessageType.Info, ButtonsType.None, message);
			d.SetPosition(WindowPosition.Center);
			d.Icon = Gdk.Pixbuf.LoadFromResource("NewRestoran.images.logo.png");
			GLib.Timeout.Add(timeout, () => { d.Destroy(); return false; });
			d.Run();
		}

		public static void ShowInfo (Window window, string message) { Show(window, MessageType.Info, message);}
		public static void ShowWarning (Window window, string message) { Show (window, MessageType.Warning, message); }
		public static void ShowError (Window window, string message) { Show (window, MessageType.Error, message); }

		public static bool ShowDaNeQuestion (Window window, string message) {
			return ShowDaNe(window, MessageType.Question, message); 
		}
		public static bool ShowDaNeWarning (Window window, string message) {
			return ShowDaNe (window, MessageType.Warning, message);
		}
		public static bool ShowDaNeInfo (Window window, string message) {
			return ShowDaNe (window, MessageType.Info, message);
		}

	}
}
