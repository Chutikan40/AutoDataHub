using AutoDataHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// Configure EF Core to use SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
//---������õ�駤������Ѻ Swagger---------------------------------------------------//
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

// �Դ��ҹ Swagger ����Ѻ�ء����
app.UseSwagger();

// �Դ��ҹ Swagger UI ����Ѻ�ء����
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    // c.RoutePrefix ���١��駤�� ���¤������ Swagger UI �������� /swagger
    // �ҡ�س��ͧ�������鹷ҧ���ᵡ��ҧ�͡� �� /api-docs �س����ö��駤�� c.RoutePrefix = "api-docs";
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

app.MapRazorPages();

app.Run();
