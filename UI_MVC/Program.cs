var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura y agrega un cliente HTTP con nombre "CRMAPI"  * AGREGADA *
builder.Services.AddHttpClient("API_RESTful", c =>
{
    // Configura la dirección base del cliente HTTP desde la configuración
    c.BaseAddress = new Uri(builder.Configuration["UrlsAPI:Puerto"]);
    // Puedes configurar otras opciones del HttpClient aquí según sea necesario
});

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
