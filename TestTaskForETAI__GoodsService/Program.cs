using GoodsService__BLL.Interface;
using GoodsService__BLL.Managers;
using GoodsService__WebApi.MassTransit.ModifyConsumers.Consumers;
using GoodsService__WebApi.MassTransit.ResponseConsumers.Consumers;
using MassTransit;
using SharedModels.Constants;
using SharedModels.Models.RespondModels.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg)=>
    {
        cfg.Host("localhost", "/", h =>
        {
            var rabbit = builder.Configuration.GetSection("RabitMQ");
            h.Username(rabbit.GetValue<string>("UserName"));
            h.Password(rabbit.GetValue<string>("Password"));
        });
        cfg.ConfigureEndpoints(context);
});

    x.AddConsumer<CategoryModifyConsumer>().Endpoint(e=>e.Name = QueueConstants.NotificationQueueFromCategoriesToGoods);
    x.AddConsumer<GetCountOfGoodsConsumer>().Endpoint(e => e.Name = QueueConstants.ResponseQueueFromGood);
    x.AddConsumer<GetCountsOfGoodsConsumer>().Endpoint(e => e.Name = QueueConstants.ResponseListsQueueFromGood); ;
    /*
    x.AddRequestClient<GetCategoryNameResponse>(new Uri($"queue:{QueueConstants.ResponseQueueBetweenServices}?durable=false"));
    x.AddRequestClient<ListGetCategoryNameResponse>(new Uri($"queue:{QueueConstants.ResponseListsQueueBetweenServices}?durable=false"));
    */
    
    x.AddRequestClient<GetCategoryNameRequest>(new Uri("exchange:" + QueueConstants.ResponseQueueFromCategory));
    x.AddRequestClient<ListGetCategoryNameRequest>(new Uri("exchange:" + QueueConstants.ResponseListsQueueFromCategory));
    

});
builder.Services.AddScoped<IGoodManager>(prov => new GoodManager(builder.Configuration.GetConnectionString("DB")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin());
});

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
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();