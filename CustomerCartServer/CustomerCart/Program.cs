using CustomerCartModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;



//Requierd variables
var builder = WebApplication.CreateBuilder(args);

var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql");


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<CustomerOrdersDatabaseContext>();
builder.Services.AddDbContext<CustomerOrdersDatabaseContext>(optionsBuilder =>
optionsBuilder.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
serverVersion));

//Authorization Builders
builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration, "AzureAdB2C");
builder.Services.AddAuthorization();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options => options.AddDefaultPolicy(builder => { builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); }));
}

builder.Services.AddAuthorization();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigins",
            builder => builder.WithOrigins("https://customercart.azurewebsites.net")
                             .AllowAnyHeader()
                             .AllowAnyMethod());
    });
}


//Building the App
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}


app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () => "Hello World!");
app.UseCors();
app.MapControllers().RequireAuthorization();

app.Run();

