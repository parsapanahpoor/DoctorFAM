using DoctorFAM.Application.SiteServices;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.SharedResource;
using DoctorFAM.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

#region Service

#region Localizer

builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

builder.Services.Configure<RequestLocalizationOptions>(
    opts =>
    {
        CultureInfo faIR = CultureInfo.CreateSpecificCulture("fa-IR");
        faIR.DateTimeFormat.Calendar = new GregorianCalendar();
        faIR.NumberFormat.CurrencyDecimalSeparator = ".";
        faIR.NumberFormat.NumberDecimalSeparator = ".";
        faIR.NumberFormat.PercentDecimalSeparator = ".";
        faIR.NumberFormat.NumberGroupSeparator = ",";
        faIR.NumberFormat.CurrencyGroupSeparator = ",";
        faIR.NumberFormat.NegativeSign = "-";

        CultureInfo trTR = CultureInfo.CreateSpecificCulture("tr-TR");
        faIR.DateTimeFormat.Calendar = new GregorianCalendar();
        faIR.NumberFormat.CurrencyDecimalSeparator = ".";
        faIR.NumberFormat.NumberDecimalSeparator = ".";
        faIR.NumberFormat.PercentDecimalSeparator = ".";
        faIR.NumberFormat.NumberGroupSeparator = ",";
        faIR.NumberFormat.CurrencyGroupSeparator = ",";
        faIR.NumberFormat.NegativeSign = "-";

        CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");
        faIR.DateTimeFormat.Calendar = new GregorianCalendar();
        faIR.NumberFormat.CurrencyDecimalSeparator = ".";
        faIR.NumberFormat.NumberDecimalSeparator = ".";
        faIR.NumberFormat.PercentDecimalSeparator = ".";
        faIR.NumberFormat.NumberGroupSeparator = ",";
        faIR.NumberFormat.CurrencyGroupSeparator = ",";
        faIR.NumberFormat.NegativeSign = "-";

        var supportedCultures = new List<CultureInfo>
        {
             new CultureInfo("en-US"),
             new CultureInfo("en"),
             faIR,
             trTR,
             arSA
        };

        opts.DefaultRequestCulture = new RequestCulture("en-US");
        opts.SupportedCultures = supportedCultures;
        opts.SupportedUICultures = supportedCultures;
    });

#endregion

#region mvc

builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, option => { option.ResourcesPath = "Resources"; })
    .AddDataAnnotationsLocalization(o =>
    {
        o.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            return factory.Create(typeof(DataAnnotationResource));
        };
    });

builder.Services.AddMvc();

#endregion

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

#region Add DBContext

builder.Services.AddDbContext<DoctorFAMDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DoctorFAMConnectionString"));
});

#endregion

#region Data Protection

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory() + "\\wwwroot\\Auth\\"))
    .SetApplicationName("DoctorFAM")
    .SetDefaultKeyLifetime(TimeSpan.FromDays(30));

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
// Add Cookie settings
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
    });

#endregion

#region Encoder

builder.Services.AddSingleton<HtmlEncoder>(
    HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

#endregion

#region Register Services

DependencyContainer.RegisterServices(builder.Services);

#endregion

#region Localizer

builder.Services.AddLocalization(
    opts =>
    {
        opts.ResourcesPath = "Resources";
    }
);

builder.Services.Configure<RequestLocalizationOptions>(
    opts =>
    {


        CultureInfo faIR = CultureInfo.CreateSpecificCulture("fa-IR");
        faIR.DateTimeFormat.Calendar = new GregorianCalendar();
        faIR.NumberFormat.CurrencyDecimalSeparator = ".";
        faIR.NumberFormat.NumberDecimalSeparator = ".";
        faIR.NumberFormat.PercentDecimalSeparator = ".";
        faIR.NumberFormat.NumberGroupSeparator = ",";
        faIR.NumberFormat.CurrencyGroupSeparator = ",";
        faIR.NumberFormat.NegativeSign = "-";

        var supportedCultures = new List<CultureInfo>
        {
             new CultureInfo("en-US"),
             new CultureInfo("en"),
             faIR,
        };

        opts.DefaultRequestCulture = new RequestCulture("en-US");
        opts.SupportedCultures = supportedCultures;
        opts.SupportedUICultures = supportedCultures;
    });

#endregion

#endregion

#region MiddleWares

var app = builder.Build();

app.UseDeveloperExceptionPage();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

#region Localizer

CultureInfo faIR = CultureInfo.CreateSpecificCulture("fa-IR");
faIR.DateTimeFormat.Calendar = new GregorianCalendar();
faIR.NumberFormat.CurrencyDecimalSeparator = ".";
faIR.NumberFormat.NumberDecimalSeparator = ".";
faIR.NumberFormat.NumberGroupSeparator = ",";
faIR.NumberFormat.CurrencyGroupSeparator = ",";
faIR.NumberFormat.PercentDecimalSeparator = ".";
faIR.NumberFormat.NegativeSign = "-";

CultureInfo trTR = CultureInfo.CreateSpecificCulture("tr-TR");
faIR.DateTimeFormat.Calendar = new GregorianCalendar();
faIR.NumberFormat.CurrencyDecimalSeparator = ".";
faIR.NumberFormat.NumberDecimalSeparator = ".";
faIR.NumberFormat.PercentDecimalSeparator = ".";
faIR.NumberFormat.NumberGroupSeparator = ",";
faIR.NumberFormat.CurrencyGroupSeparator = ",";
faIR.NumberFormat.NegativeSign = "-";

CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");
faIR.DateTimeFormat.Calendar = new GregorianCalendar();
faIR.NumberFormat.CurrencyDecimalSeparator = ".";
faIR.NumberFormat.NumberDecimalSeparator = ".";
faIR.NumberFormat.PercentDecimalSeparator = ".";
faIR.NumberFormat.NumberGroupSeparator = ",";
faIR.NumberFormat.CurrencyGroupSeparator = ",";
faIR.NumberFormat.NegativeSign = "-";


var supportedCultures = new List<CultureInfo>() { faIR, trTR , arSA , new CultureInfo("en-US") };

var options = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
};

app.UseRequestLocalization(options);

#endregion


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

SiteCurrentContext.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());


app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#endregion

