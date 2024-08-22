using TeachingSite.Frontend.Clients;
using TeachingSite.Frontend.Components;
using TeachingSite.Frontend.Components.Pages;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBlazorBootstrap();
// Add services to the container.
builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();
var teachingSiteApiUrl = builder.Configuration["TeachingSiteApiUrl"] ??
	throw new Exception("TeachingSiteApiUrl is not set!");

builder.Services.AddHttpClient<QuestionsClient>(
	client => client.BaseAddress = new Uri(teachingSiteApiUrl));
	
builder.Services.AddHttpClient<ExamsClient>(
	client => client.BaseAddress = new Uri(teachingSiteApiUrl));
	
builder.Services.AddHttpClient<SubjectsClient>(
	client => client.BaseAddress = new Uri(teachingSiteApiUrl));
		
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
