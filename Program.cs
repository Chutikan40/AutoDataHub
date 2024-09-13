using AutoDataHub.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure EF Core to use SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//---เพิ่มการตั้งค่าสำหรับ Swagger---------------------------------------------------//
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Title",
        Description = "Description",
    });
});

//------------------------------------------------------//

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// เปิดใช้งาน Swagger สำหรับทุกโหมด
app.UseSwagger();

// เปิดใช้งาน Swagger UI สำหรับทุกโหมด
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    // c.RoutePrefix ไม่ถูกตั้งค่า หมายความว่า Swagger UI จะอยู่ที่ /swagger
    // หากคุณต้องการใช้เส้นทางที่แตกต่างออกไป เช่น /api-docs คุณสามารถตั้งค่า c.RoutePrefix = "api-docs";
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers(); // Maps all controllers including AuthController

app.Run();
