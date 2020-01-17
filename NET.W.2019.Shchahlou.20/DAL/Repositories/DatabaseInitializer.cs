using System.Data.Entity;
using System.Text;

namespace DAL.Repositories
{
    public class DatabaseInitializer : IDatabaseInitializer<DatabaseRepository>
    {
        public void InitializeDatabase(DatabaseRepository context)
        {
            if (context.Database.Exists())
            {
                context.Database.Delete();
            }

            context.Database.Create();
        }
    }
}
