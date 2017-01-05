using System;
using Mono.Data.Sqlite;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace NewRestoran {

	public static class DBStavkeNarudzbe {
	
		static DBStavkeNarudzbe() {
			SqliteCommand com = DB.con.CreateCommand();
			com.CommandText = @"
				CREATE TABLE IF NOT EXISTS Stavka_Narudzbe (
					ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
					id_narudzba integer NOT NULL,
					id_artikl integer NOT NULL,
					kolicina integer NOT NULL,
					status nvarchar(20) NOT NULL CHECK(status IN('NaCekanju', 'UObradi', 'Gotovo', 'Dostavljeno')),
					UNIQUE(id_narudzba, id_artikl),
					FOREIGN KEY(id_narudzba) REFERENCES Narudzba(ID),
					FOREIGN KEY(id_artikl) REFERENCES Artikl(ID))";

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void SaveStavka(Narudzba n, ref NarudzbaStavka ns) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"INSERT INTO Stavka_Narudzbe (id_narudzba, id_artikl, kolicina, status)
				VALUES ({0}, {1}, {2}, '{3}')", n.ID, ns.ArtiklStavke.ID, ns.Kolicina, ns.Status);

			com.ExecuteNonQuery();	

			SqliteCommand getId = DB.con.CreateCommand();
			getId.CommandText = "SELECT last_insert_rowid()";
			ns.ID = (long)getId.ExecuteScalar();

			com.Dispose();
		}

		public static void UpdateStavka(NarudzbaStavka ns) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"UPDATE Stavka_Narudzbe SET id_artikl = {0}, kolicina = {1}, status = '{2}' WHERE id = {3} ",
			                                ns.ArtiklStavke.ID, ns.Kolicina, ns.Status, ns.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void DeleteStavka(NarudzbaStavka ns) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"DELETE FROM Stavka_Narudzbe WHERE id = {0}", ns.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void DeleteStavke(Narudzba n) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"DELETE FROM Stavka_Narudzbe WHERE id_narudzba = {0}", n.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void GetStavke(ref Narudzba n) {
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT * FROM Stavka_Narudzbe WHERE id_narudzba = {0}", n.ID);

			SqliteDataReader reader = c.ExecuteReader();

			while(reader.Read()) {
				NarudzbaStavka ns = new NarudzbaStavka((long)reader["id"], ArtikliPresenter.GetArtikl((long)reader["id_artikl"]), 
				                                       (int)reader.GetInt64(3), NarudzbaStavka.StatusFromString((string)reader["status"]));
				n.Stavke.Add(ns);
			}
			c.Dispose();
		}

	
	
	
	}
}
