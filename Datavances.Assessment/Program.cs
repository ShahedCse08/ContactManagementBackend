using Microsoft.EntityFrameworkCore;
using Persistence;
using Services;
using Services.Abstractions;
using Domain.Repository;
using Persistence.Repositories;
using Datavanced.Assessment.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Contact Management Assessment at Datavanced", Version = "v1" });
});

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddDbContextPool<RepositoryDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<ExceptionHandlingMiddleware>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Management API V1"));
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors("AllowAll");   // This is how we deal with public and private API

app.MapControllers();

app.Run();
