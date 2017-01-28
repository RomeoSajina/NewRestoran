using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;
namespace NewRestoran {
	
	public static class DBStol {
	
		static DBStol() {
			SqliteCommand com = DB.con.CreateCommand();
			com.CommandText = @"
			CREATE TABLE IF NOT EXISTS Stol (
				ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
				oznaka nvarchar(20) NOT NULL UNIQUE,
				broj_stolica integer NOT NULL)";

			com.ExecuteNonQuery();
			com.Dispose();
		}
	
		public static void SaveStol(ref Stol s) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"INSERT INTO Stol (oznaka, broj_stolica)
				VALUES ('{0}', {1})", s.Oznaka, s.BrojStolica);

			com.ExecuteNonQuery();
			com.Dispose();

			SqliteCommand getId = DB.con.CreateCommand();
			getId.CommandText = "SELECT last_insert_rowid()";
			s.ID = (long)getId.ExecuteScalar();
			getId.Dispose();
		}

		public static void UpdateStol(Stol s) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"UPDATE Stol SET oznaka = '{0}', broj_stolica = {1} WHERE id = {2} ",
			                                s.Oznaka, s.BrojStolica, s.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void DeleteStol(Stol s) {
			SqliteCommand com = DB.con.CreateCommand();
			System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(DBNarudzba).TypeHandle);

			com.CommandText = String.Format(@"UPDATE Narudzba SET id_stol = NULL WHERE id_stol = {0}", s.ID);
			com.ExecuteNonQuery();

			com.CommandText = String.Format(@"DELETE FROM Stol WHERE id = {0}", s.ID);
			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static List<Stol> GetStolove() {
			List<Stol> stolovi = new List<Stol>();
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT * FROM Stol");

			SqliteDataReader reader = c.ExecuteReader();

			while(reader.Read()) {

				Stol s = new Stol((long)reader["id"], (string)reader["oznaka"], (int)reader.GetInt64(2));
				stolovi.Add(s);
			}
			c.Dispose();
			return stolovi;
		}



	}
}
