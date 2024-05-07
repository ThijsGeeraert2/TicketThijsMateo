using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TicketThijsMateo.Data;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Repositories;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//This example register a DbContext subclass called BeerDbContext as a scoped service in
//the ASP.NET Core application service provider (a.k.a. the dependency injection container).
builder.Services.AddDbContext<TicketDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder) // vertaling op View
    .AddDataAnnotationsLocalization(); // vertaling op ViewModel

// we need to decide which cultures we support, and which is the default culture.
var supportedCultures = new[] { "nl", "en", "fr" };

builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.SetDefaultCulture(supportedCultures[0])
      .AddSupportedCultures(supportedCultures)  //Culture is used when formatting or parsing culture dependent data like dates, numbers, currencies, etc
      .AddSupportedUICultures(supportedCultures);  //UICulture is used when localizing strings, for example when using resource files.
});



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


// syntax services.AddTransient<interface, implType>();
builder.Services.AddTransient<IService<Club>, ClubIService>();
builder.Services.AddTransient<IDAO<Club>, ClubIDAO>();

builder.Services.AddTransient<StadiumIDAO<Stadium>, StadiumDAO>();
builder.Services.AddTransient<StadiumIService<Stadium>, StadiumService>();

// SwaggerGen produces JSON schema documents that power Swagger UI.By default, these are served up under / swagger
//{ documentName}/ swagger.json, where { documentName} is usually the API version.
//provides the functionality to generate JSON Swagger documents that describe the objects, methods, return types, etc.
//eerste paramter, is de naam van het swagger document
//
// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API Football",
        Version = "version 1",
        Description = "An API to perform football ticket operations",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "CDW",
            Email = "mateo.gheeeraert@student.vives.be",
            Url = new Uri("https://vives.be"),
        },
        License = new OpenApiLicense
        {
            Name = "Football API LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
});

// Add Automapper
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddDbContext<TicketDBContext>(options =>
{
    options.UseSqlServer(connectionString); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

var swaggerOptions = new TicketThijsMateo.Options.SwaggerOptions();
builder.Configuration.GetSection(nameof(TicketThijsMateo.Options.SwaggerOptions)).Bind(swaggerOptions);
// Enable middleware to serve generated Swagger as a JSON endpoint.
//RouteTemplate legt het path vast waar de JSON‐file wordt aangemaakt
app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
//// By default, your Swagger UI loads up under / swagger /.If you want to change this, it's thankfully very straight‐forward.Simply set the RoutePrefix option in your call to app.UseSwaggerUI in Program.cs:
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
});
app.UseSwagger();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
