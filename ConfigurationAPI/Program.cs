var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Configuration.AddJsonFile("MicroConfigs-development.json",
    optional: true,
    reloadOnChange: true);
builder.Configuration.AddJsonFile("MicroConfigs-production.json",
    optional: true,
    reloadOnChange: true);
builder.Configuration.AddJsonFile("MicroConfigs-staging.json",
    optional: true,
    reloadOnChange: true);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
