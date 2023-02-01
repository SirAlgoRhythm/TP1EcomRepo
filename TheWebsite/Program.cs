var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

app.UseMvc(routes => routes.MapRoute("Default", "{controller=Home}/{action=Index}"));

app.Run();
