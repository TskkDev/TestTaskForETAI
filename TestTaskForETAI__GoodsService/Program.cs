using GoodsService__BLL.Interface;
using GoodsService__BLL.Managers;
using GoodsService__WebApi.MassTransit.ModifyConsumers;
using GoodsService__WebApi.MassTransit.ResponseConsumers;
using MassTransit;
using SharedModels.MessageModels;
using SharedModels.ResponseModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();

    x.AddRequestClient<GoodsListMessage>();
    x.AddRequestClient<GoodResponseModel>();

    /*x.AddConsumer<CategoryModifyConsumer>();
    x.AddConsumer<CategoriesResponseConsumer>();
    x.AddConsumer<CategoryResponseConsumer>();*/

    x.AddConsumer<CategoryModifyConsumer, CategoryModifyConsumerDefinition>();
    x.AddConsumer<CategoriesResponseConsumer, CategoriesResponseConsumerDefinition>();
    x.AddConsumer<CategoryResponseConsumer, CategoryResponseConsumerDefinition>();
});
builder.Services.AddScoped<IGoodManager>(prov => new GoodManager(builder.Configuration.GetConnectionString("DB")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();