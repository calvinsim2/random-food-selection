using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RandomFoodSelection.Context;
using RandomFoodSelection.Dto;
using RandomFoodSelection.Interfaces.Repositories;
using RandomFoodSelection.Interfaces.Services;
using RandomFoodSelection.Repository;
using RandomFoodSelection.Services;
using RandomFoodSelection.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IValidator<FoodDto>, FoodDtoValidator>();

// we will do this step AFTER we created our DbContext
// Context is the db context that we created.
builder.Services.AddDbContext<FoodContext>(option =>
{

    // Need to import UseSqlServer
    // Configuration is already provided by Startup, so we use this to input our sql connection string
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        // builder.WithOrigins(<insert ur frontend url here>, it accepts a string of array.)
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

// when implementing CORS, we need this, and make sure this is ABOVE UseRouting();
app.UseCors("MyPolicy");

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();
