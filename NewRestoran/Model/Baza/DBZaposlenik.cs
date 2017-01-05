using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;
namespace NewRestoran {

	public static class DBZaposlenik {

		static DBZaposlenik() {
			SqliteCommand com = DB.con.CreateCommand();
			com.CommandText = @"
			CREATE TABLE IF NOT EXISTS Zaposlenik (
				ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
				ime nvarchar(20) NOT NULL,
				prezime nvarchar(20) NOT NULL,
				password nvarchar(20) NOT NULL,
				datum_zaposlenja integer NOT NULL,
				status nvarchar(20) NOT NULL CHECK(status IN('StalniRadnik', 'StalniSezonac', 'Sezonac')),
				uloga nvarchar(20) NOT NULL CHECK(uloga IN('Konobar', 'Kuhar', 'Sef')) )";

			com.ExecuteNonQuery();

			com.CommandText = @"SELECT COUNT(*) FROM Zaposlenik";

			if((long)com.ExecuteScalar() == 0) {
				com.CommandText = String.Format(@"INSERT INTO Zaposlenik (ime, prezime, password, datum_zaposlenja, status, uloga)
				VALUES ('Admin', 'Admin', 'Admin', {0}, 'StalniRadnik', 'Sef')", DateTime.Now.Date.ToFileTime());
				com.ExecuteNonQuery();
			}
		
			com.Dispose();
		}
		public static void SaveZaposlenik(ref Zaposlenik z) {
		SqliteCommand com = DB.con.CreateCommand();

		com.CommandText = String.Format(@"INSERT INTO Zaposlenik (ime, prezime, password, datum_zaposlenja, status, uloga)
				VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", z.Ime, z.Prezime, z.Password, z.DatumZaposlenja.ToFileTime(), z.Status, z.Uloga );

			com.ExecuteNonQuery();
			com.Dispose();

			SqliteCommand getId = DB.con.CreateCommand();
			getId.CommandText = "SELECT last_insert_rowid()";
			z.ID = (long)getId.ExecuteScalar();
			getId.Dispose();
		}

		public static void UpdateZaposlenik(Zaposlenik z) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"UPDATE Zaposlenik SET ime = '{0}', prezime = '{1}', password = '{2}', datum_zaposlenja = '{3}', 
											status = '{4}', uloga = '{5}'  WHERE id = {6} ",
			                                z.Ime, z.Prezime, z.Password, z.DatumZaposlenja.ToFileTime(), z.Status, z.Uloga, z.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void DeleteZaposlenik(Zaposlenik z) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"DELETE FROM Zaposlenik WHERE id = {0}", z.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static List<Zaposlenik> GetZaposlenike() {
			List<Zaposlenik> zaposlenici = new List<Zaposlenik>();
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT * FROM Zaposlenik");

			SqliteDataReader reader = c.ExecuteReader();

			while(reader.Read()) {

				Zaposlenik z = new Zaposlenik((long)reader["id"], (string)reader["ime"], (string)reader["prezime"], 
				                              (string)reader["password"], DateTime.FromFileTime((Int64)reader["datum_zaposlenja"]),
				                              Zaposlenik.StatusFromString((string)reader["status"]), Zaposlenik.UlogaFromString((string)reader["uloga"]));
				zaposlenici.Add(z);
			}
			c.Dispose();
			return zaposlenici;
		}

		public static Zaposlenik GetZaposlenik(string ime, string password) { 
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT * FROM Zaposlenik WHERE ime = '{0}' AExecuteReader '{1}' ", ime, password);

			SqliteDataReader reader = c.ExecuteReader();

			Zaposlenik z;

			if(!reader.HasRows)
				z = null;
			else {
				reader.Read();
				z = new Zaposlenik((long)reader["id"], (string)reader["ime"], (string)reader["prezime"],
								   (string)reader["password"], DateTime.FromFileTime((Int64)reader["datum_zaposlenja"]),
								   Zaposlenik.StatusFromString((string)reader["status"]), Zaposlenik.UlogaFromString((string)reader["uloga"]));
			}
			c.Dispose();
			return z;
		}


	
	}
}
