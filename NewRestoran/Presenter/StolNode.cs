using System;
using Gtk;
namespace NewRestoran {

	public class StolNode : TreeNode{

		private string oznaka;
		private int brojStolica;
		public Stol stol { get; }

		[TreeNodeValue(Column = 0)]
		public string Oznaka {
			get { return oznaka; }
			set {
				stol.Oznaka = value;
				oznaka = stol.Oznaka;
			}
		}

		[TreeNodeValue(Column = 1)]
		public string BrojStolica {
			get { return brojStolica.ToString(); }
			set {
				stol.BrojStolica = int.Parse(value);
				brojStolica = stol.BrojStolica;
			}
		}

		public StolNode(Stol s){
			stol = s;
			oznaka = s.Oznaka;
			brojStolica = s.BrojStolica;
		}
	}
}
