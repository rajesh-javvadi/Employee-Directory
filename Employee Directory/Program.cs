using Employee_Directory.Repository;
using Employee_Directory.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeServices>();
builder.Services.AddScoped<OfficeServices>();
builder.Services.AddScoped<OfficeRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<DepartmentServices>();
builder.Services.AddScoped<DBServices>();

var app = builder.Build();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
