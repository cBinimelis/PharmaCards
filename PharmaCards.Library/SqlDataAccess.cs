using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace PharmaCards.Library
{
    public class SqlDataAccess
    {
        public static List<MedicamentsModel> LoadMedicament()
        {
            string connectionString = "Data Source=Cards.db";
            using (IDbConnection connectiion = new SqliteConnection(connectionString))
            {
                var output = connectiion.Query<MedicamentsModel>("SELECT * FROM Medicament", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveMedicament(MedicamentsModel medicament)
        {
            string connectionString = "Data Source=Cards.db";
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Execute("INSERT INTO Medicament(Name, ) VALUES (@Name)", medicament);
            }
        }
    }
}
