var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// The Angular build is copied into wwwroot at deploy time, so one site serves both the page and the API.
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/allocations", () => StripeData.GetAll());
app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));

app.Run();

public record StripeItem(Guid Id, int Number, string Name, string Detail, string Status);

public static class StripeData
{
    public static IReadOnlyList<StripeItem> GetAll() =>
    [
        new(Guid.Parse("11111111-1111-1111-1111-111111111111"), 2001, "A Patel", "1 High Street, Leeds", "Offered"),
        new(Guid.Parse("22222222-2222-2222-2222-222222222222"), 2002, "B Jones", "3 Park Road, Hull", "Accepted"),
        new(Guid.Parse("33333333-3333-3333-3333-333333333333"), 2003, "C Smith", "5 Station Road, York", "Refused"),
    ];
}
