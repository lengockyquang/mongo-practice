using MongoPractices.Models;
using MongoPractices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()    
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Recommended to store a MongoClient instance in a global place
builder.Services.AddSingleton<IBaseMongoClient, BaseMongoClient>(); 
builder.Services.AddScoped<BooksService>();
builder.Services.Configure<BookStoreDatabaseSettings>(
builder.Configuration.GetSection("BookStoreDatabase"));
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