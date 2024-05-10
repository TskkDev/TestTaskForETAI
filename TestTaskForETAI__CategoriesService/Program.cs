using CategoriesService__BLL.Interfaces;
using CategoriesService__BLL.Managers;
using CategoriesService__WebApi.MassTransit.ModifyConsumers.Consumers;
using CategoriesService__WebApi.MassTransit.ResponseComsumers.Consumers;
using MassTransit;
using SharedModels.Constants;
using SharedModels.Models.RespondModels.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            var rabbit = builder.Configuration.GetSection("RabitMQ");
            h.Username(rabbit.GetValue<string>("UserName"));
            h.Password(rabbit.GetValue<string>("Password"));
        });
        cfg.ConfigureEndpoints(context);
    });


    x.AddConsumer<GoodModifyConsumer>().Endpoint(e => e.Name = QueueConstants.NotificationQueueFromGoodsToCategories); ;
    x.AddConsumer<GetCategoriesNameConsumer>().Endpoint(e => e.Name = QueueConstants.ResponseListsQueueFromCategory); ;
    x.AddConsumer<GetCategoryNameConsumer>().Endpoint(e => e.Name = QueueConstants.ResponseQueueFromCategory); ;
    /*
    x.AddRequestClient<GetCountGoodsResponse>(new Uri($"queue:{QueueConstants.ResponseQueueBetweenServices}?durable=false"));
    x.AddRequestClient<ListGetCountGoodsResponse>(new Uri($"queue:{QueueConstants.ResponseListsQueueBetweenServices}?durable=false"));
    */
    
    x.AddRequestClient<GetCountGoodsRequest>(new Uri("exchange:"+QueueConstants.ResponseQueueFromGood));
    x.AddRequestClient<ListGetCountGoodsRequest>(new Uri("exchange:" + QueueConstants.ResponseListsQueueFromGood));
    

});
builder.Services.AddScoped<ICategoryManager>(prov => new CategoryManager(builder.Configuration.GetConnectionString("DB")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin());
});
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
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();