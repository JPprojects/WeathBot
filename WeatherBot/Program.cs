using WeatherBot.Interfaces;
using WeatherBot.ModelBuilders;
using WeatherBot.Services;
using WeatherBot.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//for .net6 you can register the interface and the type here
builder.Services.AddScoped<IHomeViewModelBuilder, HomeViewModelBuilder>();
builder.Services.AddScoped<IWeatherAPIService, WeatherApiService>();

//using the IHtttpFactory, this also uses the httpclienthandler
//Named client
builder.Services.AddHttpClient("weatherApi", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
});

//using the IHtttpFactory, this also uses the httpclienthandler
//Type Client define httpclient to be resolve bya sepcific type
builder.Services.AddHttpClient<ApiHelper>(client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
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
