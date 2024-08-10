using Gallery_Backend.Configurations;
using Gallery_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure MongoDB settings from environment variables
builder.Services.Configure<MongoDBSettings>(options =>
{
    options.ConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
    options.DatabaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME");
});

builder.Services.AddSingleton<MongoDBContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow requests from your React app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use the correct CORS policy name
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
