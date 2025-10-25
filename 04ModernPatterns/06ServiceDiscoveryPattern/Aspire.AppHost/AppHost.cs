using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<ProductWebAPI>("product");
builder.AddProject<BasketWebAPI>("basket");

builder.Build().Run();
