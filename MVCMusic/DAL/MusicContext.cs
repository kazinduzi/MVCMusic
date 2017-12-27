using MVCMusic.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCMusic.DAL
{
    public class MusicContext : DbContext
    {

        public MusicContext() : base("MusicContext")
        {
            //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        public DbSet<CustomerModel> Customers { get; set; }

        public DbSet<MovieModel> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }
    }
}