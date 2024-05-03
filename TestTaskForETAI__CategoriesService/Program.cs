using CategoriesService__BLL.Interfaces;
using CategoriesService__BLL.Managers;
using CategoriesService__WebApi.MassTransit.ModifyConsumers;
using CategoriesService__WebApi.MassTransit.ResponseComsumers;
using MassTransit;
using SharedModels.MessageModels;
using SharedModels.ResponseModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq();

    x.AddRequestClient<CategoryListMessage>();
    x.AddRequestClient<CategoryResponseModel>();

    /*x.AddConsumer<GoodModifyConsumer>();
    x.AddConsumer<GoodResponseConsumer>();
    x.AddConsumer<GoodsResponseConsumer>();*/

    x.AddConsumer<GoodModifyConsumer, GoodModifyConsumerDefinition>();
    x.AddConsumer<GoodResponseConsumer, GoodResponseConsumerDefinition>();
    x.AddConsumer<GoodsResponseConsumer, GoodsResponseConsumerDefinition>();

});
builder.Services.AddScoped<ICategoryManager>(prov => new CategoryManager(builder.Configuration.GetConnectionString("DB")));


builder.Services.AddControllers();
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