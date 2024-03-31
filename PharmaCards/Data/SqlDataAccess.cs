using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Dapper;
using System.Data;
using SQLite;
using System.Threading.Tasks;
using System.IO;

namespace PharmaCards.Data
{
    public class SqlDataAccess
    {
        /*
        public static List<MedicamentsModel> LoadMedicament()
        {
            string connectionString = "Data Source=.\\Cards.db";
            using (IDbConnection connectiion = new SQLiteConnection(connectionString))
            {
                var output = connectiion.Query<MedicamentsModel>("SELECT * FROM Medicament", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveMedicament(MedicamentsModel medicament)
        {
            string connectionString = "Data Source=.\\Cards.db";
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute("INSERT INTO Medicament(Name, ) VALUES (@Name)", medicament);
            }
        }
        */

        SQLiteAsyncConnection DB;

        public SqlDataAccess()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("PharmaCards.Assets.Cards.db"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    File.WriteAllBytes(Constants.DatabasePath, ms.ToArray());
                }
            }
        }

        async Task Init()
        {
            if(DB is not null)
                return;
            
            DB = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public async Task<List<MedicamentModel>> LoadMedicament()
        {
            await Init();
            return await DB.Table<MedicamentModel>().ToListAsync();
        }
    }
}
