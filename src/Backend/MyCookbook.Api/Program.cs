using Microsoft.EntityFrameworkCore;
using MyCookbook.Api.Filters;
using MyCookbook.Aplication.Services.AutoMapper;
using MyCookbook.Infrastructure;
using MyCookbook.Infrastructure.Database;
using MyCookbook.Aplication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepository(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilters)));
builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperConfiguration())).CreateMapper());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

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
