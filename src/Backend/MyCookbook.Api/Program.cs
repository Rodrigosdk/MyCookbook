using MyCookbook.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

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

updateDatabase();

app.Run();

void updateDatabase()
{
    var nameDatabase = builder.Configuration.GetConnectionString("NameDatabase");
    var connectionDatabase = builder.Configuration.GetConnectionString("Connection");
    DataContext.createDatabase(nameDatabase:nameDatabase, databaseConnection:connectionDatabase);
    app.MigrateDataBase();
}
