using LinqToDB;
using LinqToDB.Data;

namespace GoodsService__DAL.Enities;

public class DbConection : DataConnection
{
    public DbConection(string connectionString) : base("LinqToDB.DataProvider.PostgreSQL",
        connectionString)
    {
    }
    public ITable<Good> Goods => this.GetTable<Good>();
}