var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CatalogApi")!);
    if (builder.Environment.IsDevelopment())
        options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
});

var app = builder.Build();

app.MapCarter();

app.Run();
