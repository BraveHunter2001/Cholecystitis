using Prometheus;

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

app.UseRouting();
// Capture metrics about all received HTTP requests.
app.UseHttpMetrics(options =>
{
    // This will preserve only the first digit of the status code.
    // For example: 200, 201, 203 -> 2xx
    options.ReduceStatusCodeCardinality();
});


// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
