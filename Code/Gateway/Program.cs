using Gateway.Extensions;
using Steeltoe.Discovery.Client;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDiscoveryClient();

builder.Services.AddReverseProxy().LoadFromMemory();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}


app.UseRouting();


app.UseEndpoints(endpoints =>
{
	endpoints.MapReverseProxy();

});


app.Run();
