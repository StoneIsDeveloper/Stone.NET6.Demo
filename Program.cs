var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//lamda middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello middleware 1;  ");
    await next(context);
});

//middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello middleware 2;  ");
    await next(context);
});

//middleware 3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Hello middleware 3;  ");
});

//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello 2");
//});

//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello 1");
//});

app.Run();
