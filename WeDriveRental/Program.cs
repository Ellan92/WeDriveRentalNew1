using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeDriveRental.Client.Pages;
using WeDriveRental.Components;
using WeDriveRental.Components.Account;
using WeDriveRental.Data;
using WeDriveRental.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
	{
		options.DefaultScheme = IdentityConstants.ApplicationScheme;
		options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
	})
	.AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddSignInManager()
	.AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddScoped<WeDriveRentalRepository>();

// Skapa users och roller som ska finnas med från start

using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
{
	var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
	var signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

	context.Database.Migrate();

	ApplicationUser newUser = new()
	{
		UserName = "adminuser@mail.com",
		Email = "adminuser@mail.com",
		EmailConfirmed = true
	};

	var user = signInManager.UserManager.FindByEmailAsync(newUser.Email).GetAwaiter().GetResult();

	if (user == null)
	{
		// SKapa en ny user
		signInManager.UserManager.CreateAsync(newUser, "Password1234!").GetAwaiter().GetResult();



		// Kolla om adminrollen existerar
		bool adminRoleExists = roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult();
		if (!adminRoleExists)
		{
			IdentityRole adminRole = new()
			{
				Name = "admin",
			};

			roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
		}

		// Tilldela adminrollen till den nya användaren
		signInManager.UserManager.AddToRoleAsync(newUser, "Admin").GetAwaiter().GetResult();
	}
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(Counter).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
