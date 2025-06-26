using Microsoft.EntityFrameworkCore;
using SensitiveWords.API.Data;
using SensitiveWords.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Seed(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/sensitivewords", async (AppDbContext db) =>
{
    return await db.SensitiveWords.ToListAsync();
})
.WithName("GetAllSensitiveWords")
.WithOpenApi(op =>
{
    op.Summary = "Get all sensitive words";
    op.Description = "Returns a list of all sensitive words stored in the database.";
    return op;
});

app.MapGet("/sensitivewords/{id}", async (int id, AppDbContext db) =>
{
    var word = await db.SensitiveWords.FindAsync(id);
    return word is not null ? Results.Ok(word) : Results.NotFound();
})
.WithName("GetSensitiveWordById")
.WithOpenApi(op =>
{
    op.Summary = "Get a specific sensitive word by ID";
    op.Description = "Retrieves a single sensitive word using its unique ID.";
    return op;
});

app.MapPost("/sensitivewords", async (SensitiveWord word, AppDbContext db) =>
{
    db.SensitiveWords.Add(word);
    await db.SaveChangesAsync();
    return Results.Created($"/sensitivewords/{word.Id}", word);
})
.WithName("AddSensitiveWord")
.WithOpenApi(op =>
{
    op.Summary = "Add a new sensitive word";
    op.Description = "Adds a new sensitive word to the database.";
    return op;
});

app.MapPut("/sensitivewords/{id}", async (int id, SensitiveWord input, AppDbContext db) =>
{
    var word = await db.SensitiveWords.FindAsync(id);
    if (word is null) return Results.NotFound();

    word.Word = input.Word;
    await db.SaveChangesAsync();
    return Results.Ok(word);
})
.WithName("UpdateSensitiveWord")
.WithOpenApi(op =>
{
    op.Summary = "Update a sensitive word";
    op.Description = "Updates the word value of an existing sensitive word entry.";
    return op;
});

app.MapDelete("/sensitivewords/{id}", async (int id, AppDbContext db) =>
{
    var word = await db.SensitiveWords.FindAsync(id);
    if (word is null) return Results.NotFound();

    db.SensitiveWords.Remove(word);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteSensitiveWord")
.WithOpenApi(op =>
{
    op.Summary = "Delete a sensitive word";
    op.Description = "Deletes a sensitive word from the database using its ID.";
    return op;
});


app.MapPost("/sanitize", async (SanitizeRequest request, AppDbContext db) =>
{
    var sensitiveWords = await db.SensitiveWords.Select(w => w.Word).ToListAsync();
    var sanitized = request.Message;

    foreach (var word in sensitiveWords)
    {
        sanitized = sanitized.Replace(word, new string('*', word.Length), StringComparison.OrdinalIgnoreCase);
    }

    return Results.Ok(new { sanitized });
})
.WithName("SanitizeMessage")
.WithOpenApi(op =>
{
    op.Summary = "Sanitizes a user message";
    op.Description = "Replaces all stored sensitive words in the message with asterisks.";
    return op;
});


app.Run();