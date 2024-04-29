namespace TestTaskForETAI__GoodsService.Data_Access_Layer.Enities;

public class DbConnect
{
    public DbConection(IConfiguration configuration) : base("LinqToDB.DataProvider.PostgreSQL", 
        configuration.GetConnectionString("DB"))
    {
    }
    public ITable<Category> Categories => this.GetTable<Category>();
}