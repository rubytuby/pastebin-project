var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Set SQlite connection string

bool useAbsolutePath = builder.Configuration.GetValue<bool>("Sqlite:UseAbsolutePath", false);
string sqliteConnectionString;

if (useAbsolutePath)
{
	string dbPath = builder.Configuration.GetValue<string>("Sqlite:DbPath");
	sqliteConnectionString = $"Data Source={dbPath}";
}
else
{
	// get directory to project before building
	string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin" }, StringSplitOptions.None)[0];
	string dbPath = builder.Configuration.GetValue<string>("Sqlite:DbPath");
	dbPath = System.IO.Path.Combine(projectPath, dbPath);
	sqliteConnectionString = $"Data Source={dbPath}";
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlite(sqliteConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();
