var builder = WebApplication.CreateBuilder(args);
builder.AddKeyedRedisClient("redis");
builder.Host.UseOrleans(c =>
{
    c.UseDashboard(d =>
    {
        d.HostSelf = true;
    });
});

var app = builder.Build();

app.Map("/dashboard", o => o.UseOrleansDashboard());
app.Run();
