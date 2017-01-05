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

		public static void Update(string oldOznaka, string newOznaka, int brojStolica) {
			int index = stoloviList.FindIndex(s => s.Oznaka == oldOznaka);
			if(index >= 0) {
				stoloviList[index].Oznaka = newOznaka;
				stoloviList[index].BrojStolica = brojStolica ;
				DBStol.UpdateStol(stoloviList[index]);
				MainWindow.stolChanged();
			}
		}

		public static void Delete(Stol s) {
			stoloviList.Remove(s);
			DBStol.DeleteStol(s);
			MainWindow.stolChanged();
		}

		public static List<string> GetOznake() {
			List<string> oznakeList = new List<string>();
			stoloviList.ForEach(s => oznakeList.Add(s.Oznaka) );
			return oznakeList;
		}

		public static void CheckUniqueOznaka(Stol st, string NewOznaka) {
			if(stoloviList.Find(s => s.Oznaka == NewOznaka && s.ID != st.ID) != null)
				throw new ArgumentException("Oznaka stola mora biti jedinstvena.", nameof(NewOznaka));
		}

	}
}
