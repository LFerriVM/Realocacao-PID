using Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Usuario/Login";
        options.LoginPath = "/Usuario/Login";
        options.LogoutPath = "/Usuario/Logout";
    });
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source=data.db"); // nome do arquivo onde se encontra o banco de dados
});
builder.WebHost.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseUrls("https://*:7272", "https://localhost:7272").UseIISIntegration();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();

app.Run();

// private void GetIpValue(out string ipAdd)  
// {  
//     ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];  
  
//     if (string.IsNullOrEmpty(ipAdd))  
//     {  
//         ipAdd = Request.ServerVariables["REMOTE_ADDR"];  
//     }  
//     else  
//     {  
//         lblIPAddress.Text = ipAdd;  
//     }  
// }  