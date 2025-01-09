using DigitalCursos.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddScoped<HttpClient>(s => {
//    return new HttpClient { BaseAddress = new Uri(@"https://localhost:7075") };
//});

builder.Services.AddHttpClient<IAlunoService, AlunoService>(client => {
    client.BaseAddress = new Uri("https://localhost:7075");
    client.DefaultRequestHeaders.Add("Accept", "application/+json");
});

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
