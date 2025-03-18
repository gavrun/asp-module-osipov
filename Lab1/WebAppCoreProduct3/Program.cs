//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();


// object manages application config
var builder = WebApplication.CreateBuilder(args);

// add Razor Pages services to the container
builder.Services.AddRazorPages();

// object for processing HTTP requests
var app = builder.Build();

// Configure the HTTP request pipeline (Middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Razor Pages end points for IEndpointRouteBuilder
app.MapRazorPages();

// starts application
app.Run();
