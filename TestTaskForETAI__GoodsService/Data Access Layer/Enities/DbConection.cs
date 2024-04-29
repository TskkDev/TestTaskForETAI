using LinqToDB;
using LinqToDB.Data;

namespace TestTaskForETAI__GoodsService.Data_Access_Layer.Enities;

public class DbConection: DataConnection
{
    public DbConection(IConfiguration configuration) : base("LinqToDB.DataProvider.PostgreSQL", 
        configuration.GetConnectionString("DB"))
    {
    }
    public ITable<Good> Goods => this.GetTable<Good>();
}