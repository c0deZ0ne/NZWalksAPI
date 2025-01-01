using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Mappings;
using NZWalksAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//database connection dependency Injection
builder.Services.AddDbContext<NZWalksDbContext>((options) => options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksDbConnectionSting")));

// start injecting repository pattern 
builder.Services.AddScoped<IRegionRepository ,SQLRegionRepository>(); // inject the interface of the IRegionRepository interface with into the implementation of the interface
//end injecting repository pattern

//Adding Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
