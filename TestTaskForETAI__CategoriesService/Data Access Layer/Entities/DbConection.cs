using LinqToDB;
using LinqToDB.Data;

namespace TestTaskForETAI__CategoriesService.Data_Access_Layer.Entities;

public class DbConection : DataConnection
{
    public DbConection(IConfiguration configuration) : base("LinqToDB.DataProvider.PostgreSQL", 
        configuration.GetConnectionString("DB"))
    {
    }
    public ITable<Category> Categories => this.GetTable<Category>();
}