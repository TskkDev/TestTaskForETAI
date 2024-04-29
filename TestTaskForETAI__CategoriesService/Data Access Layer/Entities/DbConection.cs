using System.Data.Common;
using LinqToDB;
using LinqToDB.Data;

namespace TestTaskForETAI__CategoriesService.Entity;

public class DbConection : DataConnection
{
    public DbConection(IConfiguration configuration) : base("LinqToDB.DataProvider.PostgreSQL", 
        configuration.GetConnectionString("DB"))
    {
    }
    public ITable<Category> Categories => this.GetTable<Category>();
}