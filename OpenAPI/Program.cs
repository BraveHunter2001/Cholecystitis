using DAL;
using DAL.DI;
using Prometheus;
using Services.DI;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCholecystitisContext();
builder.Services.AddCholicystitsServices();

builder.Services.AddControllers().AddJsonOptions(opt => { opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CholecystitisContext>();
   // db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}


app.UseRouting();

// Capture metrics about all received HTTP requests.
app.UseHttpMetrics(options =>
{
    // This will preserve only the first digit of the status code.
    // For example: 200, 201, 203 -> 2xx
    options.ReduceStatusCodeCardinality();
});


app.UseCors(MyAllowSpecificOrigins);
//app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapMetrics());

app.MapControllers();



app.Run();