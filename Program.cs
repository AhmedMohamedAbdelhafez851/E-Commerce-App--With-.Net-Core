using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Labs.Bl;
using Labs.Models;
using System.Security.Policy;
//using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddControllersWithViews();

#region Entity Framework
builder.Services.AddDbContext<LapShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<LapShopContext>(); 
#endregion
#region Custom Services
builder.Services.AddScoped<ICategories, ClsCategories>();
builder.Services.AddScoped<IItems, ClsItems>();
builder.Services.AddScoped<IItemTypes, ClsItemTypes>();
builder.Services.AddScoped<IOs, ClsOs>();
builder.Services.AddScoped<IItemImages, ClsItemImages>();
builder.Services.AddScoped<ISliders, ClsSliders>();

//builder.Services.AddScoped<ISalesInvoice, ClsSalesInvoice>();
//builder.Services.AddScoped<ISalesInvoiceItems, ClsSalesInvoiceItems>();
//builder.Services.AddScoped<VmHomePage>(); 
#endregion

#region Swagger
//builder.Services.AddSwaggerGen(options =>
//{
//    // How To Generate Documentation . 
//options.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo()
//{
//Version = "v1",
//Title = "Lap Shope Api ",
//Description = "Api To Access items and related categories",
//TermsOfService = new Uri("https://arabic.alibaba.com/f/alibaba-%25D8%25B9%25D8%25B1%25D8%25A8%25D9%258A.html"),
//Contact = new OpenApiContact()
//{
//    Email = "ahmedmhafez851@gmail.com",
//    Name = "Ahmed",
//    Url = new Uri("https://arabic.alibaba.com/f/alibaba-%25D8%25B9%25D8%25B1%25D8%25A8%25D9%258A.html")
//},
//License = new OpenApiLicense()
//{
//    Name = "Ali BaBa License",
//    Url = new Uri("https://arabic.alibaba.com/f/alibaba-%25D8%25B9%25D8%25B1%25D8%25A8%25D9%258A.html")
//}

//});
//var xmlComments = $" {Assembly.GetExecutingAssembly().GetName().Name}.xml";
//var fullPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
//Options.IncludeXmlComments(fullPath); 
//});

#endregion

#region Coockies and Sessions
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.ConfigureApplicationCookie(options =>
{
options.AccessDeniedPath = "/Users/AccessDenied";
options.Cookie.Name = "Cookie";
options.Cookie.HttpOnly = true;
options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
options.LoginPath = "/Users/Login";
options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
options.SlidingExpiration = true;
}); 
#endregion
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
#region Swagger Hashed
//app.UseSwagger();
//app.UseSwaggerUI(options=>
//{                      // Swagger generate jason file display on page html 
//                       // path of swagger document     
//    options.SwaggerEndpoint("/swagger/V1/swagger.json", "V1");
//    options.RoutePrefix = String.Empty;  
//}
//    );    

#endregion

#region Routing
app.UseEndpoints(endpoints =>
{
endpoints.MapControllerRoute(
name: "admin",
pattern: "{area:exists}/{controller=Home}/{action=Index}");

endpoints.MapControllerRoute(
name: "LandingPages",
pattern: "{area:exists}/{controller=Home}/{action=Index}");

endpoints.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index1}/{id?}");

endpoints.MapControllerRoute(
name: "ali",
pattern: "ali/{controller=Home}/{action=Index}/{id?}");
}
); 
#endregion


app.Run();
