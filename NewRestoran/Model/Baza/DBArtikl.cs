using System;
using Mono.Data.Sqlite;
using System.Collections.Generic;
namespace NewRestoran {

	public static class DBArtikl {

		private static System.Globalization.CultureInfo customCulture;

		static DBArtikl() {
			SqliteCommand com = DB.con.CreateCommand();
			com.CommandText = @"
				CREATE TABLE IF NOT EXISTS Artikl (
					ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
					sifra nvarchar(20) NOT NULL UNIQUE,
					naziv nvarchar(30) NOT NULL,
					duzi_naziv nvarchar(40),
					sastav nvarchar(60) NOT NULL,
					cijena numeric NOT NULL,
					oznaka nvarchar(10) NOT NULL CHECK(oznaka IN('Hrana', 'Pice', 'Desert', 'Ostalo')))";

			com.ExecuteNonQuery();
			com.Dispose();

			customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

		}

		public static void SaveArtikl(ref Artikl a) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"INSERT INTO Artikl (sifra, naziv, duzi_naziv, sastav, cijena, oznaka)
											  VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", a.Sifra, a.Naziv, 
			                                  a.DuziNaziv, a.Sastav, a.Cijena.ToString(customCulture), a.Oznaka );
			com.ExecuteNonQuery();
			com.Dispose();

			SqliteCommand getId = DB.con.CreateCommand();
			getId.CommandText = "SELECT last_insert_rowid()";
			a.ID = (long)getId.ExecuteScalar();
			getId.Dispose();

		}

		public static void UpdateArtikl(Artikl a) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"UPDATE Artikl SET sifra = '{0}', naziv = '{1}', duzi_naziv = '{2}', sastav  = '{3}',
											 cijena = '{4}', oznaka = '{5}' WHERE id = {6} ", 
			                                a.Sifra, a.Naziv, a.DuziNaziv, a.Sastav, a.Cijena.ToString(customCulture), a.Oznaka, a.ID);
			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static void DeleteArtikl(Artikl a) {
			SqliteCommand com = DB.con.CreateCommand();

			com.CommandText = String.Format(@"DELETE FROM Artikl WHERE id = {0}", a.ID);

			com.ExecuteNonQuery();
			com.Dispose();
		}

		public static List<Artikl> GetArtikle() {
			List<Artikl> artikli = new List<Artikl>();
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT * FROM Artikl");

			SqliteDataReader reader = c.ExecuteReader();

			while(reader.Read()) {
				Artikl a = new Artikl((long)reader["ID"], (string)reader["sifra"], (string)reader["naziv"], 
				                      (string)reader["duzi_naziv"], (float)reader.GetDecimal(5), (string)reader["sastav"],
				                      Artikl.OznakaFromString((string)reader["oznaka"]));
				artikli.Add(a);
			}
			c.Dispose();
			return artikli;
		}

		public static List<Artikl> GetArtikleReadOnly(Artikl.OznakaArtikla oznaka) {
			List<Artikl> artikli = new List<Artikl>();
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT * FROM Artikl WHERE oznaka = '{0}'", oznaka);
			
			SqliteDataReader reader = c.ExecuteReader();

			while(reader.Read()) {
				Artikl a = new Artikl((long)reader["ID"], (string)reader["sifra"], (string)reader["naziv"],
									  (string)reader["duzi_naziv"], (float)reader.GetDecimal(5), (string)reader["sastav"],
									  Artikl.OznakaFromString((string)reader["oznaka"]));
				artikli.Add(a);
			}
			c.Dispose();
			return artikli;
		}

		public static List<Artikl> GetArtikleReadOnly() {
			List<Artikl> artikli = new List<Artikl>();
			SqliteCommand c = DB.con.CreateCommand();

			c.CommandText = String.Format(@"SELECT * FROM Artikl a 
											ORDER BY (SELECT COUNT(*) FROM Stavka_Narudzbe WHERE id_artikl = a.id) DESC");
			
			SqliteDataReader reader = c.ExecuteReader();

			while(reader.Read()) {
				Artikl a = new Artikl((long)reader["ID"], (string)reader["sifra"], (string)reader["naziv"],
									  (string)reader["duzi_naziv"], (float)reader.GetDecimal(5), (string)reader["sastav"],
									  Artikl.OznakaFromString((string)reader["oznaka"]));
				artikli.Add(a);
			}
			c.Dispose();
			return artikli;
		}
	}
}
