using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Quizzler.Data;

var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// // builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new QuestionConverter());
        opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // optional but recommended
    });

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlite("Data Source=quizzler.db"));

var app = builder.Build();

// // // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// // {
// //     app.MapOpenApi();
// // }

app.MapControllers();
app.Run();

// OpenQuestion openQuestion = new OpenQuestion
// {
//     prompt = "this is a prompt",
//     answer = "answer"
// };

// Console.WriteLine(JsonSerializer.Serialize(openQuestion));