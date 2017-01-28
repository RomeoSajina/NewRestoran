using System;
using Gtk;
using System.Collections.Generic;
namespace NewRestoran {
	
	public static class StoloviPresenter {

		public static List<Stol> stoloviList = new List<Stol>();

		static StoloviPresenter() {
			stoloviList.Add(new Stol("-", 1));
			stoloviList.AddRange(DBStol.GetStolove());
		}

		public static void Add(Stol s) {
			stoloviList.Add(s);
			DBStol.SaveStol(ref s);
			MainWindow.stolChanged();
		}

		public static void Update(string oldOznaka, string newOznaka) {
			int index = stoloviList.FindIndex(s => s.Oznaka == oldOznaka);
			if(index >= 0) {
				stoloviList[index].Oznaka = newOznaka;
				DBStol.UpdateStol(stoloviList[index]);
				MainWindow.stolChanged();
			}
		}

		public static Stol GetStol(string oznaka) {
			return stoloviList.Find(s => s.Oznaka == oznaka);
		}

		public static void Delete(Stol s) {
			stoloviList.Remove(s);
			DBStol.DeleteStol(s);
			MainWindow.stolChanged();
		}

		public static void Delete(string oznaka) {
			Delete(GetStol(oznaka));
		}

		public static void CheckUniqueOznaka(Stol st, string NewOznaka) {
			if(stoloviList.Find(s => s.Oznaka == NewOznaka && s.ID != st.ID) != null)
				throw new ArgumentException("Oznaka stola mora biti jedinstvena.");
		}

	}
}
