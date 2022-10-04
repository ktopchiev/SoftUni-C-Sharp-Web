using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data;
using WebShopDemo.Core.Services;

//*nai vajnata 4ast ot app-a e buildera
var builder = WebApplication.CreateBuilder(args);

//*Dve mnogo vajni property-ta na buildera sa configuration-a i services
//*ConnectionString-a idva ot appsettings.json
//*Propertito services e za dependency injection
//*Tozi builder ni pozvolqva da si configurirame apa,
//*da napalnim inversion of control container ???? Pipeline ???
//*var app e nasheto prilojenie koeto veche se bildva
//*Nasheto prilojenie ot request ddo response minava prez middlewware-i v koito se naslagvat nastroiki


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(
    options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

//*kogato dobavqme survisi v containera trqbwa da kajem kakav e jivota na teq servisi
//*transient e obratnoto na singleton
//*scoped e nai 4esto izpolzvaniq lifetime, zashtoto skoup ozna4ava 4e vaprosnoto neshto
//*e vidimo, v ramkite na edin rikuest polu4avame edna isashta instanciq, po tozi nachin si ostava
//*steitles za tozi rekuest si imame servisa
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();


//*Ot tuk natatak e mnogo vajno kak se podrejdat neshtata zashtoto taka se narejdat v pipeline
//*a se pro4ete otnovo kakvo e pipeline i za kakvo sluji

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

//Tezi trqbva da sa podredeni v to4no opredelen red log4eski
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//otorizaciqta e sled autentikaciqta
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
