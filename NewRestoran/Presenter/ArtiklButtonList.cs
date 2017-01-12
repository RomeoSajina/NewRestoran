using System;
using System.Collections.Generic;
namespace NewRestoran {
	public class ArtiklButtonList {

		private List<ArtiklButton> artikliButton = new List<ArtiklButton>();

		public List<ArtiklButton> ArtikliButton {
			get {return artikliButton;}
		}

		public ArtiklButtonList() { }

		public void RefreshWithCommon() {
			artikliButton.Clear();
			DBArtikl.GetArtikleReadOnly().ForEach(a => artikliButton.Add(new ArtiklButton(a)));
		}

		private void RefreshFromOznaka(Artikl.OznakaArtikla oznaka) {
			artikliButton.Clear();
			DBArtikl.GetArtikleReadOnly(oznaka).ForEach(a => artikliButton.Add(new ArtiklButton(a)));
		}

		public void RefreshWithHrana() { RefreshFromOznaka(Artikl.OznakaArtikla.Hrana); }
		public void RefreshWithPice() { RefreshFromOznaka(Artikl.OznakaArtikla.Pice); }
		public void RefreshWithDesert(){ RefreshFromOznaka(Artikl.OznakaArtikla.Desert);}
		public void RefreshWithOstalo() { RefreshFromOznaka(Artikl.OznakaArtikla.Ostalo); }



	}
}
