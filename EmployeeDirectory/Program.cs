using DLL;
using Microsoft.EntityFrameworkCore;
using BLL;
using EmployeeDirectory.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
builder.Services.AddDbContext<EmployeeDB>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCS"),
            options => options.EnableRetryOnFailure()));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else {
    app.UseExceptionHandler("/error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseRouting();


app.UseExceptionHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
