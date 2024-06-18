using Dclt.Directus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<DirectusService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/rpas", async (DirectusService directus) =>
{
    if (directus != null && directus._client != null)
    {
        var item = await directus._client.GetItemAsync<dynamic>("rpas", 1);
        return Results.Ok(item);
    }
    return Results.NotFound();
});

app.Run();

