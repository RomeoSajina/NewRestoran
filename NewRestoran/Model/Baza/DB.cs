using System;
using Mono.Data.Sqlite;
namespace NewRestoran {

	public static class DB {
		private static string connectionString = "URI=file:NewRestoran.db,version=3";

		internal static SqliteConnection con = new SqliteConnection(connectionString);

		internal static void OpenConnection() {
			con.Open();
		}

		internal static void CloseConnection() {
			con.Close();
		}
	}
}
