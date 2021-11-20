using ASCOPC.Infrastructure.Data;
using ASCOPC.Infrastructure.Extensions;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

//Fixed connection .gltf extensions
var options = new StaticFileOptions
{
    ContentTypeProvider = new FileExtensionContentTypeProvider()
};
((FileExtensionContentTypeProvider)options.ContentTypeProvider).Mappings.Add(
    new KeyValuePair<string, string>(".gltf", "text/plain"));

// connection custom DI extension
builder.Services.AddInfrastructure(builder.Configuration);

// auth
builder.Services.AddMvcCore()
    .AddAuthorization();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// initialize roles
using var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
var logger = provider.GetRequiredService<ILogger<Program>>();

try
{
    await DbInitializer.IdentityInitializeAsync(provider);

    logger.LogInformation("Finished Seeding Default Data");
    logger.LogInformation("Application Starting");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred while migrating or seeding the database");
    throw;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles(options);

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// endpoints
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
