using booking_calendar.Components;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

<<<<<<< Updated upstream
=======
/***********************************************************************************
 * AddControllers is a method that adds services for controllers to the service collection.
 * This is necessary for our API controllers to work, as it allows us to use features such
 * as model binding, validation, and routing. By calling this method, we are telling the
 * application that we want to use controllers to handle HTTP requests and return responses
 * in our application.
***********************************************************************************/
builder.Services.AddControllers(); // add controllers to the service collection
builder.Services.AddHttpClient(); // add HttpClient to the service collection, which allows us to make HTTP requests to our API controllers from our Razor components


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().BaseUri)
});

/***********************************************************************************
 * AddDbContext is a method that adds a DbContext to the service collection. In this case,
 * we are adding the meetingContext, which is our custom DbContext for managing events in
 * our application. We are configuring it to use an in-memory database called "CalendarTestDb",
 * which allows us to store and retrieve event data without needing a physical database server.
    * This is useful for testing and development purposes, as it provides a simple way to manage
    * data without the overhead of setting up a full database.
***********************************************************************************/
builder.Services.AddDbContext<meetingContext>(options =>
    options.UseInMemoryDatabase("CalendarTestDb"));

builder.Services.AddDbContext<meetingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

>>>>>>> Stashed changes
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
<<<<<<< Updated upstream
else
{
    app.UseDeveloperExceptionPage();
}
=======


>>>>>>> Stashed changes
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is AntiforgeryValidationException)
        {
            context.Response.Redirect("/antiforgery-error");
            return;
        }

        context.Response.Redirect("/error");
    });
});

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


