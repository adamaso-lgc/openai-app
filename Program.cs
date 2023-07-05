using OpenaiApp.Configurations;
using OpenaiApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var openAiApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

builder.Services.Configure<OpenAiConfig>(options =>
{
    options.Key = openAiApiKey;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOpenAiService, OpenAiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();