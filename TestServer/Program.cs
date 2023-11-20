
using MediatR;
using TestServer.Application.Common.Commands.CreateCustomer;
using TestServer.Application.Common.Interfaces;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddMyApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();

app.MapGet("/customers", (ICustomerService db) =>
//ToDo
//Implement Query
     db.GetCustomers());

app.MapPost("/Customers", async (List<CreateCustomerCommand> customers, ISender sender) =>
{
    customers.ForEach(async c =>
    {
        await sender.Send(c);
    });

});


app.Run();
