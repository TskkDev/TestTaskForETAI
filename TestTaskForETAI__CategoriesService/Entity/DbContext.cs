using System.Data.Common;
using LinqToDB;
using LinqToDB.Data;

namespace TestTaskForETAI__CategoriesService.Entity;

public class DbContext : DataConnection
{
    public DbContext(IConfiguration configuration) : base(configuration.GetConnectionString("Db"))
    {
    }
    public ITable<Category> Categories => this.GetTable<Category>();
}