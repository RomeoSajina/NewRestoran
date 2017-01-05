using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;
namespace NewRestoran {

	public static class DBNarudzba {
	
		static DBNarudzba() {
			SqliteCommand com = DB.con.CreateCommand();
			com.CommandText = @"
			CREATE TABLE IF NOT EXISTS Narudzba (
				ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
				broj nvarchar(20) NOT NULL UNIQUE,
				datum integer NOT NULL,
				oznaka_potvrde nvarchar(15) NOT NULL CHECK(oznaka_potvrde IN('Potvrdeno', 'Nepotvrdeno')),
				id_stol integer,
				FOREIGN KEY(id_stol) REFERENCES Stol(ID))";

			com.ExecuteNonQuery();
			com.Dispose();
		}


		public static void SaveNarudzba(ref Narudzba n) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"INSERT INTO Narudzba (broj, datum, oznaka_potvrde, id_stol)
											VALUES ('{0}', '{1}', '{2}', {3})", n.Broj, n.Datum.ToFileTime(), n.Oznaka, 
			                                (n.StolNarudzbe == null) ? "NULL" : (object)n.StolNarudzbe.ID);
			com.ExecuteNonQuery();
			com.Dispose();

			SqliteCommand getId = DB.con.CreateCommand();
			getId.CommandText = "SELECT last_insert_rowid()";
			n.ID = (long)getId.ExecuteScalar();
			getId.Dispose();

			n.Broj = DateTime.Now.Year + "-" + n.ID.ToString("0000000000");
			UpdateNarudzba(n);
		}

		public static void UpdateNarudzba(Narudzba n) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"UPDATE Narudzba SET broj = '{0}', oznaka_potvrde = '{1}',id_stol = {2} WHERE id = {3} ",
			                                n.Broj, n.Oznaka, (n.StolNarudzbe == null) ? "NULL" : (object)n.StolNarudzbe.ID, n.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void DeleteNarudzba(Narudzba n) {
			SqliteCommand com = DB.con.CreateCommand();
		
			DBStavkeNarudzbe.DeleteStavke(n);
			com.CommandText = String.Format(@"DELETE FROM Narudzba WHERE id = {0}", n.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static List<Narudzba> GetNarudzbe() {
			List<Narudzba> narudzbe = new List<Narudzba>();
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT id, broj, datum, oznaka_potvrde, ifnull(id_stol,0) as id_stol FROM Narudzba WHERE oznaka_potvrde = 'Nepotvrdeno' ");

			SqliteDataReader reader = c.ExecuteReader();

			while(reader.Read()) {
				
				Narudzba n = new Narudzba((long)reader["id"], (string)reader["broj"], 
				                          DateTime.FromFileTime((Int64)reader["datum"]), 
				                          Narudzba.OznakaFromString((string)reader["oznaka_potvrde"]), 
				                          StoloviPresenter.stoloviList.Find(s => s.ID == (long)reader["id_stol"]));
				
				DBStavkeNarudzbe.GetStavke(ref n);
				narudzbe.Add(n);
			}
			c.Dispose();
			return narudzbe;
		}
	
	
	
	}
}
