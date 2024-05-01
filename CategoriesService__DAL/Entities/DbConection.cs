using LinqToDB;
using LinqToDB.Data;

namespace CategoriesService__DAL.Entities;

public class DbConection : DataConnection
{
    public DbConection(string connectionString) : base("LinqToDB.DataProvider.PostgreSQL",
        connectionString)
    {
    }
    public ITable<Category> Categories => this.GetTable<Category>();
}